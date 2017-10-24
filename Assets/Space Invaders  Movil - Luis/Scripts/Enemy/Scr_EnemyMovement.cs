///Script by Luis Bazan
///Git User: luisquid11

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnemyMovement : MonoBehaviour {

    [Header("Movement")]
    public float f_speedMovement;
    public int i_stepsDown;

	void Start () {
        StartCoroutine(MoveDown());
	}
	
	void Update () {
		
	}

    IEnumerator MoveDown()
    {
        yield return new WaitForSeconds(f_speedMovement);
        transform.Translate(Vector3.down * i_stepsDown);
        StartCoroutine(MoveDown());
    }

    IEnumerator MoveSideWays()
    {
        yield return new WaitForSeconds(2f);
        //if()
        transform.Translate(new Vector3());
    }
}
