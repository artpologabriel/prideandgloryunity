using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHide : MonoBehaviour
{
    
    void Start(){
        Hide();
    }
    
    public void Hide(){
        StartCoroutine(HideNow());
    }

    IEnumerator HideNow(){
        yield return new WaitForSeconds(1f);
        transform.position = new Vector3(10000,10000,10000);
    }

}
