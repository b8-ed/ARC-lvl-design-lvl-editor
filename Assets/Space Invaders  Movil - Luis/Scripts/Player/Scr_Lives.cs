///Script by Luis Bazan
///Git User: luisquid11

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Lives : MonoBehaviour {

    public Image[] lives;
    Scr_Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Scr_Player>();    
    }

    void Update () {
		for(int i = 0; i < lives.Length; i++)
        {
            if (i  >= player.i_lives)
                lives[i].enabled = false;
        }
	}
}
