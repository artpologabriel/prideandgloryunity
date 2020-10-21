using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    
    public string ActiveObjName;
    public string Action;
    public string TargetObjName;    
    public GameObject TaskCanvasObj;
    

    void Awake(){
            TaskCanvasObj.SetActive(false);
    }


    void TaskObj(string ObjName){
        ActiveObjName = ObjName;
         TaskCanvasObj.SetActive(true);
    }

    public void Task(string t){
        Action = t;
        TaskCanvasObj.SetActive(false);
    }


    void TaskTarget(string ObjName){
        TargetObjName = ObjName;
        DoTask(Action);

        ActiveObjName = null;
        TargetObjName = null;
        Action = null;    
    }


    void DoTask(string task){
        if(task == "goto"){
                GameObject Obj = GameObject.Find(ActiveObjName);
                Obj.SendMessage("GoTo", TargetObjName);
        }
    }


}
