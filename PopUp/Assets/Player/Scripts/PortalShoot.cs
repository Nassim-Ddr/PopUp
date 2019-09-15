using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalShoot : MonoBehaviour
{
    public Transform ShootPoint;
    public GameObject PortalInBullet;
    public GameObject PortalOutBullet;
    public PortalController PC;

    private Transform Parent;
    

    void Start()
    {
        Parent = GameObject.Find("PortalController").transform;
    }

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
        PC.PortalCheck(true);
        Instantiate(PortalInBullet, ShootPoint.position, ShootPoint.rotation,Parent);
    }

    void PortalOutShoot() 
    {
        //BULLETONEFFECT
        PC.PortalCheck(false);
        Instantiate(PortalOutBullet, ShootPoint.position, ShootPoint.rotation,Parent);
    }
}
