using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalShoot : MonoBehaviour
{
    public Transform ShootPoint;
    public Transform HandlePoint;
    public GameObject PortalInBullet;
    public GameObject PortalOutBullet;
    public GameObject PortalIn;
    public GameObject PortalOut;

    private CharacterController2D CC2D;
    private GameObject OldPortal;
    private bool InputIn, InputOut;//Used to avoid calling Input.GetButton too many times .
    private bool Handling;
    private float OldVelX, OldVelY;//Wanted to use vars in order to avoid rewriting the code if i tweak the the run and jump speed .

    void Start()
    {
        CC2D = gameObject.GetComponent<CharacterController2D>();
        OldVelX = CC2D.RunVelocity;
        OldVelY = CC2D.JumpVelocity;
    }

    void Update()
    {
        InputIn = Input.GetButtonDown("PortalInShoot");
        InputOut = Input.GetButtonDown("PortalOutShoot");

        //Track mouse positions
        Vector3 Diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float RotZ = Mathf.Atan2(Diff.y, Diff.x) * Mathf.Rad2Deg;
        ShootPoint.rotation = Quaternion.Euler(0f, 0f, RotZ);

        if (!Input.GetButton("Handle"))
        {
            if (InputIn) PortalInShoot(false);
            else if (InputOut) PortalOutShoot(false); //Used else to prevent shooting both portals at the same time
        }
        else 
        {
            if (InputIn && !Handling) HandlePortalIn();
            else if (InputOut && !Handling) HandlePortalOut();
            CC2D.RunVelocity = CC2D.JumpVelocity = 0;
            CC2D.Handling = true;
        }

        if (Input.GetButtonUp("Handle"))
        {
            Handling = false;
            if (OldPortal != null) Destroy(OldPortal, 0);
            CC2D.RunVelocity = OldVelX;
            CC2D.JumpVelocity = OldVelY;
            CC2D.Handling = false;
        }

    }

    void PortalInShoot(bool BHandle)
    {
        //BULLETONEFFECT
        Instantiate(PortalInBullet, ShootPoint.position, ShootPoint.rotation);
    }

    void PortalOutShoot(bool BHandle)
    {
        //BULLETONEFFECT
        Instantiate(PortalOutBullet, ShootPoint.position, ShootPoint.rotation);
    }

    void HandlePortalIn()
    {
        OldPortal = GameObject.Find("PortalIn(Clone)");
        if (OldPortal != null) Destroy(OldPortal, 0);
        OldPortal = Instantiate(PortalIn, HandlePoint.position, ShootPoint.rotation, HandlePoint);
        Handling = true;
    }   

    void HandlePortalOut()
    {
        OldPortal = GameObject.Find("PortalOut(Clone)");
        if (OldPortal != null) Destroy(OldPortal, 0);
        OldPortal = Instantiate(PortalOut, HandlePoint.position, ShootPoint.rotation, HandlePoint);
        Handling = true;
    }
}