using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GetDeviceID : MonoBehaviour
{
    
    public string DeviceID;
    public Text DeviceIDText;
    public GameObject Main;

    void Start(){

        //android
        if (Application.platform == RuntimePlatform.Android){
            DeviceID = GoGetDeviceID();
            //Main.DeviceID = DeviceID;    
            Main.SendMessage("SetDeviceID", DeviceID);
        }
        
         DeviceID =    SystemInfo.graphicsDeviceID.ToString(); 
        Main.SendMessage("SetDeviceID", DeviceID);
    }

    // Get Android DeviceID
    public string GoGetDeviceID()
    {
        // Get Android ID
        AndroidJavaClass clsUnity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = clsUnity.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject objResolver = objActivity.Call<AndroidJavaObject>("getContentResolver");
        AndroidJavaClass clsSecure = new AndroidJavaClass("android.provider.Settings$Secure");
 
        string android_id = clsSecure.CallStatic<string>("getString", objResolver, "android_id");
 
        // Get bytes of Android ID
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(android_id);
 
        // Encrypt bytes with md5
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);
 
        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";
 
        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }
 
        string device_id = hashString.PadLeft(32, '0');
 
        return device_id;
    }



}
