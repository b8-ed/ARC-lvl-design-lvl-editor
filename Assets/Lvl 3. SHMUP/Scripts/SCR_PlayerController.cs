using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerController : MonoBehaviour {

    public GameObject goSplit;
    public GameObject goTogether;

    public int healthPoints;
    public int velocity;
    public float coolDown;

    private bool canShoot;

    private Rigidbody2D rb2DPlayer;

	void Start ()
    {
        rb2DPlayer = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
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

        }
    }
}
