using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LBProgramming;

public class SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.CompareTag("Selectable"))
                {
                    ObjectClass.ToggleObject(hit.transform.gameObject.GetComponent<ObjectClass>());
                }
            }           
        }
	}
}
