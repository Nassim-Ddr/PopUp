using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalShoot : MonoBehaviour
{
    public Transform ShootPoint;

    void Update()
    {
        if(Input.GetButtonDown("Shoot"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

    }
}
