using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_ChangeTargetColor : MonoBehaviour {

    Color initialColor;

    Image IMG_Target;

	void Start ()
    {
        IMG_Target = GetComponent<Image>();
        initialColor = IMG_Target.color;
	}
	
	void Update ()
    {
        CheckIfEnemy();
	}

    private void CheckIfEnemy()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Enemy"))
        {
            IMG_Target.color = Color.red;
        }

        else
        {
            IMG_Target.color = initialColor;
        }
    }
}
