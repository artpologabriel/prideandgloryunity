using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToCastle : MonoBehaviour
{
    
    public bool Move = false;
    public float speed = 2f;
    public GameObject targetGameObj;
    public GameObject CanvasDistance;
    public GameObject CastleRenderer;
    
    public void GoBack(){
        Move = true;
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
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetGameObj.transform.position, step);
        }

        if (Input.GetMouseButtonDown (0)) {
            Move = false;
        }

    }
}
