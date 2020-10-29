using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class Teleport : MonoBehaviour
{
    public GameObject targetGameObj;
    public bool Move =false;
    public float speed = 1f;
    public float yP = .5f;
    public Text MapPositionText;

    // Update is called once per frame
    void Update()
    {
        if(Move){
            float step =  speed; //* Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetGameObj.transform.position, step);
           // Debug.Log("Teleporting"+ transform.position);
        }        
    }

    public void TeleportNow(){
        GameObject tile = GameObject.Find("Imaginary_CastleHolder");
        targetGameObj = tile;
        Move  = true;
        StartCoroutine(UnMove());        
    }

    IEnumerator UnMove(){
        yield return new WaitForSeconds(1f);
        Move = false;
        SaveNewPosition();
    }

    public void MapPosition(string data){        
        var N = JSON.Parse(data);
        Debug.Log(N);     
        string xPos = N["data"]["map_position"][0]["x_pos"].Value; 
        string zPos = N["data"]["map_position"][0]["z_pos"].Value; 
        Debug.Log("xzpos" + xPos + zPos);
        
        if(xPos == "null"){
            xPos = "1";
        }
        
        float xP = float.Parse(xPos);
        float zP = float.Parse(zPos); 
        transform.position = new Vector3(xP, yP, zP);
        
        Debug.Log("MapPosition");

        GameObject Cam = GameObject.FindWithTag("ActiveCamera");
        Cam.SendMessage("GoBack");
        MapPositionText.text = "x:"+xPos+"  : y:"+zPos;
    }

    void SaveNewPosition(){
        float xP = Mathf.Round(transform.position.x);
        float zP = Mathf.Round(transform.position.z);
        GameObject M = GameObject.FindWithTag("Main");
        string castleName = "castle-"+Main.InitCredential; //this is for the other players view
        //SOCKET
        string data = "action:MapLocation,id:"+Main.InitCredential+",receiverObj:"+castleName+", x_pos:"+xP + ",z_pos:"+zP;
        M.SendMessage("SendDataToSocket", data);
        
        //HTTPCALL
        string postData = "route:teleport,action:MapLocation,u_id:"+Main.InitCredential+",receiverObj:"+castleName+", x_pos:"+xP + ",z_pos:"+zP;
        gameObject.SendMessage("Post", postData);
    }




}
