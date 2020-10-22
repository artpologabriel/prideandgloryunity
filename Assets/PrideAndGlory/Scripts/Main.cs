using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using System.IO;



[System.Serializable]
public class Main : MonoBehaviour
{
    public static Main instance = null;
    public GameObject[] Canvases;

    public static string InitCredential;    
    public static string username;
    public static string email;
    public static string pass;
    public static string token;

    public static string myData;

    public string requesterObj;
    public string requesterAction;

    public Text TextInfo;
    public bool serverReady = false;

    public GameObject NetworkController;

    void Awake()
        {
            if(instance == null){
                instance = this;
            } else if (instance !=this){
                Destroy(gameObject);
            }

            string theTime = System.DateTime.Now.ToString("hh:mm:ss"); 
            string theDate = System.DateTime.Now.ToString("MM/dd/yyyy"); 


            Debug.Log(theTime + "-" +theDate );

            
            if(!checkCredential()){
                InitCredential = Md5Sum(theDate + theTime);
            } else{
                InitCredential = PlayerPrefs.GetString("InitCredential");
            }
            
            
        }

    


    void Start(){
       // StartCoroutine(CloseWelcomPanel());
        //checkCredential();
        //TextInfo.text = DeviceID;
        StartCoroutine(CheckServerInit());
        Debug.Log("Initializing");
    }

    IEnumerator CheckServerInit(){
        yield return new WaitForSeconds(.5f);
        if(!serverReady){
            if(InitCredential!=""){
                string param = "action:ping,receiverObj:Main,InitCredential:"+InitCredential;
                string data =  JsonMaker(param);                      
                NetworkController.SendMessage("SendDataToSocket",data);
                Debug.Log("Server Ping" + data);
            }
            StartCoroutine(CheckServerInit());
        }else{
            EnableControls();
        }        
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

    void InitFromServer(){
        serverReady = true;
    }

    void EnableControls(){
        TextInfo.text = "Server is ready! Enabling controls";
    }


    

    public void SendDataToSocket(string data){        
        NetworkController.SendMessage("SendDataToSocket",JsonMaker(data));
        Debug.Log("SEND: "+ data);
    }



    public void SendPingToSocket(){

        float rn = Random.Range(1.0f,1000.0f);
        string data = "{action:ping, randomNumber:"+ rn.ToString() +"}";        
        NetworkController.SendMessage("SendDataToSocket",data);
        Debug.Log(data);

        

    }


    bool checkCredential(){
        InitCredential = PlayerPrefs.GetString("InitCredential");

        email = PlayerPrefs.GetString("Email");
        pass = PlayerPrefs.GetString("Pass");
        token = PlayerPrefs.GetString("Token");        

       // listObjVal.Add(new ListObjectAndValue("Text_MenuName", user, 1));
       // listObjVal.Add(new ListObjectAndValue("Text_MenuAddress", "Manchester, USA", 2));

        if(InitCredential == ""){
                   // Debug.Log("not login");
                    //EnableGameObj("Canvas_Auth");
                    return false;
        }else{
                  
                  return true;
                   // Debug.Log("logged in");
                    //EnableGameObj("Canvas_Dashboard");
        }
        //Debug.Log(PlayerPrefs.GetString("Token"));
    }

    IEnumerator CloseWelcomPanel(){
        yield return new WaitForSeconds(5f);
        DisableGameObj("Panel_Welcome");
    }

    void EnableGameObj(string ObjName){
            
            if(ObjName != "Canvas_Menu"){
            for(int i=0; i < Canvases.Length ; i++){                
                    Canvases[i].SetActive(false);                
            }
        }                        
            
            for(int i=0; i < Canvases.Length ; i++){
                if(Canvases[i].name == ObjName){
                    Canvases[i].SetActive(true);
                }
            }
    }
    
    void DisableGameObj(string ObjName){
            for(int i=0; i < Canvases.Length ; i++){
                if(Canvases[i].name == ObjName){
                    Canvases[i].SetActive(false);
                }
            }
    }

    void Logout(){
        email = "";
        pass = "";
        PlayerPrefs.SetString("Email", "");
        PlayerPrefs.SetString("Token", "");
        EnableGameObj("Canvas_Logout");
    }


    void RequestQue(string ObjNameAction){
        string[] i = ObjNameAction.Split('~');
        requesterObj = i[0];
        requesterAction = i[1];
    }    

    void RequestSuccess(){
        GameObject reqObj = GameObject.Find(requesterObj);
        string action = requesterAction;
        if(reqObj != null){
        reqObj.SendMessage("RequestSuccess",action);
        }
        StartCoroutine(CloseServerResponsePanel());
    }

    void RequestFailed(){
        GameObject reqObj = GameObject.Find(requesterObj);
        string action = requesterAction;
        if(reqObj != null){
            reqObj.SendMessage("RequestFailed",action);
        }
        StartCoroutine(RequestObjUnQue());        
    }

    IEnumerator RequestObjUnQue(){
        yield return new WaitForSeconds(.5f);
        requesterObj = null;

    }

    IEnumerator CloseServerResponsePanel(){
        yield return new WaitForSeconds (3f);
        GameObject Panel_ServerResponse = GameObject.Find("Panel_ServerResponse");
        if(Panel_ServerResponse != null){
            Panel_ServerResponse.SetActive(false);
        }
        
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
