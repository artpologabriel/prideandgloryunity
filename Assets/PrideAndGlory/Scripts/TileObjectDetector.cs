using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObjectDetector : MonoBehaviour
{
    
    public GameObject MyParent;
    public Texture2D texture1;
    public Texture2D texture2;

    public GameObject tileObjThing;

    //When the Primitive collides with the walls, it will reverse direction
    void OnTriggerEnter(Collider other)
    {                
        MyParent.gameObject.GetComponent<Renderer>().material.mainTexture = texture2;
        tileObjThing.SetActive(false);
    }

    //When the Primitive exits the collision, it will change Color
    void OnTriggerExit(Collider other)
    {
        MyParent.gameObject.GetComponent<Renderer>().material.mainTexture = texture1; 
        tileObjThing.SetActive(true);
    }

}
