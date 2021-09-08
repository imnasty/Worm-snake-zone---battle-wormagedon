using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Lean;



[Serializable]
public class ScreenshotHandler : MonoBehaviour
{
    public Lean.Localization.LeanLocalization leans;
    public static ScreenshotHandler instance;
    private bool IsTransparent = false;
    private bool OpenFileDirecoty = true;
    public bool screenwork=false;
    private TextureFormat transp = TextureFormat.ARGB32;
    private TextureFormat nonTransp = TextureFormat.RGB24;

    private KeyCode ShotKey = KeyCode.Space;

    public Resolution[] Resolutions;
    private UnityEngine.UI.Text test;


    private void Start() {
        instance=this;
    }
    private void Awake() {
        instance=this;
    }
    public void testtt()
    {
        Debug.LogWarning(UnityEngine.Application.persistentDataPath);
        Debug.LogWarning(UnityEngine.Application.dataPath);
        Debug.LogWarning(UnityEngine.Application.temporaryCachePath);
        Debug.LogWarning(UnityEngine.Application.streamingAssetsPath);

    }
    public void GetFolder()
    {
        if (PlayerPrefs.GetString("Folderopen") == "True")
        {
            OpenFileDirecoty = true;
        }
        else
        {
            OpenFileDirecoty = false;
        }
    }
    public void wwwww()
    {
        for (int i = 0; i < Resolutions.Length; i++)
        {
            Capture(Resolutions[i].Width, Resolutions[i].Height, 1);

            /*if (Resolutions[i].Width == 0 || Resolutions[i].Height == 0)
            {
                Debug.LogWarning("Resolution can't be 0 !");
                return;
            }
            else
            {


            }*/
        }
    }
    public void wwwww2()
    {/*
        Invoke("")


        screenwork=true;
        StartCoroutine(waitins());
        for(int i=0; i<1000;i++){}
        Debug.LogError("корутина завершена");
      */
        StartCoroutine(Screenwait());
    }
    public void Playerprefss()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
    public IEnumerator Screenwait()
    {
        WebDavSTA.instance.delete2();
        yield return StartCoroutine(waitins());
        Debug.LogError("qwertyuiop");
        WebDavSTA.instance.LoadEnglish();
        WebDavSTA.instance.StartCoroutine(WebDavSTA.instance.UploadScreen());
    }
    IEnumerator waitins()
    {
        Debug.LogError("Старт 15 сек");
        yield return new WaitForSecondsRealtime(7);
        Debug.LogError("продолжаем");
        leans.SetCurrentLanguage("Russian");
        for (int i = 0; i < Resolutions.Length; i++)
        {
            Capture2(Resolutions[i].Width, Resolutions[i].Height, 1);

            /*if (Resolutions[i].Width == 0 || Resolutions[i].Height == 0)
            {
                Debug.LogWarning("Resolution can't be 0 !");
                return;
            }
            else
            {


            }*/
        }
        Debug.LogError("Старт 1 сек");
        yield return new WaitForSecondsRealtime(7);
        Debug.LogError("продолжаем");
        leans.SetCurrentLanguage("English");
        for (int i = 0; i < Resolutions.Length; i++)
        {
            Capture2(Resolutions[i].Width, Resolutions[i].Height, 1);

            /*if (Resolutions[i].Width == 0 || Resolutions[i].Height == 0)
            {
                Debug.LogWarning("Resolution can't be 0 !");
                return;
            }
            else
            {


            }*/
        }
        Debug.LogError("Старт 1 сек");
        yield return new WaitForSecondsRealtime(7);
        Debug.LogError("продолжаем");
        leans.SetCurrentLanguage("Chinese");
        for (int i = 0; i < Resolutions.Length; i++)
        {
            Capture2(Resolutions[i].Width, Resolutions[i].Height, 1);

            /*if (Resolutions[i].Width == 0 || Resolutions[i].Height == 0)
            {
                Debug.LogWarning("Resolution can't be 0 !");
                return;
            }
            else
            {


            }*/
        }
        Debug.LogError("Старт 1 сек");
        yield return new WaitForSecondsRealtime(7);
        Debug.LogError("продолжаем");
        leans.SetCurrentLanguage("Spanish");
        for (int i = 0; i < Resolutions.Length; i++)
        {
            Capture2(Resolutions[i].Width, Resolutions[i].Height, 1);

            /*if (Resolutions[i].Width == 0 || Resolutions[i].Height == 0)
            {
                Debug.LogWarning("Resolution can't be 0 !");
                return;
            }
            else
            {


            }*/
        }
        Debug.LogError("Старт 15 сек");
        yield return new WaitForSecondsRealtime(7);
        Debug.LogError("продолжаем");
        leans.SetCurrentLanguage("Arabic");
        for (int i = 0; i < Resolutions.Length; i++)
        {
            Capture2(Resolutions[i].Width, Resolutions[i].Height, 1);

            /*if (Resolutions[i].Width == 0 || Resolutions[i].Height == 0)
            {
                Debug.LogWarning("Resolution can't be 0 !");
                return;
            }
            else
            {


            }*/
        }
        Debug.LogError("Старт 1 сек");
        yield return new WaitForSecondsRealtime(7);
        Debug.LogError("продолжаем");
        leans.SetCurrentLanguage("Japanese");
        for (int i = 0; i < Resolutions.Length; i++)
        {
            Capture2(Resolutions[i].Width, Resolutions[i].Height, 1);

            /*if (Resolutions[i].Width == 0 || Resolutions[i].Height == 0)
            {
                Debug.LogWarning("Resolution can't be 0 !");
                return;
            }
            else
            {


            }*/
        }
        Debug.LogError("Старт 1 сек");
        yield return new WaitForSecondsRealtime(7);
        Debug.LogError("продолжаем");
        leans.SetCurrentLanguage("Portuguese");
        for (int i = 0; i < Resolutions.Length; i++)
        {
            Capture2(Resolutions[i].Width, Resolutions[i].Height, 1);

            /*if (Resolutions[i].Width == 0 || Resolutions[i].Height == 0)
            {
                Debug.LogWarning("Resolution can't be 0 !");
                return;
            }
            else
            {


            }*/
        }
        screenwork=false;
    }
    public void papke()
    {
        string[] allfiles = Directory.GetFiles(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1080x1920/");
        foreach (string filename in allfiles)
        {
            Debug.Log(filename);
        }
    }
    public void perviy()
    {
        Capture(Resolutions[0].Width, Resolutions[0].Height, 1);

    }
    public void vtoroy()
    {
        Capture(Resolutions[1].Width, Resolutions[1].Height, 1);
    }
    /* private void LateUpdate()
     {
         if (Input.GetKeyDown(ShotKey))
         {
             if (Resolutions.Length == 0)
             {
                 Debug.LogWarning("no resolution found !");
                 return;



             }
             else
             {
                 for (int i = 0; i < Resolutions.Length; i++)
                 {
                     if (Resolutions[i].Width == 0 || Resolutions[i].Height == 0)
                     {
                         Debug.LogWarning("Resolution can't be 0 !");
                         return;
                     }
                     else
                     {
                         Capture(Resolutions[i].Width, Resolutions[i].Height, 1);
                     }
                 }
             }
         }
     }
 */
    public void Capture(int width, int height, int enlargeCOEF)
    {
        TextureFormat textForm = nonTransp;

        if (IsTransparent)
            textForm = transp;
        RenderTexture rt = new RenderTexture(width * enlargeCOEF, height * enlargeCOEF, 24);
        Camera.main.targetTexture = rt;
        Texture2D screenShot = new Texture2D(width * enlargeCOEF, height * enlargeCOEF, textForm, false);
        Camera.main.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, width * enlargeCOEF, height * enlargeCOEF), 0, 0);
        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = ScreenshotName("ANDROID+", (width * enlargeCOEF).ToString(), (height * enlargeCOEF).ToString());

