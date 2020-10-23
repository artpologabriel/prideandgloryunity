using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject targetGameObj;
    public bool Move =false;
    public float speed = 1f;


    // Update is called once per frame
    void Update()
    {
        if(Move){
            float step =  speed; //* Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetGameObj.transform.position, step);
            Debug.Log("Teleporting"+ transform.position);
        }        
    }

    public void TeleportNow(){
        GameObject tile = GameObject.Find("Imaginary_CastleHolder");
        targetGameObj = tile;
        Move  = true;
        StartCoroutine(UnMove());        
    }

    IEnumerator UnMove(){
        yield return new WaitForSeconds(1f);
        Move = false;
    }
}
