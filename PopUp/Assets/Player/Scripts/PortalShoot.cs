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
        Vector3 Diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float RotZ = Mathf.Atan2(Diff.y, Diff.x) * Mathf.Rad2Deg;
        ShootPoint.rotation = Quaternion.Euler(0f, 0f, RotZ);


        if(Input.GetButtonDown("PortalInShoot")) PortalInShoot();
        else if (Input.GetButtonDown("PortalOutShoot")) PortalOutShoot(); //Used else to prevent shooting both portals at the same time
    }

    void PortalInShoot()
    {
        //BULLETONEFFECT
        Instantiate(PortalInBullet, ShootPoint.position, ShootPoint.rotation);
    }

    void PortalOutShoot() 
    {
        //BULLETONEFFECT
        Instantiate(PortalOutBullet, ShootPoint.position, ShootPoint.rotation);
    }
}
