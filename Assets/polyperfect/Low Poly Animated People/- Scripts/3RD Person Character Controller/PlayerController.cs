﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed, runSpeed, rotateSpeed, jumpForce, walkAnimationSpeed, runAnimatonSpeed;

    public Animator animator;
    public new Rigidbody rigidbody;

    Vector3 offset;

    public float distToGround;

    public bool isGrounded; 
    public bool dead = false;

    public new CinemachineFreeLook camera;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        distToGround = GetComponent<Collider>().bounds.extents.y;

    }

    // Update is called once per frame
    void Update()
    { 
        if (!dead)
        {
        isGrounded = Grounded();

        //Allow the player to move left and right
        float horizontal = Input.GetAxisRaw("Horizontal");

        //Allow the player to move forward and back
        float vertical = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        float speed = walkSpeed;
        float animSpeed = walkAnimationSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            vertical *= 2f;
            speed = runSpeed;
            animSpeed = runAnimatonSpeed;
        }

        var translation = transform.forward * (Mathf.Abs(vertical) * Time.deltaTime);
        translation += transform.forward * (Mathf.Abs(horizontal) * Time.deltaTime);
        if(vertical != 0 && horizontal != 0)
        {
            
            translation = translation * speed * .5f;

        }
        else
        {
            translation *= speed;
        }

        
        translation = rigidbody.position + translation;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        { 
            animator.SetBool("Jump", true);
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        } 
        else 
        { 
            animator.SetBool("Jump", false);
        }

        animator.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);
        animator.SetFloat("Horizontal", vertical, 0.1f, Time.deltaTime);

        animator.SetFloat("WalkSpeed", animSpeed);

       
        if (direction.magnitude >= .01f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.m_XAxis.Value;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            if (!Input.GetKey(KeyCode.LeftAlt))
            {
                rigidbody.MoveRotation(Quaternion.Euler(0, angle, 0));
            }
            
            rigidbody.MovePosition(translation);
            
        }

        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        } 

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        { 
            animator.SetBool("IsAttacking", true);
        } 
        else 
        { 
            animator.SetBool("IsAttacking", false);
        } 

        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {    
            dead = true;
            animator.SetTrigger("IsDead");
        } 
        }
    } 

    bool Grounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround, 9);
    }


}
