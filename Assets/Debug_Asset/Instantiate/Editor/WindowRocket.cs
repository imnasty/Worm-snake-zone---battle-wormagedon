using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class WindowRocket : EditorWindow
{
    public static void ShowWindow()
    {
        GetWindow<WindowRocket>("Alert");
    }

    private void OnGUI() {
    GUILayout.Label("Игра это ракетка или ее производные?",EditorStyles.boldLabel);    
    if (GUILayout.Button("Да, установить автоматически параметры")) { }
    if (GUILayout.Button("Нет, я всё сделаю сам")) { }

    }

}
