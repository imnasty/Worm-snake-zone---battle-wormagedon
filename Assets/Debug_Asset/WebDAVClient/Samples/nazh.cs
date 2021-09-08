using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nazh : MonoBehaviour
{
    public KeyCode ShotKey = KeyCode.Space;
    public Resolution[] Resolutions;
    public ScreenshotHandler Screen;
    public WebDavSTA sta;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        //ScreenshotHandler.instance.wwwww();
    }

    // Update is called once per frame
   private void Update()
    {
        if (Input.GetKeyDown(ShotKey))
        {
           canvas.SetActive(!canvas.activeSelf);
        }
    }
}
