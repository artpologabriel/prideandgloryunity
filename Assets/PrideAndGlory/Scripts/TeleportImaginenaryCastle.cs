using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportImaginenaryCastle : MonoBehaviour
{
    

    
    public GameObject targetGameObj;
    public bool Move =false;
    public float speed = 1f;

    public GameObject MyParent;

    public GameObject ConfirmMenu3DObj;

    public GameObject tiles;
    public GameObject MapTileOptions;

    public float height = 1f;

    // Update is called once per frame
    void Update()
    {
        
            float step =  speed * Time.deltaTime; // calculate distance to move
            tiles.transform.position = Vector3.MoveTowards(transform.position, tiles.transform.position, step); 
            MapTileOptions.transform.position = Vector3.MoveTowards(transform.position, MapTileOptions.transform.position, step);                            
    }

    public void TeleportNow(){
      //  GameObject tile = GameObject.Find("Tile");
      //  targetGameObj = tile;
      //  Move  = true;
      //  StartCoroutine(UnMove());
    }

    IEnumerator UnMove(){
        yield return new WaitForSeconds(1f);
        Move = false;
    }

    void OnMouseUp(){
        ConfirmMenu3DObj.SetActive(true);
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
       //                
    }

    void Teleported(){
        transform.position =  MyParent.transform.position;  
    }

    void OnMouseDrag(){

       //tiles.transform.position = transform.position;
        //tiles.SendMessage("FollowObjectNow", gameObject.name);
    }


}
