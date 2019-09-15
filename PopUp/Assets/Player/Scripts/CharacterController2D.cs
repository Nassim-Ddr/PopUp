﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float RunVelocity = 10f;
    [Range(0, .3f)] public float MovementSmoothing = .05f;
    public float JumpVelocity = 10f;
    public LayerMask WhatIsGround;
    public Transform GroundCheck;
    private Animator Anim;
    private Rigidbody2D Rb;

    private float HorizontalMovement;
    private bool VerticalMovement;
    private bool FacingRight = true;
    private bool Grounded;
    private Vector3 ReferenceVelocity = Vector3.zero;

    private void Awake() 
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void Update() 
    {
        HorizontalMovement = Input.GetAxisRaw("Horizontal") *RunVelocity;
        VerticalMovement = Input.GetButton("Jump");
    }
    
    void FixedUpdate ()
    {   
        //Ground Check
        Grounded = Physics2D.OverlapCircle(GroundCheck.position,0.2f, WhatIsGround);
    
         //Horizontal Movement
        // //RUNANIMATION
        Vector3 TargetVelocity = new Vector2(HorizontalMovement, Rb.velocity.y);
        Rb.velocity = Vector3.SmoothDamp(Rb.velocity, TargetVelocity, ref ReferenceVelocity, MovementSmoothing);
            
        //Flip : We use rotate to also rotate the shootpoint (case of a shooting game) you can also use the SpriteRendrer.flix.y=true;
        if (HorizontalMovement > 0 && !FacingRight)
        {
            Flip();
        }
        else if (HorizontalMovement < 0 && FacingRight)
        {
            Flip();
        }

        //Vertical Movement
        if (Grounded && VerticalMovement)
        {
            // //JUMPANIMATION
            Grounded = false;
            Rb.velocity += Vector2.up * JumpVelocity;
        }
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}