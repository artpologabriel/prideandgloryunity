using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty_Tiles : MonoBehaviour
{
    

    public bool bigTileEmpty = false;

    void Start()    
    {
        StartCoroutine(CheckIfOnScreen());
    }

    IEnumerator CheckIfOnScreen(){

        GameObject Cam = GameObject.FindWithTag("ActiveCamera");        
        float dist = Vector3.Distance( Cam.transform.position, transform.position); 
        Debug.Log(gameObject + " "+ dist );
        yield return new WaitForSeconds(1f);
        StartCoroutine(CheckIfOnScreen());
    }

}
