using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBullet : MonoBehaviour
{
    public bool In;
    public float Velocity;
    public GameObject PortalIn;
    public GameObject PortalOut;
    [HideInInspector] public Vector3 MousePosition;
    [HideInInspector] public Vector3 PlayerPosition;
    
    private Rigidbody2D Rb;
    private Animator Anim;
    private Quaternion Rotation;
    private GameObject OldPortal;
    private Camera Cam;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.velocity = transform.right * Velocity;
        Anim = GetComponent<Animator>();
        Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void OnTriggerEnter2D(Collider2D HitInfo) //Notice : to make all game mecanics works i had to spawn the new portel then delete the old one .
    {
        if (HitInfo.tag != "Player" && HitInfo.tag != "NotTpable")
        {
            Anim.enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Rb.velocity = Vector2.zero;
            if (HitInfo.tag != "PortalWall")
            {
                if (HitInfo.tag == "Environment")
                {
                    MousePosition = Cam.ScreenToWorldPoint(MousePosition);
                    //Adjust portal rotation depending on the support that the bullet is landing on
                    if (HitInfo.transform.localEulerAngles.z == 90)
                        if (MousePosition.x < PlayerPosition.x) Rotation = Quaternion.Euler(0,0,0);
                        else Rotation = Quaternion.Euler(0,0,180);
                    else
                        if (MousePosition.y < PlayerPosition.y) Rotation = Quaternion.Euler(0,0,90);
                        else Rotation = Quaternion.Euler(0,0,270);

                    FindOld(In);
                    if (In) Instantiate(PortalIn, transform.position, Rotation);
                    else Instantiate(PortalOut, transform.position, Rotation);
                    if (OldPortal != null) Destroy(OldPortal, 0);
                }
            }
            Destroy(gameObject, .37f);
        }
    }

    void FindOld(bool PIn)
    {
        if (PIn) OldPortal = GameObject.Find("PortalIn(Clone)");
        else OldPortal = GameObject.Find("PortalOut(Clone)");
    }
}