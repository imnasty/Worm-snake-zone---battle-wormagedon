using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class version : MonoBehaviour
{
    public static version Instance;
    private int debug = 0;
    public GameObject debuglogin;
    public Text Versiontext;
    public InputField Loginfield;
    public GameObject Debugsetting;
    public GameObject CanvasConsole;
    public GameObject CanvasScreen;
    public Toggle console;
    public Toggle screen;
    public Toggle reklama;
    // Start is called before the first frame update
    void Start()
    {
        Versiontext.text = "ver " + Application.version.ToString();
        checkcanvas();
    }
    private void Awake()
    {
        Instance = this;
    }
    public void checkcanvas()
    {
        if (PlayerPrefs.GetString("console") == "true")
        {
            CanvasConsole.SetActive(true);
        }
        else
        {
            CanvasConsole.SetActive(false);
        }

        if (PlayerPrefs.GetString("screen") == "true")
        {
            CanvasScreen.SetActive(true);
        }
        else
        {
            CanvasScreen.SetActive(false);
        }
    }
    // Update is calld once per frame
    public void DebugCkick()
    {
        debug++;
        if (debug == 20)
        {
            debug = 0;
            debuglogin.SetActive(true);
        }
    }
    public void Login()
    {
        if (Loginfield.text == "askerweb")
        {
            debuglogin.SetActive(false);
            Loginfield.text = " ";
            Debugsetting.SetActive(true);
        }
    }
    public void Debugsettingsave()
    {
        if (console.isOn == true)
        {
            PlayerPrefs.SetString("console", "true");
        }
        else
        {
            PlayerPrefs.SetString("console", "false");
        }
        if (screen.isOn == true)
        {
            PlayerPrefs.SetString("screen", "true");
        }
        else
        {
            PlayerPrefs.SetString("screen", "false");
        }
        if (reklama.isOn == true)
        {
            PlayerPrefs.SetString("reklama", "true");
        }
        else
        {
            PlayerPrefs.SetString("reklama", "false");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public static Object Find(string name, System.Type type)
    {
        Object[] objects = Resources.FindObjectsOfTypeAll(type);
        foreach (var obj in objects)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }
        return null;
    }
    public static GameObject Find(string name)
    {
        return Find(name, typeof(GameObject)) as GameObject;
    }
    public void FindCanvass()
    {

        Debug.Log("ВЫполняю");
        CanvasConsole = GameObject.Find("IngameDebugConsole");
        CanvasScreen = GameObject.Find("CanvasScreen");
        CanvasConsole.SetActive(false);
        CanvasScreen.SetActive(false);

    }
}
