using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSite : MonoBehaviour
{
    public string goToSite = "https://deliciousgames.askerweb.biz/rocket";
    public string goToMain = "https://deliciousgames.askerweb.biz/";

    public void GoToSitee()
    {
        Application.OpenURL(goToSite);
    }
    public void GoToMain()
    {
        Application.OpenURL(goToMain);
    }
}
