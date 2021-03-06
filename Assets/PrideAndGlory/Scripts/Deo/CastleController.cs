﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System.IO;
using System;


public class CastleController : MonoBehaviour
{
    // Start is called before the first frame update
      public GameObject Castle;
      public int lvl;
  
    [SerializeField]
    private Material[] materials;
    private MeshRenderer renderer;
    public string myID;

    //playerReference

    public static string InitCredential;    

        public bool completed = false;

      void SetId(string Id){
        myID = Id;
        StartCoroutine(DisableMe());
      }

    IEnumerator DisableMe(){
      yield return new WaitForSeconds(1f);
      gameObject.SetActive(false);
    }  

    void Enable(){
        // Debug.Log("Enabled " + gameObject.name);
        CheckName();
    }


    void CheckName(){
          //Debug.Log("CheckName: " + id);
          //yield return new WaitForSeconds(2f);
          string v = gameObject.name;          
          string[] na =   v.Split('-');
          string id = na[1];
          string route = "castleinfo";
          string data = route + "-" + "SetLevel"+"-"+id;
          gameObject.SendMessage("GetData", data);
    }

      public void SetLevel(string JsonData)
      {
            Debug.Log(JsonData);
            var N = JSON.Parse(JsonData);
            var c_name =N[0]["level"].Value;
            var c_level = N[0]["level"].Value;
            var c_id = N[0]["_id"].Value;
            Level(Int32.Parse(c_level));


      }

      public void  Level(int level) 
      {     
        int levlCastle =  level-1;
        renderer = Castle.GetComponent<MeshRenderer>();
        renderer.GetComponent<MeshRenderer>().material = materials[levlCastle];
        // Instantiate(Castle,pos,Quaternion.identity);
      }

   

   

    
}
