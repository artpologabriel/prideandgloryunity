using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class MapObstacles : MonoBehaviour
{
   
   
    public GameObject Cam;
    float CamXpos;
    float CamZpos;
    // must be query where the camera is located

    void Awake(){
        StartCoroutine(MapDragged());
    }



    IEnumerator MapDragged(){
        yield return new WaitForSeconds(1f);
        CheckObjs();
        yield return new WaitForSeconds(1f);
        StartCoroutine(MapDragged());
    }

    void CheckObjs(){

        float xPos = Cam.transform.position.x;
        float zPos = Cam.transform.position.z;

        if(xPos == CamXpos || zPos == CamZpos){
            return;           
        } else {
            CamXpos = xPos;
            CamZpos = zPos;
        }



        string route = "route:mapobstaclehere";
        string action = ",action:LoadObstacles";
        string id = ",xpos:"+ Mathf.Round(xPos)  +",zpos:"+ Mathf.Round(zPos); //or query
        string receiverObj = ",receiverObj:"+ gameObject.name;

        string data = route + action + id;
        Debug.Log(data);
        
        //gameObject.SendMessage("PostDataToServer", data);
        
    }


    void LoadObstacles(string data){
        var N = JSON.Parse(data); 
        string action = N["action"].Value;
        Debug.Log(data);
    }

}
