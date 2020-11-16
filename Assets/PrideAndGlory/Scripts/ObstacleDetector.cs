using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other)
    {                
        Debug.Log("Object Detected");
        if(other.name != "Map"){
            Destroy (other.gameObject);
        }
        
    }

    //When the Primitive exits the collision, it will change Color
    void OnTriggerExit(Collider other)
    {
        
    }
}
