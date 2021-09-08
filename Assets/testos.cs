using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testos : MonoBehaviour
{
    // Start is called before the first frame update
    public static void Test()
    {
        if (Application.platform==RuntimePlatform.WindowsEditor)
    {
        Debug.LogError("редактор юнити");
    }
if (Application.platform==RuntimePlatform.WindowsPlayer)
    {
        Debug.LogError("windows");
    }
    if (Application.platform==RuntimePlatform.Android)
    {
        Debug.LogError("android");
    }
Debug.LogError(Application.persistentDataPath.ToString());
Debug.LogError(Application.dataPath.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
