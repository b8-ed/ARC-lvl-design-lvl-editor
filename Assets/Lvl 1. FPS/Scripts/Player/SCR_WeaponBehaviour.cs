using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_WeaponBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void Shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Enemy"))
        {
            Debug.Log("Im doing damage to " + hit.transform.name);
        }
    }
}
