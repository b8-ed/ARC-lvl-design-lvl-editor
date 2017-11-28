using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public int healthPoints;
    public int velocity;
    public float coolDown;
    public int score = 0;
    public bool isDead = false;

    [Header("Player UI")]
    public Slider SLD_HP;
    public Text TXT_Score;

    [Header("Bullets")]
    public GameObject [] bulletTypeArray;
    public GameObject goBulletSpawn;   

    private bool canShoot = true;
    private Rigidbody2D rb2DPlayer;
    private Animator animPlayer;
    private int directionHash;
    private int isDeadHash;

	void Start ()
    {
        rb2DPlayer = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();

        directionHash = Animator.StringToHash("Direction");
        isDeadHash = Animator.StringToHash("IsDead");
	}
	
	void Update ()
    {
        if(!isDead)
        {
            Shoot(bulletTypeArray[0]);
            Movement();
        }

        Stats();

        if (Input.GetKeyDown(KeyCode.C))
            TakeDamage(5);
	}

    public void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        animPlayer.SetFloat(directionHash, x);

        Vector2 movement = new Vector2(x, y);
        transform.Translate(movement * Time.deltaTime * velocity);
    }

    public void Shoot(GameObject _goBullet)
    {
        if(canShoot)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(_goBullet, goBulletSpawn.transform.position, Quaternion.identity);
                Debug.Log("I am shooting");
                StartCoroutine(TurnOffCooldown());
            }
        }
    }

    public void SwitchBulletType()
    {

    }

    public void Stats()
    {
        SLD_HP.value = healthPoints;
        TXT_Score.text = "SCORE: " + score;
    }

    public void TakeDamage(int _damagePoints)
    {
        healthPoints-= _damagePoints;
        if(healthPoints <= 0)
        {
            isDead = true;
            healthPoints = 0;
            Dead();
        }
    }

    public void Dead()
    {
        Debug.Log("I am dead");
        animPlayer.SetTrigger(isDeadHash);
    }

    IEnumerator TurnOffCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
}
