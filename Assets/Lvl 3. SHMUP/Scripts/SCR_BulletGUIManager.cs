using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_BulletGUIManager : MonoBehaviour {

    [Header("Bullet Buttons")]
    public Button []BTN_Types;

    private SCR_PlayerController pCtrl;

    // Use this for initialization
    void Start () {
        pCtrl = FindObjectOfType<SCR_PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        for(int i = 0; i < BTN_Types.Length; i++)
        {
           if(i == pCtrl.bulletIndex)
            {
                BTN_Types[i].transform.Find("IMG_BulletActivated").gameObject.SetActive(true);
            }
           else
            {
                BTN_Types[i].transform.Find("IMG_BulletActivated").gameObject.SetActive(false);
            }
        }
	}
}
