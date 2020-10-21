using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;



public class PlayObject : MonoBehaviour
{
    
    public bool Move = false;
    public float speed = .5f;
    public GameObject targetGameObj;

    void GotHit(){ 
        GameObject TM = GameObject.FindWithTag("TaskManager");
        TM.SendMessage("TaskObj", gameObject.name);
       
    }

    void GoTo(string TargetObjName){
        GameObject targetObj  =GameObject.Find(TargetObjName);
        targetGameObj = targetObj;
        Move = true;

        GameObject M = GameObject.FindWithTag("Main");

        string data = "action:gotoObject,receiverObj:"+gameObject.name+" ,objectName:"+gameObject.name+",targetObject:"+TargetObjName;
        
		M.SendMessage("SendDataToSocket", data);

    }

    void gotoObject(string data){
        var N = JSON.Parse(data);
        var TargetObjectName = N["targetObject"].Value;
        GameObject targetObj  =GameObject.Find(TargetObjectName);
        targetGameObj = targetObj;
        Move = true;
    }

    void Update(){ 

        if(Move){
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetGameObj.transform.position, step);
        }
    }

}
