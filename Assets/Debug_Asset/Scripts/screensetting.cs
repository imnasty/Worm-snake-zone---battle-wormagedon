using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screensetting : MonoBehaviour
{
    public Toggle Folder;
    public InputField namefolder;
    public InputField Password;
    public InputField Username;
    public void SetFolder()
    {
        PlayerPrefs.SetString("Folderopen", Folder.isOn.ToString());
    }
    public void GetFolder()
    {
        if (PlayerPrefs.GetString("Folderopen") == "True")
        {
            Folder.isOn = true;
        }
        else
        {
            Folder.isOn = false;
        }
    }
    public void SetPassword()
    {
        PlayerPrefs.SetString("Password",Password.text);
    }
    public void GetPassword()
    {
        Password.text=PlayerPrefs.GetString("Password");
    }
    public void SetNameFolder()
    {
        PlayerPrefs.SetString("Namefolder", namefolder.text);
    }
    public void GetNameFolder()
    {
        namefolder.text = PlayerPrefs.GetString("Namefolder");
    }
    public void SetUsername()
    {
        PlayerPrefs.SetString("Username",Username.text);
    }
    public void GetUsername()
    {
        Username.text=PlayerPrefs.GetString("Username");
    }
}
