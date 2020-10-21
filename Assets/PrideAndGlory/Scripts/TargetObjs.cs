using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjs : MonoBehaviour
{
    
    
     void GotHit(){ 
        GameObject TM = GameObject.FindWithTag("TaskManager");
        TM.SendMessage("TaskTarget", gameObject.name);
       
    }
}
