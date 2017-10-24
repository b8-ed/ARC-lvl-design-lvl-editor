///Script by Luis Bazan
///Git User: luisquid11

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Player : MonoBehaviour
{

    public GameObject GO_BulletSpawn;
    public GameObject GO_Bullet;
    public GameObject GO_Canvas;
    public GameObject GO_LeftLimit;
    public GameObject GO_RightLimit;
    public GameObject GO_Explosion;
    public int i_lives;
    public int i_velocity;
    public float f_coolDown;

    RectTransform RECT_Player;
    bool b_moveLeft = false;
    bool b_moveRight = false;
    bool b_canShoot = true;


    void Start()
    {
        RECT_Player = GetComponent<RectTransform>();
    }

    public void OnLeftArrowClickedDown()
    {
        b_moveLeft = true;
    }

    public void OnRightArrowClickedDown()
    {
        b_moveRight = true;
    }

    public void OnLeftArrowClickedUp()
    {
        b_moveLeft = false;
    }

    public void OnRightArrowClickedUp()
    {
        b_moveRight = false;
    }


    void Update()
    {
        if (b_moveLeft && transform.position.x - (RECT_Player.rect.width/2) > GO_LeftLimit.transform.position.x)
        {
            transform.Translate(Vector3.left * i_velocity);
        }

        if (b_moveRight && transform.position.x + (RECT_Player.rect.width / 2) < GO_RightLimit.transform.position.x)
        {
            transform.Translate(Vector3.right * i_velocity);
        }

        //if (transform.position.x + (RECT_Player.rect.width / 2) < GO_RightLimit.transform.position.x &&
        //    transform.position.x - (RECT_Player.rect.width / 2) > GO_LeftLimit.transform.position.x)
        //    transform.Translate(new Vector3(Input.acceleration.x * i_velocity, 0, 0));
    }

    public void Shoot()
    {
        if (b_canShoot)
        {
            Instantiate(GO_Bullet, GO_BulletSpawn.transform.position, Quaternion.identity, GO_Canvas.transform);
            b_canShoot = false;
            StartCoroutine(TurnOffCooldown());
        }
    }

    IEnumerator CheckNumberOfEnemies()
    {
        yield return new WaitForSeconds(5f);
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(Enemies.Length == 0)
        {
            GameObject.Find("StartText").GetComponent<Text>().enabled = true;
            GameObject.Find("StartText").GetComponent<Text>().text = "YOU WON";
        }
    }

    IEnumerator TurnOffCooldown()
    {
        yield return new WaitForSeconds(f_coolDown);
        b_canShoot = true;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BulletEnemy"))
        {
            if (i_lives > 1)
                i_lives--;
            else
                Explode();
        }
    }

    public void Explode()
    {
        i_lives--;
        GetComponent<Image>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Instantiate(GO_Explosion, transform.position, Quaternion.identity, transform);
        Invoke("DestroySelf", 1f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (GameObject.Find("StartText") == null)
            return;

        GameObject.Find("StartText").GetComponent<Text>().enabled = true;
        GameObject.Find("StartText").GetComponent<Text>().text = "GAME OVER";
        FindObjectOfType<Scr_GoToMenu>().OnPlayerDead();
    }
}
