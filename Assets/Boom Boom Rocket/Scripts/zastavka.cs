using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zastavka : MonoBehaviour
{
    public Animator rocketka;
    // start is called before the first frame update
    void Start()
    {
        rocketka.StopPlayback();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
