using System.Collections;
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
      public int x;
       public int y;
        public int z;
    public int lvl ;

    [SerializeField]
    private Material[] materials;
    private MeshRenderer renderer;

    //playerReference
    public static string ServerUrl;
    public string serverURL;
     public static string username;
    public static string email;
    public static string pass;
    public static string token;

    public static string InitCredential;    

        public bool completed = false;


      public void Start(){
      

      }

       void Awake()
        {
            string v = gameObject.name;
            string[] na =   v.Split('-');

            string id = na[1];

        StartCoroutine(GetContentsFromServer(serverURL,id));

                // ServerUrl = serverURL;
                // if(!checkCredential()){                               
                //         } else{
                //             InitCredential = PlayerPrefs.GetString("InitCredential");
                //             Castle.name="castle-"+InitCredential;
                //             Debug.Log(InitCredential);
                //             string url = ServerUrl + "userdata";
                //             StartCoroutine(GetContentsFromServer(url,InitCredential,"ParseJsonData"));
                //       }
        }


      public void SetLevel(string data)
      {
        var N = JSON.Parse(data);
        var mess = N["SetLevel"].Value;

      }

      public void  Level(String level,String id) 
      {     
         Vector3 pos = new Vector3(x,y,z) ;
        int levlCastle =  Int32.Parse(level)-1;
        Castle.transform.position = pos;
        Castle.name="castle-"+id;
        
        renderer = Castle.GetComponent<MeshRenderer>();
        renderer.GetComponent<MeshRenderer>().material = materials[levlCastle];
        // Instantiate(Castle,pos,Quaternion.identity);
      }

    //      bool checkCredential(){
    //     InitCredential = PlayerPrefs.GetString("InitCredential");

    //     email = PlayerPrefs.GetString("Email");
    //     pass = PlayerPrefs.GetString("Pass");
    //     token = PlayerPrefs.GetString("Token");        

    //    // listObjVal.Add(new ListObjectAndValue("Text_MenuName", user, 1));
    //    // listObjVal.Add(new ListObjectAndValue("Text_MenuAddress", "Manchester, USA", 2));

    //     if(InitCredential == ""){
    //                 Debug.Log("not login");
    //                 //EnableGameObj("Canvas_Auth");
    //                 return false;
    //     }else{
                  
    //               return true;
    //                 Debug.Log("logged in");
    //                 //EnableGameObj("Canvas_Dashboard");
    //     }
    //     //Debug.Log(PlayerPrefs.GetString("Token"));
    // }


      IEnumerator GetContentsFromServer(string url, string id) {
         
        string urldata = url + "castleInfo/"+ id;      
        Debug.Log(urldata);
        // Create a Web Form                
        using (UnityWebRequest w = UnityWebRequest.Get(urldata))
        {
            yield return w.Send();
            if (w.isNetworkError)
            {
                 Debug.Log("Deo NetworError");
            }
            else
            {  
                                                                                           
               // Debug.Log(w.downloadHandler.text);
                string txt = w.downloadHandler.text.ToString(); 
                //byte[] data = w.downloadHandler.data;
                
                var N = JSON.Parse(txt);
                var c_name = N["castle"]["c_name"].Value;
                var c_level = N["castle"]["c_level"].Value;
                var c_id = N["castle"]["_id"].Value;

                Level( c_level,c_id) ;

            //     var newId = N["user"]["_id"].Value; 
            //    if(functionName == "ParseJsonData"){
            //        if(id == newId){
            //             PlayerPrefs.SetString("PlayerConfig", txt);
            //             ParseJsonData(txt);
            //         } 
            //    }
               
                                                       
            }
        }
    }

       private void ParseJsonData(string the_JSON_string){
                Debug.Log(the_JSON_string);
                var N = JSON.Parse(the_JSON_string); 
                //Debug.Log(TextureData);
                InitCredential = N["user"]["_id"].Value; 
                PlayerPrefs.SetString("InitCredential", InitCredential);
                Debug.Log("Deo HEre"+InitCredential);
                if(!completed){ 

                // GameObject CH = GameObject.FindWithTag("CastleController");
                // CH.SendMessage("MapPosition",N.ToString());

                GameObject CC = GameObject.FindWithTag("CastleController");
                CC.SendMessage("SetLevel",N.ToString());

                }else{
                   
                }
        }

      


}
