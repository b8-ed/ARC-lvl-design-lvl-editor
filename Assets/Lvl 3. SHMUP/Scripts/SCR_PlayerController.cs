using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public int healthPoints;
    public int velocity;
    public float coolDown;

    [Header("Bullet")]
    public GameObject goBullet;
    public GameObject goBulletSpawn;   

    private bool canShoot = true;

    private Rigidbody2D rb2DPlayer;

	void Start ()
    {
        rb2DPlayer = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        Shoot();
        Movement();
	}

    public void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(x, y);
        transform.Translate(movement * Time.deltaTime * velocity);
    }

    public void Shoot()
    {
        if(canShoot)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(goBullet, goBulletSpawn.transform.position, Quaternion.identity);
                Debug.Log("I am shooting");
                StartCoroutine(TurnOffCooldown());
            }
        }
    }

    IEnumerator TurnOffCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
}
