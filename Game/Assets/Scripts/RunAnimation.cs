using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimation : MonoBehaviour
{

    public Animator animatorBody;
    public Animator animatorArm;


    void Awake()
    {
        animatorBody = GetComponent<Animator>();
        animatorArm = GetComponent<Animator>();
    }


    void Update()
    {
        if (AimControl.IsFacingRight)
        {
            animatorBody.SetBool("IsFacingRight", true);
            animatorArm.SetBool("IsFacingRight", true);
        }
        else
        {
            animatorBody.SetBool("IsFacingRight", false);
            animatorArm.SetBool("IsFacingRight", false);
        }
        if (PlayerMovement.IsRunning)
        {
            animatorBody.SetBool("IsRunning", true);
            

        }
        else
        {
            animatorBody.SetBool("IsRunning", false);
            
        }

    }
}
