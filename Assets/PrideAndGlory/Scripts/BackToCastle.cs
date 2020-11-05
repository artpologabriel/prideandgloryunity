using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToCastle : MonoBehaviour
{
    
    public bool Move = false;
    public float speedNormal = 2f;
    public float speedQuick = 2f;
    float speed;
    public GameObject targetGameObj;
    public GameObject CanvasDistance;
    public GameObject CastleRenderer;
    public bool Quick = false;

    void Start()
    {
        string InitCredential = Main.InitCredential;
        Debug.Log(InitCredential);

    }


    public void GoBack(){
        Move = true;
    }

    public void GoBackQuick(){
        Quick = true;
        Debug.Log("GoBackQuick");
    }

    void OnMouseDown(){
        Move = false;
    }

    public void ShowCanvasDistance(){
        CanvasDistance.SetActive(true);
    }
    
    public void HideCanvasDistance(){
        CanvasDistance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {        
        if(Move){
            if(Quick){
                speed = speedQuick;
            }else{
                speed = speedNormal;
            }
            float step =  speed; // * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetGameObj.transform.position, step);
        }

        if (Input.GetMouseButtonDown (0)) {
            Move = false;
            Quick = false;
        }

    }
}
