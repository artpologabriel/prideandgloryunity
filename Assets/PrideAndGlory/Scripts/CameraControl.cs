using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    
    public Camera[] Cam;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
        SelectCam("MainCamera");
    }

    void SelectCam(string camName){
        

        for(int i = 0; i < Cam.Length; i++){
            if(camName == Cam[i].name){
                Cam[i].enabled = true;
                Debug.Log(Cam[i]); 
            }else{
                Cam[i].enabled = false;
            }
        }

    }
}
