using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System.IO;
using System;

public class D_BuildingSetLevel : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject Castle;
  
   [SerializeField]
    private Material[] materials;
    private MeshRenderer renderer;


void Awake(){
}


      public void BuildingSetLevel(string data)
      {

             string[] n =   data.Split('-');  
        string name = n[0];
        string _id = n[1];
        string level = n[2];
        string u_id = n[3];
                Debug.Log("Building set Level"+name);

           Level(Int32.Parse(level));

      }
        
      public void  Level(int level) 
      {     
        int levlCastle =  level-1;
        renderer = Castle.GetComponent<MeshRenderer>();
        renderer.GetComponent<MeshRenderer>().material = materials[levlCastle];
        // Instantiate(Castle,pos,Quaternion.identity);
      }

}