using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleRenderer : MonoBehaviour
{

    public GameObject Cam;
    public bool OnCam = false;
    void OnBecameVisible()
    {        
        Cam.SendMessage("HideCanvasDistance");
        OnCam = true;
    }


    void OnBecameInvisible()
    {
        if(Cam != null){
           Cam.SendMessage("ShowCanvasDistance");
           OnCam = false;
        }
    }
}
