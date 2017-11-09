using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_ChangeCrossHairSprite : MonoBehaviour {

    public Sprite SPR_ShootingCrossHair;
    public Sprite SPR_IdleCrossHair;

    Image IMG_CrossHair;

	void Start () {
        IMG_CrossHair = GetComponent<Image>();	
	}
	

	void Update ()
    {
		if(Input.GetMouseButton(0))
        {
            IMG_CrossHair.sprite = SPR_ShootingCrossHair;
        }
        else
        {
            IMG_CrossHair.sprite = SPR_IdleCrossHair;
        }
	}
}
