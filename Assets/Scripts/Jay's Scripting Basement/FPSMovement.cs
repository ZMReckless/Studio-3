using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpSpeed;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Animator animator;

    Vector3 velocity;
    bool isGrounded;
    bool isIdle;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 ||
            z != 0)
        {
            isIdle = false;
        }
        else
        {
            isIdle = true;
        }

        animator.SetBool("isIdle", isIdle);

        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", z);

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpSpeed;
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);



        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (isGrounded)
        //    {
        //        _airTime -= 1 * Time.deltaTime;
        //        while (_airTime > 0)
        //        {
        //            velocity.y -= gravity * Time.deltaTime;
        //            if (_airTime <= 0)
        //            {
        //                break;
        //            }
        //        }
        //    }
        //}
    }

    //void jump()
    //{
    //    _airTime -= 1 * Time.deltaTime;
    //    while (_airTime > 0)
    //    {
    //        velocity.y -= gravity * Time.deltaTime;
    //        if (_airTime <= 0)
    //        {
    //            break;
    //        }
    //    }

    //}
}
