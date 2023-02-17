using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimControl : MonoBehaviour
{

    public Camera cam;

    public static float angle;
    public static Vector3 lookDir;
    public static bool IsFacingRight;

    private Vector3 mousePos;

    private float maxRightAngleUp = 30f;
    private float maxRightAngleDown = -30f;

    private float maxLeftAngleUp = 150f;
    private float maxLeftAngleDown = -150f;

    private void Start()
    {
        /*
        float maxRightAngleDown = -maxRightAngleUp;
        float maxLeftAngleDown = -maxLeftAngleUp;
        */
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
        
    private void FixedUpdate()
    {
        lookDir = (mousePos - transform.position).normalized;
       
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if(angle > maxRightAngleDown && angle < maxRightAngleUp)
        {

            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            if(IsFacingRight == false)
            {
                IsFacingRight = true;
            }
        }
    
        else if(angle > maxLeftAngleUp || angle < maxLeftAngleDown )
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            if (IsFacingRight == true)
            {
                IsFacingRight = false;
            }
        }


    }
}
