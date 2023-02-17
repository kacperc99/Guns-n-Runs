using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;

    public Rigidbody2D rb;

    public Animator animator;

    public static Vector3 playerPos;
    public static bool IsRunning;

    Vector2 _movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    void Update()
    {
        playerPos = transform.position;
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");


        if(_movement.x != 0f || _movement.y != 0f)
        {
            IsRunning = true;

        }
        else
        {
            IsRunning = false;
        }

        animator.SetFloat("Horizontal", _movement.x);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement.normalized * moveSpeed * Time.fixedDeltaTime);

    }

}
