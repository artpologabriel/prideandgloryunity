using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClose : MonoBehaviour
{
    
    public GameObject ObjToDisable;


    public void Close(){
        StartCoroutine(CloseNow());
    }

    IEnumerator CloseNow(){
        yield return new WaitForSeconds(.2f);
        ObjToDisable.SetActive(false);
    }
}
