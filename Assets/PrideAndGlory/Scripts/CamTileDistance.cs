using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamTileDistance : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject MyCastlePoint;
    public Text DistanceToCastlePoint;
    
    void Start()
    {
       // StartCoroutine(CheckIfNearby());
    }

    IEnumerator CheckIfNearby(){
        yield return new WaitForSeconds(5f);
        GameObject[] target = GameObject.FindGameObjectsWithTag("Tile_Empty_Big");           
        for (int i=0; i < target.Length ; i++){
            float dist = Vector3.Distance( target[i].transform.position, transform.position); 
            if(dist < 20f){                
              //  Debug.Log(target[i].name + " - " + dist);
            }           
        }        
        StartCoroutine(CheckIfNearby());
    }



    void Update(){

            float dist = Vector3.Distance( MyCastlePoint.transform.position, transform.position);

            DistanceToCastlePoint.text = Mathf.Round(dist) + " km";

    }

    
}
