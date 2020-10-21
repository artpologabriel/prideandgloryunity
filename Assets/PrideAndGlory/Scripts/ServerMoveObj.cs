using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class ServerMoveObj : MonoBehaviour
{
    
    
    void moveObject(string data){        
        var N = JSON.Parse(data);
        var xPos = N["xPos"].Value;
        var yPos = N["yPos"].Value;
        var zPos = N["xPos"].Value;
        float xP = float.Parse(xPos);
        float yP = float.Parse(yPos);
        float zP = float.Parse(zPos);
        transform.TransformPoint(Vector3.zero);
        gameObject.transform.position = new Vector3(xP, yP, zP);        
        Debug.Log("ServerMove" + xP);
    }

    
}
