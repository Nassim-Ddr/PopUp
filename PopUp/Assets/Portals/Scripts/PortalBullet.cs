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
    private Quaternion Rotation;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.velocity = transform.right * Velocity;
    }

    void OnTriggerEnter2D(Collider2D HitInfo)
    {
        Rotation = Quaternion.Euler(0f, 0f, HitInfo.transform.rotation.eulerAngles.z - 90); //Adjust portal rotation depending on the support that the bullet is landing on
        if (HitInfo.tag != "Player" && HitInfo.tag != "Portal")
        {
            if (In)
            Instantiate(PortalIn, transform.position, Rotation, gameObject.transform.parent.transform);
            else Instantiate(PortalOut, transform.position, Rotation, gameObject.transform.parent.transform);
            Destroy(gameObject, 0);
            //BULLETOFFEFFECT OR PORTALONEFFECT
        }
    }
}
