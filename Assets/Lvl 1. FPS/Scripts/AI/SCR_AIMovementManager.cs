using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using LBProgramming;

public class SCR_AIMovementManager : MonoBehaviour {

    public AIManager aiManager;

    private NavMeshAgent agent;
    private Animator anim;
    private GameObject player;
    private SkinnedMeshRenderer skindMsh;

    bool isDead = false;

    void Start()
    {
        aiManager = FindObjectOfType<AIManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        skindMsh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            Die();

        if (Input.GetKeyDown(KeyCode.I))
            Idle();

        if (Input.GetKeyDown(KeyCode.P))
            Patrol(player.transform.position);

        if (Input.GetKeyDown(KeyCode.R))
            Respawn();

        //if (agent.velocity.magnitude > 0)
        //    anim.SetBool("IsRunning", true);
        //else
        //    anim.SetBool("IsRunning", false);

        //if (agent.remainingDistance < 5 && anim.GetBool("IsRunning"))
        //{
        //    agent.isStopped = true;
        //    anim.SetBool("IsShooting", true);
        //}
        //else
        //    anim.SetBool("IsShooting", false);      
    }

    public void Idle()
    {
        agent.isStopped = true;
        anim.SetBool("IsRunning", false);
    }

    public void Aim(Vector3 v3Target)
    {
        transform.LookAt(v3Target);
    }

    public void Patrol(Vector3 destination)
    {
        agent.SetDestination(destination);
        agent.isStopped = false;
        anim.SetBool("IsRunning", true);
    }

    public void Die()
    {
        anim.SetBool("IsDead", true);
        //AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        //AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);
        //float time = clipInfo[0].clip.length * state.normalizedTime;

        //if (anim.GetFloat("Juanito") >= 1.0f)
        //    anim.enabled = false;
        //if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Death From The Back" && time > clipInfo[0].clip.length)
        //    anim.enabled = false;
        if (anim.GetBool("IsDead") && !agent.isStopped)
            agent.isStopped = true;

        isDead = true;

        AIManager.disappearedEnemies.AddAndExecute(gameObject, aiManager.DissappearAll);
    }

    public void Respawn()
    {
        skindMsh.enabled = true;
        anim.enabled = true;
        anim.SetBool("IsDead", false);
        anim.SetBool("IsRunning", false);
        isDead = false;

        //AIManager.disappearedEnemies.RemoveAndExecute(this.gameObject, aiManager.ReAppear(gameObject));
    }

    
}
