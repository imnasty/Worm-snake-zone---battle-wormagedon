using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Show : MonoBehaviour
{
    private float vremya;
    public Text test;
    public GameObject gameoversscreen;
    public GameObject loadingpanel;
    public VideoPlayer adsvideoplayer;
    public VideoPlayer videoPlayerloading;
    public GameObject adspanel;
    public GameObject adsaskerpanel;
    public RawImage image;
    public Text test1;
    public Text test2;
   
    private int ads;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {PlayerPrefs.SetInt("adsvideo",1);
        test1.text=adsvideoplayer.frame.ToString();
        test2.text=adsvideoplayer.frameCount.ToString();
        test.text = vremya.ToString();
        ads = PlayerPrefs.GetInt("ads", 0);
//        Debug.LogError(ads.ToString());
  //      Debug.LogWarning(PlayerPrefs.GetFloat("vremya").ToString());
        vremya = PlayerPrefs.GetFloat("vremya");
        vremya = vremya + Time.deltaTime;
        PlayerPrefs.SetFloat("vremya", vremya);
        if (vremya > 120 + (1800 * ads) && gameoversscreen.activeSelf == true)
        {
            vremya = 0;
            PlayerPrefs.SetFloat("vremya", vremya);
            ads++;
            PlayerPrefs.SetInt("ads", ads);
            adsaskerpanel.SetActive(true);
            adsvideoplayer.Play();
            
        }
        if (videoPlayerloading.frame >1)
        {
            loadingpanel.SetActive(true);
        }

        if (loadingpanel.activeSelf == true)
        {
            if (adsvideoplayer.frame == 10)
            {

                adspanel.SetActive(true);
            }
        }
       /*
        if (((adsvideoplayer.frame+1).ToString() == adsvideoplayer.frameCount.ToString())&&adsvideoplayer.frameCount!=0)
        {
            Debug.LogError("awdoiwdhwudhwudwdhwudhwu");
          PlayerPrefs.SetInt("adsvideo",0);
            adsaskerpanel.SetActive(false);
        }
       */
    }
}
