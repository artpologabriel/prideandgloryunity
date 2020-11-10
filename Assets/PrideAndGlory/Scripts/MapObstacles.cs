using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class MapObstacles : MonoBehaviour
{
   
   
    public GameObject Cam;
    float CamXpos;
    float CamZpos;
    public float height;
    // must be query where the camera is located
    public GameObject[] obstacles;

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
        string query = ",xpos:"+ Mathf.Round(xPos)  +",zpos:"+ Mathf.Round(zPos); //or query
        string receiverObj = ",receiverObj:"+ gameObject.name;

        string data = route + action + receiverObj + query;
       // Debug.Log(data);
        
        gameObject.SendMessage("PostDataToServer", data);
        
    }


    void LoadObstacles(string data){
        var N = JSON.Parse(data);         
      //  Debug.Log(data);        
        

        for(int i=0; i < 20; i++){
            string objName = N[i]["_id"].Value;
            string objecttype = N[i]["objecttype"].Value;
            float xpos = N[i]["x"].AsFloat;
            float zpos = N[i]["z"].AsFloat;

            if(objecttype != ""){
                //Debug.Log(objecttype);
                LoadObs(objecttype, xpos, zpos, objName);
            }
            
        }

        
    }

    void LoadObs(string objecttype, float x, float y, string objName){

        GameObject objIsAlreadyInGame = GameObject.Find(objName);
        if(objIsAlreadyInGame != null){
            return;
        }

        objecttype = "Obstacle";

        for(int i = 0; i < obstacles.Length; i++){
            if(obstacles[i].name == objecttype){
                GameObject obj = Instantiate(obstacles[i]) as GameObject;
                obj.transform.position = new Vector3(x, height, y);
                obj.name = objName;
                obj.transform.parent = transform;
                obj.transform.localScale = new Vector3(0.01f,0.01f,0.01f);
            }
        }
    }

}
