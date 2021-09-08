using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;

    public int schethelp;
    // Start is called before the first frame update
    void Start()
    {
        schethelp=1;
    }

    // Update is called once per frame
    void Update()
    {
        if (schethelp==1)
        {
            image1.SetActive(true);
            text1.SetActive(true);
            image2.SetActive(false);
            text2.SetActive(false);
            image3.SetActive(false);
            text3.SetActive(false);
            image4.SetActive(false);
            text4.SetActive(false);
        }
        if (schethelp==2)
        {
            image2.SetActive(true);
            text2.SetActive(true);
            image1.SetActive(false);
            text1.SetActive(false);
            image3.SetActive(false);
            text3.SetActive(false);
            image4.SetActive(false);
            text4.SetActive(false);
        }
        if (schethelp==3)
        {
            image3.SetActive(true);
            text3.SetActive(true);
            image2.SetActive(false);
            text2.SetActive(false);
            image1.SetActive(false);
            text1.SetActive(false);
            image4.SetActive(false);
            text4.SetActive(false);
        }
        if (schethelp==4)
        {
            image4.SetActive(true);
            text4.SetActive(true);
            image2.SetActive(false);
            text2.SetActive(false);
            image3.SetActive(false);
            text3.SetActive(false);
            image1.SetActive(false);
            text1.SetActive(false);
        }
    }
    public void Next()
    {
        schethelp++;
        if (schethelp>4)
        {
            schethelp=4;
        }
    }
    public void Undo()
    {
        schethelp--;
        if (schethelp<1)
        {
            schethelp=1;
        }
    }
}
