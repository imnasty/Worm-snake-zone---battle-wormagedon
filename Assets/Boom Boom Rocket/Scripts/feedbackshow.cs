using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedbackshow : MonoBehaviour
{
    public GameObject gameoverscreen;
    public GameObject feedbackpanel;
    public int schet;
    // Update is called once per frame
    public int kol_vo_feedback;
    private int kol_vo;
   
    void Start()
    {
        kol_vo=PlayerPrefs.GetInt("kol_vo",0);
        if (kol_vo < kol_vo_feedback){
       int bestscore = PlayerPrefs.GetInt("BestScore", 0);   
        if (gameoverscreen.activeSelf==true && bestscore >= schet && PlayerPrefs.GetInt("feedbackoff",0)==0)
        {
            kol_vo++;
            PlayerPrefs.SetInt("kol_vo", kol_vo);
            if (PlayerPrefs.GetInt("kol_vo") == kol_vo_feedback)
            feedbackpanel.SetActive(true);

        }
        }
    }
}
