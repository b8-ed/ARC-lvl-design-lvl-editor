using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LBProgramming;

public class Scr_MenuManager : MonoBehaviour {

    public void OnNewLevelClicked()
    {
        LBSceneManager.Instance.LoadScene("Main");
    }

    public void OnLoadLevelClicked()
    {
        LBSceneManager.Instance.LoadSceneAsync("Main");
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
