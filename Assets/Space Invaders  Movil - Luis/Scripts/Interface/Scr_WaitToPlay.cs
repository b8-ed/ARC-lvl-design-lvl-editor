///Script by Luis Bazan
///Git User: luisquid11

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scr_WaitToPlay : MonoBehaviour {

    Text txt_Tap;

	void Start () {
        txt_Tap = GetComponent<Text>();
        StartCoroutine(TurnOffText());
	}

    IEnumerator TurnOffText()
    {
        yield return new WaitForSeconds(3.0f);
        txt_Tap.enabled = false;
    }
}
