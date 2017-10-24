///Script by Luis Bazan
///Git User: luisquid11

using UnityEngine;
using UnityEngine.UI;

public class Scr_ToggleText : MonoBehaviour {

    public float f_maxTime;

    Text txt_Toggle;
    float f_time;

    void Start()
    {
        txt_Toggle = GetComponent<Text>();    
    }

    void Update ()
    {
        f_time += Time.deltaTime;

        if(f_time >= f_maxTime)
        {
            txt_Toggle.enabled = !txt_Toggle.enabled;
            f_time = 0.0f;
        }
	}
}
