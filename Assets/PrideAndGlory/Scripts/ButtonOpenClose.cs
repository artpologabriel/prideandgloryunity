using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenClose : MonoBehaviour
{

    public string ObjNameToOpen;
    public string ObjNameToClose;
     
    public void OpenAndClose(){
        GameObject MainObj = GameObject.FindGameObjectWithTag("Main");
        MainObj.SendMessage("EnableGameObj", ObjNameToOpen);
        MainObj.SendMessage("DisableGameObj", ObjNameToClose);
    }

    public void Open(){
        GameObject MainObj = GameObject.FindGameObjectWithTag("Main");
        MainObj.SendMessage("EnableGameObj", ObjNameToOpen);        
    }

    public void Close(){
        GameObject MainObj = GameObject.FindGameObjectWithTag("Main");
        MainObj.SendMessage("DisableGameObj", ObjNameToClose);       
    }


}
