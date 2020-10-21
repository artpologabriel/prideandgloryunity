using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

[System.Serializable]
public class Auth_Controller : MonoBehaviour
{
    
    public string urltoregister;
    public string urltologin;
    public InputField Name;
    public InputField Username;
    public InputField Password;
    public InputField Email;
    public Text ServerResponse;
    public string action;
    public GameObject ButtonToLogin;
    public GameObject ButtonToRegister;
    public GameObject NameGameObj;
    public GameObject EmailGameObj;
    public GameObject SubmitButtonLogin;
    public GameObject SubmitButtonRegister;
    public GameObject PanelResponse;

    void OnEnable(){
        PanelResponse.SetActive(false);
    }

    public void Register(){
        action = "register";
        string json_string = "{ \"name\": \" "+ Name.text +"\",\"username\":\""+Username.text+"\",\"password\":\""+Password.text+"\",\"email\":\""+Email.text+"\" }" ; 
        Debug.Log(json_string);
        StartCoroutine(Post(urltoregister, json_string));
    }


    public void Login(){
        action = "login";
        string json_string = "{ \"email\":\""+Email.text+"\",\"password\":\""+Password.text+"\" }" ; 
        Debug.Log(json_string);
        StartCoroutine(Post(urltologin, json_string));
    }



    IEnumerator Post(string url, string bodyJsonString)
        {
            PanelResponse.SetActive(true);
            ServerResponse.text = "Please wait";
            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(bodyJsonString);
            request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");            
            request.SetRequestHeader("Accept", "application/json");
            yield return request.SendWebRequest();
            //Debug.Log("Status Code: " + request.responseCode);
            //Debug.Log(request.downloadHandler.text);  
            if(request.responseCode == 200){
                    if(action == "login"){
                        Debug.Log("login");
                        LoginResponse(request.downloadHandler.text);
                    }else{
                        Debug.Log("register");
                        RegisterResponse(request.downloadHandler.text);
                    }    
            } else{
                ErrorResponse(request.downloadHandler.text);
            }
 



     } 

    void ErrorResponse(string res){
            var N = JSON.Parse(res);             
            PanelResponse.SetActive(true);
            ServerResponse.text = N["message"].Value;
            
    }

    void LoginResponse(string res){
            PanelResponse.SetActive(true);
            var N = JSON.Parse(res);            
            var access_token = N["access_token"].Value;
            var token_type = N["token_type"].Value;
            var expires_at = N["expires_at"].Value;
            Main.email = Email.text;
            Main.token = access_token;
            PlayerPrefs.SetString("Email", Email.text);
            PlayerPrefs.SetString("Token", access_token);
            ServerResponse.text = "Login Successful";
            StartCoroutine(CloseLoginWindow());
           // LoginToNetworkMngr(u,id,token);            
    }

    void RegisterResponse(string res){
            PanelResponse.SetActive(true);
            var N = JSON.Parse(res);
            var access_token = N["access_token"].Value;
            var token_type = N["token_type"].Value;
            var expires_at = N["expires_at"].Value;
            //var token = N["token"].Value;
            //var id = N["id"].Value;
            //var u = N["token"].Value;
            //Debug.Log(token + id + u);
            ServerResponse.text = "Registration Successful";
            
    }

    public void GoToLogin(){
        ButtonToLogin.SetActive(false);
        ButtonToRegister.SetActive(true);
        NameGameObj.SetActive(false);
        EmailGameObj.SetActive(false);
        SubmitButtonRegister.SetActive(false);
        SubmitButtonLogin.SetActive(true);
        action = "login";
    }

    public void GoToReg(){
        ButtonToLogin.SetActive(true);
        ButtonToRegister.SetActive(false);
        NameGameObj.SetActive(true);
        EmailGameObj.SetActive(true);
        SubmitButtonRegister.SetActive(true);
        SubmitButtonLogin.SetActive(false);
        action = "register";
    }

    IEnumerator CloseLoginWindow(){
        yield return new WaitForSeconds(2.0f);
        PanelResponse.SetActive(false);
        GameObject Main = GameObject.FindWithTag("Main");
        Main.SendMessage("EnableGameObj", "Canvas_Dashboard"); 
        Main.SendMessage("DisableGameObj", "Canvas_Auth");        
    }

}
