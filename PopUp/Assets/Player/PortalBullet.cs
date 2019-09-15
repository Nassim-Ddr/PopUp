using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBullet : MonoBehaviour
{
    public bool In;
    public float Velocity;
    public GameObject PortalIn;
    public GameObject PortalOut;

    private Rigidbody2D Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.velocity = transform.right * Velocity;
    }

    void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.tag != "Player")
        {
            if (In)
            Instantiate(PortalIn, transform.position, transform.rotation);
            else Instantiate(PortalOut, transform.position, transform.rotation);
            Destroy(gameObject, 0);
        }
    }
}
