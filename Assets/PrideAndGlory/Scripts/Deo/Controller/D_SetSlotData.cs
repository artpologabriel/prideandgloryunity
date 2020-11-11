using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_SetSlotData : MonoBehaviour
{
    // Start is called before the first frame update
      public GameObject[] building;

  void SetData(string data){

      string[] n =   data.Split('-');  
        string name = n[0];
        string _id = n[1];
        string level = n[2];
        string u_id = n[3];

        if(name == "cavalry")
        {
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[0],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(54,139,121);
            t.name=name+"-"+_id;
            t.SendMessage("BuildingSetLevel",data);


        }
        else if(name == "hospital"){
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[1],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(54,139,121);
            t.name=name+"-"+_id;
                        t.SendMessage("BuildingSetLevel",data);


        } 

          else if(name == "embassy"){
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[2],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(54,139,121);
            t.name=name+"-"+_id;
                        t.SendMessage("BuildingSetLevel",data);


        } 

          else if(name == "infantrybarracks"){
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[3],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(54,139,121);
            t.name=name+"-"+_id;
                        t.SendMessage("BuildingSetLevel",data);


        } 

          else if(name == "siegeworkshop"){
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[4],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(54,139,121);
            t.name=name+"-"+_id;
                        t.SendMessage("BuildingSetLevel",data);


        } 

         else if(name == "archery"){
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[5],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(54,139,121);
            t.name=name+"-"+_id;
                        t.SendMessage("BuildingSetLevel",data);


        } 




  }
}
