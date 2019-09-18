﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public bool In;
    private Transform Destination;

    private Rigidbody2D Rb;

    void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (Vector3.Distance(HitInfo.transform.position, transform.position) > 0.5f)
        {
            if (In) Destination = GameObject.Find("PortalOut(Clone)").GetComponent<Transform>();
            else Destination = GameObject.Find("PortalIn(Clone)").GetComponent<Transform>();
            if (Destination != null)
            {
                HitInfo.transform.position = Destination.position;
                if (transform.rotation != Destination.transform.rotation) // Simulate inertia 
                {
                    Rb = HitInfo.GetComponent<Rigidbody2D>();
                    if (Destination.position.x > transform.position.x) Rb.velocity = new Vector2(Rb.velocity.y, -10);
                    else Rb.velocity = new Vector2(-Rb.velocity.y, -10);
                }
            }
        }
    }
}
