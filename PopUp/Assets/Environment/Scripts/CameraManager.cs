using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform[] Views;
    public Camera Cam;


    private int i = 0;
    

    void OnTriggerExit2D(Collider2D HitInfo)
    {
        if (HitInfo.name == "Player")
        {
            i = (i + 1) % 2;
            Cam.transform.position = Views[i].position;
        }
    }
}
