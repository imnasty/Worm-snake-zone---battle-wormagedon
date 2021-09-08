using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRotationSpeed : MonoBehaviour
{
    public Scrollbar scrollbar;

    public Text rotationSpeed;

    private void Update()
    {
        PlayerPrefs.SetFloat("RotationSpeed1", scrollbar.value * 9 + 1);
        rotationSpeed.text = PlayerPrefs.GetFloat("RotationSpeed1").ToString();
    }
}
