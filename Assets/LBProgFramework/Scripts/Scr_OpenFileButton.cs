using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Scr_OpenFileButton : MonoBehaviour
{
    public string path;

#if UNITY_EDITOR
    public void OpenDialog()
    {
        path = EditorUtility.OpenFilePanel(
                    "Open file",
                    "",
                    "*");
    }
#endif
}