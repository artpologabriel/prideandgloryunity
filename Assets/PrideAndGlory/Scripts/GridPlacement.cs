using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlacement : MonoBehaviour
{
    
    float posX;
    float posY;
    float posZ;

    public float height;
    // Update is called once per frame
    void LateUpdate()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;


        transform.position = new Vector3(Mathf.Round(posX),height,Mathf.Round(posZ)) ; 
        
    }
}
