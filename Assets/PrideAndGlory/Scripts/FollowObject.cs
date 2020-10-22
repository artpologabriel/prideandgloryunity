﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    
    public bool follow =false; 
    public float speed = 1f;
    
    public GameObject targetGameObj;
    // Start is called before the first frame update
    void FollowObjectNow(string ObjName){
        GameObject Obj =GameObject.Find("CamStartPoint");
        targetGameObj = Obj; 
        follow = true;
        StartCoroutine(StopFollow());
    }

    IEnumerator StopFollow(){
        yield return new WaitForSeconds(2f);
        follow = false;
    }

    void Update()
    {
        if(follow){
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetGameObj.transform.position, step);
        }
    }
}