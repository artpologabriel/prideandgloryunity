using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class NetworkController : MonoBehaviour
{
    
    public GameObject Main;
    public  GameObject NetworkControllerPort ;
    public Text datafromSocket;
    
    
    public void SendDataToSocket (string data){
        NetworkControllerPort.SendMessage("SendDataToSocket", data);
        Debug.Log("SendDataToSocket");
    }

    public void SocketData(string data){
        datafromSocket.text = data;
       // Debug.Log("SocketData Recieved");
        ProcessData(data);
    }


    void ProcessData(string data){
        //var d = JsonMaker(data); 
        var N = JSON.Parse(data);
        var action = N["action"].Value;
        var receiverObj = N["receiverObj"].Value;
        Debug.Log("receiverObj:"+ receiverObj);
        /*
        if(action == "pong"){        
            Main.SendMessage("InitFromServer");
        }    

        if(action == "addBuilding"){
            GameObject AddObj = GameObject.FindWithTag("AddObjectController");
            AddObj.SendMessage("addBuilding", data);
        }

        if(action == "moveObject"){
            string objectName = N["objectName"].Value;
            GameObject Obj = GameObject.Find(objectName);
            Obj.SendMessage("moveObject", data);
        }

        if(action == "gotoObject"){
            string objectName = N["objectName"].Value;
            GameObject Obj = GameObject.Find(objectName);
            Obj.SendMessage("gotoObject", data);
        }
        */
        
        GameObject Obj = GameObject.Find(receiverObj);
        Obj.SendMessage(action, data);
        

        Debug.Log(action);
        Debug.Log(data);
        
    }

    public string JsonMaker(string data){        
        string JsonOutput = "";
        string[] pairs = data.Split(',');                
        for(int i = 0 ; i < pairs.Length; i++){
            string[] d = pairs[i].Split(':');
            string key = d[0];
            string value = d[1];
            
            if(pairs.Length - 1 != i){
                JsonOutput += "\""+key+"\" : \""+value+"\""+ ",";
            }else{
                JsonOutput += "\""+key+"\" : \""+value+"\"";
            }
        }
        return "{"+JsonOutput+"}";
        //Debug.Log(JsonOutput);
    }    



}
