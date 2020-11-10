using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjOnCamera : MonoBehaviour
{
    void OnBecameVisible()
    {        
        int children = transform.childCount;        
         for (int i = 0; i < children; ++i){
             transform.GetChild(i).gameObject.SetActive(true);
             transform.GetChild(i).gameObject.SendMessage("Enable",null, SendMessageOptions.DontRequireReceiver);
         }
    }


    void OnBecameInvisible()
    {
        int children = transform.childCount;        
         for (int i = 0; i < children; ++i){
             transform.GetChild(i).gameObject.SetActive(false);
         }
    }
}
