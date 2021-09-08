using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class resolution : MonoBehaviour
{
    public Dropdown dropdawn;
    public Text test;
    // Start is called before the first frame update
    public void DropResolution()
    {
        if(dropdawn.value==0)
        {
            Screen.SetResolution(540,960,false);
        }
        if(dropdawn.value==1)
        {
            Screen.SetResolution(1080,1920,false);
        }
        if(dropdawn.value==2)
        {
            Screen.SetResolution(1080,1920,true);
        }
    }
    public void testresolution()
    {
        ScreenCapture.CaptureScreenshot("test.png");
   // ScreenCapture.CaptureScreenshot(Application.dataPath+"test2.png",4);
    test.text="dwdwdwdw";
    }

}
