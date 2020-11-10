using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.Networking;

public class GetContentsFromServer : MonoBehaviour
{
    
    
    
     string route;
     string query;
     string functionName;
    
    public bool DebugLog = true;
    
    void Start()
    {
        /*
        string o = gameObject.name;        
        string q = query;
        string f =functionName;
        StartCoroutine(Get(q, f, o));
        */
    }

    void GetData(string data){
        
        string[] n =   data.Split('-');    
        string o = gameObject.name; 
        string route = n[0];
        string action = n[1];
        string id = n[2];
        StartCoroutine(Get(route, action, o, id));
    }

     IEnumerator Get(string route, string action, string thisObj, string id) {
                 
        string urldata = Main.ServerUrl +"/"+ route +"/"+ id;

        if(DebugLog){
            Debug.Log(urldata);
        }
               
                    
                            using (UnityWebRequest w = UnityWebRequest.Get(urldata))
                                    {
                                        yield return w.Send();
                                        if (w.isNetworkError)
                                        {

                                        }
                                        else
                                        {                                                                                             
                                            
                                            string txt = w.downloadHandler.text.ToString(); 
                                            byte[] data = w.downloadHandler.data;
                                            
                                            if(DebugLog){
                                                Debug.Log(w.downloadHandler.text);
                                                Debug.Log(action);
                                            }
                                            
                                            GameObject Obj = GameObject.Find(thisObj);
                                            Obj.SendMessage(action, txt, SendMessageOptions.DontRequireReceiver);                                                     
                                        }
                                    }
                    
        if(DebugLog){
            Debug.Log(gameObject.name + " : " + urldata);
        }        
 
        // Create a Web Form                
 
    }
}
