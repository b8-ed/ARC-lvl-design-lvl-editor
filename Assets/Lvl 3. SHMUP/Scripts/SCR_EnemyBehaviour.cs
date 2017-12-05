//Code by Luis Bazan
//Github user: luisquid11

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyBehaviour : MonoBehaviour {
    
    [Header("Enemy Stats")]
    public int healthPoints = 100;
    public int armor;

    private bool isDead = false;
    private Animator animEnemy;
    private int isDeadHash;
    
    void Start () 
	{
        animEnemy = GetComponent<Animator>();
        isDeadHash = Animator.StringToHash("IsDead");
	}
	
	void Update () 
	{
		
	}

    public void Dead()
    {
        Debug.Log("I am dead");
        animEnemy.SetTrigger(isDeadHash);
    }

    public void TakeDamage(int _damagePoints)
    {
        healthPoints -= _damagePoints;
        if(healthPoints <= 0)
        {
            isDead = true;
            healthPoints = 0;
            Dead();
        }
    }
}
