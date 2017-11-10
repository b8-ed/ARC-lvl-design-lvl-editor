using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_WeaponRecoil : MonoBehaviour {

    float timer = 0.0f;
    float timerEnd = 0.15f;
    Vector3 startPosition;
    bool recoil = false;

	void Start ()
    {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {	
        //IN HOLD TILL SHOOTING IS FINISHED
        //if(Input.GetMouseButtonDown(0))
        //{
        //    transform.position = (Vector3.left * 0.3f);
        //    recoil = true;
        //}

        //if(recoil)
        //{
        //    timer += Time.deltaTime;

        //    if (timer >= timerEnd)
        //    {
        //        transform.position = startPosition;
        //        recoil = false;
        //    }
        //}
	}
}
