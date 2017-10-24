using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainCanvasManager : MonoBehaviour {

    public void OnSaveClicked()
    {
        Debug.Log(Application.dataPath + "/Levels");
        if (!Directory.Exists(Application.dataPath + "/Levels"))
            Directory.CreateDirectory(Application.dataPath + "/Levels");

        //FileStream fileStream = File.Create(Application.dataPath + "/Levels/MyLevel.txt");
    }
}
