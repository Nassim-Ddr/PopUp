using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public bool In;
    
    private Transform Destination;
    private Rigidbody2D Rb;
    private GameObject V; //used to not repeat the 18 line

    void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.tag != "Environment" && HitInfo.tag != "Portal" && HitInfo.tag != "NotTpable") 
        {
            if (Vector3.Distance(HitInfo.transform.position, transform.position) > 0.5f)
            {
                if (In) V = GameObject.Find("PortalOut(Clone)");
                else V = GameObject.Find("PortalIn(Clone)");

                if (V != null)
                {
                    if (In) Destination = V.transform;
                    else Destination = V.transform;
                    HitInfo.transform.position = Destination.position;
                    Rb = HitInfo.GetComponent<Rigidbody2D>();
                    // Simulate inertia
                    if (Rb != null) Rb.velocity = Destination.right * Rb.velocity.magnitude * .9f;
                }
            }
        }
    }
}
