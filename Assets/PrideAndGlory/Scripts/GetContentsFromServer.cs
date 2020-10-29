using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.Networking;

public class GetContentsFromServer : MonoBehaviour
{
    
    
    public string url;
    public string query;
    public string functionName;
    
    // Start is called before the first frame update
    void Start()
    {
        string o = gameObject.name;
        string u = url;
        string q = query;
        string f =functionName;
        StartCoroutine(Get(u, q, f, o));
    }

     IEnumerator Get(string url, string query, string action, string thisObj) {
         
        string urldata = url + query;      

        // Create a Web Form                
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
    }
}
