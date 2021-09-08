using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System.IO;

public class Showpopup : EditorWindow
{

    [MenuItem("Example/ShowPopup Example")]
    static void Init()
    {
        
        Showpopup window = ScriptableObject.CreateInstance<Showpopup>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        var position = window.position;
 position.center = new Rect(0f, 0f, Screen.currentResolution.width, Screen.currentResolution.height).center;
 window.position = position;
        window.ShowPopup();

    }
    [MenuItem("Example/Shell")]
    public static void shell()
    {
        string command="";
        Process process = Process.Start("powershell.exe",command);
        process.WaitForExit();
        process.Close();
    }
    [MenuItem("Example/Load Textures To Folder")]
    static void Apply()
    {
        string path = EditorUtility.OpenFolderPanel("Load png Textures", "", "");
        string[] files = Directory.GetFiles(path);

        foreach (string file in files)
        {
            UnityEngine.Debug.Log(file);
        }
    }
    void OnGUI()
    {
        EditorGUILayout.LabelField("This is an example of EditorWindow.ShowPopup", EditorStyles.wordWrappedLabel);
        GUILayout.Space(70);
        if (GUILayout.Button("OK!")) this.Close();
    }
}
