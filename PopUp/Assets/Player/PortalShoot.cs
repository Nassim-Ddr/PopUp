using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalShoot : MonoBehaviour
{
    public Transform ShootPoint;
    public GameObject PortalInBullet;
    public GameObject PortalOutBullet;


    void Update()
    {
        if(Input.GetButtonDown("PortalInShoot")) PortalInShoot();
        else if (Input.GetButtonDown("PortalOutShoot")) PortalOutShoot(); //Used else to prevent shooting both portals at the same time
    }

    void PortalInShoot()
    {
        Instantiate(PortalInBullet, ShootPoint.position, ShootPoint.rotation);
    }

    void PortalOutShoot() 
    {
        Instantiate(PortalOutBullet, ShootPoint.position, ShootPoint.rotation);
    }
}
