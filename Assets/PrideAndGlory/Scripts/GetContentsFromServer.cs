using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.Networking;

public class GetContentsFromServer : MonoBehaviour
{
    
    
    
    public string route;
    public string query;
    public string functionName;
    
    // Start is called before the first frame update
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
        string q = n[0];
        string f = n[1];
        StartCoroutine(Get(q, f, o));
    }

     IEnumerator Get(string query, string action, string thisObj) {
         
        //string urldata = url + query;      
        string urldata = Main.ServerUrl + route +"/"+ query;
        //string urldata = "http://18.134.172.35/castleinfo/5fa0ca9a0a0d6c9eed1000a3";

                
                    
                            using (UnityWebRequest w = UnityWebRequest.Get(urldata))
                                    {
                                        yield return w.Send();
                                        if (w.isNetworkError)
                                        {

                                        }
                                        else
                                        {                                                                                             
                                            Debug.Log(w.downloadHandler.text);
                                            string txt = w.downloadHandler.text.ToString(); 
                                            byte[] data = w.downloadHandler.data;
                                            Debug.Log(action);
                                            GameObject Obj = GameObject.Find(thisObj);
                                            Obj.SendMessage(action, txt, SendMessageOptions.DontRequireReceiver);                                                     
                                        }
                                    }
                    
                
        Debug.Log(gameObject.name + " : " + urldata);
        // Create a Web Form                
 
    }
}
