﻿using System.Collections;
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
                                                    
            string url = Main.ServerUrl + N["route"].Value; 
            Debug.Log("url to post+"+ url);


            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(txt);
            request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            Debug.Log("Status Code: " + request.responseCode);
            Debug.Log(request.downloadHandler.text);
           //ParseDataJson(request.downloadHandler.text);
           //ParseDataJsonSupplier(request.downloadHandler.text);
            //System.IO.File.WriteAllText("C:\blahblah_yourfilepath\yourtextfile.txt", request.downloadHandler.text);   
           // res = JsonUtility.FromJson<LibraryListResponse>(request.downloadHandler.text);
            //Debug.Log(res.id + res.name + res.username);


            //print("Finished Uploading Image" + imageNum);
                    //Debug.Log(w.downloadHandler.text);
                   
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