
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Enemy : MonoBehaviour {

    [Header("GameObjects References")]
    public GameObject GO_Explosion;
    public GameObject GO_Bullet;
    public GameObject GO_BulletSpawn;
    public GameObject GO_Canvas;

    [Header("Enemies' Sprites")]
    public Sprite[] Enemies;

    [Header("Health")]
    public int i_hp;

    [Header("Cooldown Limits")]
    public static int i_minCD = 1;
    public static int i_maxCD = 30;

    float f_coolDown;

    private Scr_Player scrP;

	void Start () {
        f_coolDown = Random.Range(i_minCD,i_maxCD);
        GetComponent<Image>().sprite = Enemies[Random.Range(0, Enemies.Length)];
        scrP = GameObject.FindGameObjectWithTag("Player").GetComponent<Scr_Player>();
        StartCoroutine(StartShooting());
	}

    IEnumerator StartShooting()
    {
        yield return new WaitForSeconds(f_coolDown);
        Shoot();
        StartCoroutine(StartShooting());
    }

    void Shoot()
    {
        Instantiate(GO_Bullet, GO_BulletSpawn.transform.position, Quaternion.identity, GO_Canvas.transform);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (i_hp > 1)
                i_hp--;
            else
                Explode();
        }

        if(other.CompareTag("DeadZone")&& scrP != null)
        {
            Debug.Log("Murio el player");
            scrP.i_lives = 1;
            scrP.Explode();
        }
    }

    void Explode()
    {
        GetComponent<Image>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Instantiate(GO_Explosion, transform.position, Quaternion.identity, transform);
        Invoke("DestroySelf", 1f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
