using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTools : MonoBehaviour
{
    public Animator animator;

    private bool isShow = false;

    public void ShowHidePanel()
    {
        isShow = !isShow;

        animator.SetBool("hide",isShow);
    }
}
