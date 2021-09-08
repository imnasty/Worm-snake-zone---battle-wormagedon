using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class statusloading : MonoBehaviour
{
    public GameObject loadingpanel;
    public GameObject canvas;
    public Text texts;
    public Slider slider;
    public Text textscreen;
    public Slider screenslider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textscreen.text=texts.text=PlayerPrefs.GetInt("loadsscreen",0).ToString()+" из 6";
        screenslider.value=PlayerPrefs.GetInt("loadsscreen",0);
        texts.text=PlayerPrefs.GetInt("loadingscreen").ToString()+" из 28";
        slider.value=PlayerPrefs.GetInt("loadingscreen");
     
     //   Debug.LogWarning(PlayerPrefs.GetInt("loadingscreen").ToString());
        if (PlayerPrefs.GetInt("loadingscreen")==28)
        {
           // Debug.LogWarning("попытка закрыть окно");
            PlayerPrefs.SetInt("loadingscreen",0);
            if (PlayerPrefs.GetInt("loadsscreen",0)==6){
            loadingpanel.SetActive(false);
            }
           // canvas.SetActive(false);
        }
    }
}
