using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class View
{
    public int Next,Previous;
    public bool Swap;
    public Transform ViewPosition;
}

public class CameraManager : MonoBehaviour
{
    public View[] Views;
    public Camera Cam;
    private View CurrentView;
    
    void Start() 
    {
        CurrentView = Views[0];    
    }
    void OnTriggerExit2D(Collider2D ExitInfo)
    {
        if (ExitInfo.tag == "Player")
        {
            if (!CurrentView.Swap)
                if (ExitInfo.transform.position.x > CurrentView.ViewPosition.position.x) CurrentView = Views[CurrentView.Next];
                else CurrentView = Views[CurrentView.Previous];
            else 
                if (ExitInfo.transform.position.x < CurrentView.ViewPosition.position.x) CurrentView = Views[CurrentView.Next];
                else CurrentView = Views[CurrentView.Previous];
            Cam.transform.position = CurrentView.ViewPosition.position;
        }
    }
}