        //   Debug.LogWarning("Принял путь");
        if (!Directory.Exists(UnityEngine.Application.persistentDataPath + "/../screenshots/"))
        {
            Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/");
            Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/en");
            Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ru");
            Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1080x1920");
            Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/en/1600x2560");
            Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1080x1920");
            Directory.CreateDirectory(UnityEngine.Application.persistentDataPath + "/../screenshots/ru/1600x2560");
            Debug.LogWarning("Создана папка");
        }
        System.IO.File.WriteAllBytes(filename, bytes);

        Debug.Log(string.Format("Took screenshot to: {0}", filename));
        // test.text = string.Format("Took screenshot to: {0}", filename);
        /*if (OpenFileDirecoty)
        {
            Process.Start(UnityEngine.Application.persistentDataPath + "/screenshots/");
        }*/
    }

    public void Capture2(int width, int height, int enlargeCOEF)
    {
        TextureFormat textForm = nonTransp;

        if (IsTransparent)
            textForm = transp;
        RenderTexture rt = new RenderTexture(width * enlargeCOEF, height * enlargeCOEF, 24);
        Camera.main.targetTexture = rt;
        Texture2D screenShot = new Texture2D(width * enlargeCOEF, height * enlargeCOEF, textForm, false);
        Camera.main.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, width * enlargeCOEF, height * enlargeCOEF), 0, 0);
        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = ScreenshotName("ANDROID+", (width * enlargeCOEF).ToString(), (height * enlargeCOEF).ToString());

        //   Debug.LogWarning("Принял путь");
        if (!Directory.Exists(UnityEngine.Application.dataPath + "/screenshots/"))
        {
            Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/");
            Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/en");
            Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ru");
            Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/en/1080x1920");
            Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/en/1600x2560");
            Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ru/1080x1920");
            Directory.CreateDirectory(UnityEngine.Application.dataPath + "/screenshots/ru/1600x2560");
            Debug.LogWarning("Создана папка");
        }
        System.IO.File.WriteAllBytes(filename, bytes);

        Debug.Log(string.Format("Took screenshot to: {0}", filename));
        // test.text = string.Format("Took screenshot to: {0}", filename);
        /*if (OpenFileDirecoty)
        {
            Process.Start(UnityEngine.Application.persistentDataPath + "/screenshots/");
        }*/
    }
    private string ScreenshotName(string platform, string width, string height)
    {
        if (UnityEngine.Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (width == "1080")
            {
                if (Lean.Localization.LeanLocalization.currentLanguage == "Russian")
                {
                    return string.Format("{0}/screenshots/ru/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "English")
                {
                    return string.Format("{0}/screenshots/en/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Chinese")
                {
                    return string.Format("{0}/screenshots/cn/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Spanish")
                {
                    return string.Format("{0}/screenshots/sp/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Arabic")
                {
                    return string.Format("{0}/screenshots/ar/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Japanese")
                {
                    return string.Format("{0}/screenshots/jp/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Portuguese")
                {
                    return string.Format("{0}/screenshots/pt/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else
                {
                    return string.Format("{0}/screenshots/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
            }
            else if (width == "1600")
            {
                if (Lean.Localization.LeanLocalization.currentLanguage == "Russian")
                {
                    return string.Format("{0}/screenshots/ru/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "English")
                {
                    return string.Format("{0}/screenshots/en/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Chinese")
                {
                    return string.Format("{0}/screenshots/cn/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Spanish")
                {
                    return string.Format("{0}/screenshots/sp/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Arabic")
                {
                    return string.Format("{0}/screenshots/ar/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Japanese")
                {
                    return string.Format("{0}/screenshots/jp/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Portuguese")
                {
                    return string.Format("{0}/screenshots/pt/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else
                {
                    return string.Format("{0}/screenshots/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
            }
            else if (width == "1242")
            {
                if (Lean.Localization.LeanLocalization.currentLanguage == "Russian")
                {
                    return string.Format("{0}/screenshots/ru/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "English")
                {
                    return string.Format("{0}/screenshots/en/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Chinese")
                {
                    return string.Format("{0}/screenshots/cn/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Spanish")
                {
                    return string.Format("{0}/screenshots/sp/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Arabic")
                {
                    return string.Format("{0}/screenshots/ar/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Japanese")
                {
                    return string.Format("{0}/screenshots/jp/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Portuguese")
                {
                    return string.Format("{0}/screenshots/pt/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else
                {
                    return string.Format("{0}/screenshots/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
            }
            else if (width == "2048")
            {
                if (Lean.Localization.LeanLocalization.currentLanguage == "Russian")
                {
                    return string.Format("{0}/screenshots/ru/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "English")
                {
                    return string.Format("{0}/screenshots/en/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Chinese")
                {
                    return string.Format("{0}/screenshots/cn/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Spanish")
                {
                    return string.Format("{0}/screenshots/sp/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Arabic")
                {
                    return string.Format("{0}/screenshots/ar/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Japanese")
                {
                    return string.Format("{0}/screenshots/jp/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Portuguese")
                {
                    return string.Format("{0}/screenshots/pt/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else
                {
                    return string.Format("{0}/screenshots/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
            }
            else
            {
                return string.Format("{0}/screenshots/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            }
        }
        else
        {
            if (width == "1080")
            {
                if (Lean.Localization.LeanLocalization.currentLanguage == "Russian")
                {
                    return string.Format("{0}/../screenshots/ru/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "English")
                {
                    return string.Format("{0}/../screenshots/en/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Chinese")
                {
                    return string.Format("{0}/../screenshots/cn/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Spanish")
                {
                    return string.Format("{0}/../screenshots/sp/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Arabic")
                {
                    return string.Format("{0}/../screenshots/ar/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Japanese")
                {
                    return string.Format("{0}/../screenshots/jp/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Portuguese")
                {
                    return string.Format("{0}/../screenshots/pt/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else
                {
                    return string.Format("{0}/../screenshots/1080x1920/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
            }
            else if (width == "1600")
            {
                if (Lean.Localization.LeanLocalization.currentLanguage == "Russian")
                {
                    return string.Format("{0}/../screenshots/ru/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "English")
                {
                    return string.Format("{0}/../screenshots/en/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Chinese")
                {
                    return string.Format("{0}/../screenshots/cn/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Spanish")
                {
                    return string.Format("{0}/../screenshots/sp/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Arabic")
                {
                    return string.Format("{0}/../screenshots/ar/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Japanese")
                {
                    return string.Format("{0}/../screenshots/jp/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Portuguese")
                {
                    return string.Format("{0}/../screenshots/pt/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else
                {
                    return string.Format("{0}/../screenshots/1600x2560/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
            }
            else if (width == "1242")
            {
                if (Lean.Localization.LeanLocalization.currentLanguage == "Russian")
                {
                    return string.Format("{0}/../screenshots/ru/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "English")
                {
                    return string.Format("{0}/../screenshots/en/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Chinese")
                {
                    return string.Format("{0}/../screenshots/cn/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Spanish")
                {
                    return string.Format("{0}/../screenshots/sp/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Arabic")
                {
                    return string.Format("{0}/../screenshots/ar/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Japanese")
                {
                    return string.Format("{0}/../screenshots/jp/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Portuguese")
                {
                    return string.Format("{0}/../screenshots/pt/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else
                {
                    return string.Format("{0}/../screenshots/1242x2208/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
            }
            else if (width == "2048")
            {
                if (Lean.Localization.LeanLocalization.currentLanguage == "Russian")
                {
                    return string.Format("{0}/../screenshots/ru/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "English")
                {
                    return string.Format("{0}/../screenshots/en/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Chinese")
                {
                    return string.Format("{0}/../screenshots/cn/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Spanish")
                {
                    return string.Format("{0}/../screenshots/sp/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Arabic")
                {
                    return string.Format("{0}/../screenshots/ar/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Japanese")
                {
                    return string.Format("{0}/../screenshots/jp/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else if (Lean.Localization.LeanLocalization.currentLanguage == "Portuguese")
                {
                    return string.Format("{0}/../screenshots/pt/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
                else
                {
                    return string.Format("{0}/../screenshots/2048x2732/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                }
            }
            else
            {
                return string.Format("{0}/../screenshots/" + "_" + platform + "screen_{1}x{2}_{3}.png", UnityEngine.Application.persistentDataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            }
        }




    }
}