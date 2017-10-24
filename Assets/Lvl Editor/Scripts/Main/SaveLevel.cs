using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLevel : MonoBehaviour {

	public void OnSaveClicked()
    {
        if (!Directory.Exists(Application.dataPath + "/Levels/"))
            Directory.CreateDirectory(Application.dataPath + "/Levels/");
        //FileStream fileStream = File.Create(Application.dataPath + "/Levels/");
    }
}
