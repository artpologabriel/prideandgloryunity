using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCastle : MonoBehaviour
{

    void Start(){

        StartCoroutine(ChangeName());
    }

    IEnumerator ChangeName(){
        yield return new WaitForSeconds(1f);
        if(Main.InitCredential ==""){
            StartCoroutine(ChangeName());
        }else{
            gameObject.name = "castle-" + Main.InitCredential;
        }
    }

}
