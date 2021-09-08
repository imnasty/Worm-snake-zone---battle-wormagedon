using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullupSettings : MonoBehaviour
{
    private Animator animator;
    private bool trigger = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenClosePullup()
    {
        trigger = !trigger;
        animator.SetBool("isOpen", trigger);
    }
}
