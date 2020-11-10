using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class PostToServer : MonoBehaviour
{
    

    public void PostDataToServer(string data){
        
        StartCoroutine(Post(data));
    }

    
    IEnumerator Post(string data)
        {
            string txt = JsonMaker(data);
            Debug.Log(txt);
            var N = JSON.Parse(txt); 
                                                    
            string url = Main.ServerUrl +"/"+ N["route"].Value; 
            Debug.Log("url to post+"+ url);


            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(txt);
            request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            Debug.Log("Status Code: " + request.responseCode);
            Debug.Log(request.downloadHandler.text);

            
            string action = N["action"].Value;
            string thisObj = N["receiverObj"].Value; 
            GameObject Obj = GameObject.Find(thisObj);
            Obj.SendMessage(action, txt, SendMessageOptions.DontRequireReceiver); 
           
                   
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
