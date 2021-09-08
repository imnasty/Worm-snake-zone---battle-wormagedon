using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AskerManager : MonoBehaviour
{
    [MenuItem("Asker Games/Clear all playerprefs")]
    static void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

}