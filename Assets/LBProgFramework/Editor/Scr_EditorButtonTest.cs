using UnityEngine;
using UnityEditor;
public class Scr_EditorButtonTest : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    // Add menu named "My Window" to the Window menu
    [MenuItem("GameObject/UI/My Window")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        Scr_EditorButtonTest window = (Scr_EditorButtonTest)EditorWindow.GetWindow(typeof(Scr_EditorButtonTest));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();
    }
}