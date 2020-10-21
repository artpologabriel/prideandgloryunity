using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class AddObjectController : MonoBehaviour
{
    
    public GameObject Building;
    public GameObject MapTiles;
    
    
    public GameObject CanvasListBuildings;
    
    
    public void OpenAddObjCanvas(){
        CanvasListBuildings.SetActive(true);
    }
    

    public void SetLocation(){
        MapTiles.SetActive(true);
               
    }   

    public void Location(string loc){
        
        
    }




    public void AddObject(){

            string theTime = System.DateTime.Now.ToString("hh"+"mm"+"ss"); 
            string theDate = System.DateTime.Now.ToString("MM"+"dd"+"yyyy"); 

        GameObject M = GameObject.FindWithTag("Main"); 
               
       // GameObject Obj = Instantiate(Building) as GameObject;
        
        string n = Main.InitCredential + "-"+ theDate + theTime;    
        string ObjName = Md5Sum(n);
        string data = "action:addBuilding,who:,InitCredential:"+Main.InitCredential+",buildingType:Castle,buildingName:"+ObjName;
        M.SendMessage("SendDataToSocket",data);
    }



    //Server Add Obj

        void addBuilding(string data){
            var N = JSON.Parse(data);
            var action = N["action"].Value;
            var socketInitCredential = N["InitCredential"].Value;
            var buildingName = N["buildingName"].Value;
            if(socketInitCredential == Main.InitCredential){
                Debug.Log("Its your building no need to re-add");
                //return;
            }
            Debug.Log("Others building");
            GameObject T = GameObject.FindWithTag("ObjParent");
            GameObject Obj = Instantiate(Building) as GameObject;
            Obj.transform.parent = T.transform;
            Obj.name = buildingName;
        }


         private string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }

}
