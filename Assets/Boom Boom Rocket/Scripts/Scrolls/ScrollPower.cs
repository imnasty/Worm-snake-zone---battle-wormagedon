using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollPower : MonoBehaviour
{
    public Scrollbar scrollbar;

    public Text power;

    private void Update()
    {
        PlayerPrefs.SetFloat("Power1", scrollbar.value * 9 + 1);
        power.text = PlayerPrefs.GetFloat("Power1", 3).ToString();
    }
}
