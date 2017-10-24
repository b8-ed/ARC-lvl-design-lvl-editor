///Script by Luis Bazan
///Git User: luisquid11

using UnityEngine;
//Importamos libreria necesaria para usar el cargado de escenas
using UnityEngine.SceneManagement;

public class Scr_LoadLevel : MonoBehaviour {

    //Nombre de escena a cargar
    public string str_levelName;
void Start()
    {
#if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;
#elif UNITY_ANDROID  
        Application.targetFrameRate = 30;
#endif
    }
    void Update ()
    {
        //Si la cantidad de touch en pantalla es mayor que 0 cargamos la siguiente escena
		if(Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(str_levelName);
        }
	}
}
