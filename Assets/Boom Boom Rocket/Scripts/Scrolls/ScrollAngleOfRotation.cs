using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollAngleOfRotation : MonoBehaviour
{
    public Scrollbar scrollbar;

    public Text angleOfRotation;

    private void Update()
    {
        PlayerPrefs.SetFloat("AngleOfRotation1", scrollbar.value * 9 + 1);
        angleOfRotation.text = PlayerPrefs.GetFloat("AngleOfRotation1").ToString();
    }
}
