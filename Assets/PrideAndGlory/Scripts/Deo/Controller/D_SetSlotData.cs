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
            t.transform.eulerAngles = new Vector3(0,139,0);
                    t.name=name+"-"+_id;

        }
        else if(name == "hospital"){
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[1],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(0,139,0);
            t.name=name+"-"+_id;

        }



  }
}
