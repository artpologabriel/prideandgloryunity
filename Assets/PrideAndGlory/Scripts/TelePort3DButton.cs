using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePort3DButton : MonoBehaviour
{
    
    public GameObject[]  TileObjectDetectors;
    public GameObject Castle;
    public GameObject ImaginaryCastle;

    public GameObject tiles;
    bool clickable = true;

    void GotHit(){
        if(clickable){
            Castle.SendMessage("TeleportNow");
            StartCoroutine(DisableMe());                        
        }
        
    }

    IEnumerator DisableMe(){
        yield return new WaitForSeconds(.5f);        
        ImaginaryCastle.SetActive(false);
        tiles.SetActive(false);
        gameObject.SetActive(false);
    }

    void ClickaBle(){
        clickable = true;
    }

    void UnClickable(){
        clickable = false;
    }

    void OnActivated(){
        StartCoroutine(checkIfOk());
    }


    IEnumerator checkIfOk(){
        yield return new WaitForSeconds(.2f);

        GameObject[] tileObjThing = GameObject.FindGameObjectsWithTag("tileObjThing");
        int x = 0;
            for(int i=0; i < tileObjThing.Length;i++){
               x++;
            }
        Debug.Log(x);
        
        CheckIfOkResult(x);
    }

    void CheckIfOkResult(int x){

        if(x < 4){
           // gameObject.SetActive(false);
           UnClickable();
        }else{
            ClickaBle();
            StartCoroutine(checkIfOk());
        }
        
    }

}
