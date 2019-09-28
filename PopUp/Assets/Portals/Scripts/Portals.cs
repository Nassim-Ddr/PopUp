using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public bool In;
    private Transform Destination;

    private Rigidbody2D Rb;

    void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.tag != "Environment" && HitInfo.tag != "Portal") 
        {
            if (Vector3.Distance(HitInfo.transform.position, transform.position) > 0.5f)
            {
                if (In) Destination = GameObject.Find("PortalOut(Clone)").transform;
                else Destination = GameObject.Find("PortalIn(Clone)").transform;

                if (Destination != null)
                {
                    HitInfo.transform.position = Destination.position;
                    Rb = HitInfo.GetComponent<Rigidbody2D>();
                    // Simulate inertia
                    if (Rb != null)
                    {
                        if (transform.rotation != Destination.transform.rotation) //One one wall one on the ground
                        {
                            if (Destination.position.x > transform.position.x) Rb.velocity = new Vector2(Rb.velocity.y * 2, -10);
                            else Rb.velocity = new Vector2(-Rb.velocity.y * 2, -10);
                        }
                        else if (transform.rotation.z != 0) //Both on ground
                        {
                            if (Mathf.Abs(Destination.position.x - transform.position.x) < 1) Rb.velocity = new Vector2(Rb.velocity.x, Rb.velocity.y * 0.7f);//Portal above an other. (velocity.y limit)
                            else Rb.velocity = new Vector2(Rb.velocity.x, -Rb.velocity.y);
                        }
                        //else the velocity doesn t change //Both on wall
                    }
                }
            }
        }
    }
}
