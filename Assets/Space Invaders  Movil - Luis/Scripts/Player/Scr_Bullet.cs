///Script by Luis Bazan
///Git User: luisquid11

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Bullet : MonoBehaviour {

    public float f_velocity;
    public bool b_isEnemy;

	void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,f_velocity);   	
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") && !b_isEnemy)
        {
            Destroy(gameObject);
        }
        
        if(other.CompareTag("Player") && b_isEnemy)
        {
            Destroy(gameObject);
        }

        if(other.CompareTag("BulletDead"))
        {
            Destroy(gameObject);
        }
    }
}
