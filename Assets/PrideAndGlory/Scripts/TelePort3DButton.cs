using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePort3DButton : MonoBehaviour
{
    

    public GameObject Castle;
    public GameObject ImaginaryCastle;

    public GameObject tiles;

    void GotHit(){
        Castle.SendMessage("TeleportNow");
        StartCoroutine(DisableMe());            
    }

    IEnumerator DisableMe(){
        yield return new WaitForSeconds(.5f);        
        ImaginaryCastle.SetActive(false);
        tiles.SetActive(false);
        gameObject.SetActive(false);
    }



}
