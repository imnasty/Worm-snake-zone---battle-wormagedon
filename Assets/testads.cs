using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testads : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void otkl()
    {
        PlayerPrefs.SetInt("removeads",1);
    }
    public void otkl1()
    {
        PlayerPrefs.SetInt("removeads",0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
