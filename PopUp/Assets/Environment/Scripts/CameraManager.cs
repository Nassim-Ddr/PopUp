using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform[] Views;
    public Camera Cam;

    private int i,NextView,CurrentView = 0;
    private float min,x;

    void OnTriggerExit2D(Collider2D ExitInfo)
    {
        if (ExitInfo.name == "Player") Cam.transform.position = Views[FindNextView(ExitInfo.transform.position)].position;
    }

    int FindNextView(Vector3 ExitPos)
    {
        min = Vector3.Distance(Views[0].position,ExitPos);
        for(i=1;i<Views.Length;i++)
        {
            //if (CurrentView != i)
            //{
                x = Vector3.Distance(Views[i].position,ExitPos);
                if (min > x)
                {
                    NextView = i;
                    min = x;
                }
            //}
        }
        CurrentView = NextView;
        return NextView;
    }
}
