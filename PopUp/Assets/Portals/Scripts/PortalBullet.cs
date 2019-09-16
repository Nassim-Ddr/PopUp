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
    private GameObject OldPortal;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.velocity = transform.right * Velocity;
    }

    void OnTriggerEnter2D(Collider2D HitInfo) //Notice : to make all game mecanics works i had to spawn the new portel then delete the old one .
    {
        if (HitInfo.tag == "Portal") Destroy(gameObject, 0); // can't create a portal on top of another .
        else if (HitInfo.tag == "Environment")
        {
            Rotation = Quaternion.Euler(0f, 0f, HitInfo.transform.rotation.eulerAngles.z - 90); //Adjust portal rotation depending on the support that the bullet is landing on
            FindOld(In);
            if (In) Instantiate(PortalIn, transform.position, Rotation);
            else Instantiate(PortalOut, transform.position, Rotation);        
            if (OldPortal != null) Destroy(OldPortal, 0);
            Destroy(gameObject, 0);
            //BULLETOFFEFFECT OR PORTALONEFFECT
        }
    }

    void FindOld(bool PIn)
    {
        if (PIn)
        {
            OldPortal = GameObject.Find("PortalIn(Clone)");
        }
        else
        {
            OldPortal = GameObject.Find("PortalOut(Clone)");
        }
    }
}
