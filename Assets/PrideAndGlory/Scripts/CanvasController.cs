using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{


    public GameObject[] MapCanvas;
    

    
    public void OnWhichMap(string Map){

        for(int i = 0; i <  MapCanvas.Length; i++){
            if(MapCanvas[i].name == Map){
                MapCanvas[i].SetActive(true);
            }else
            {
                MapCanvas[i].SetActive(false);
            }
        }

    }    


}
