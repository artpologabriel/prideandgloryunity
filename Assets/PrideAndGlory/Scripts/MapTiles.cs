using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTiles : MonoBehaviour
{
    
    public GameObject tiles;
    public int Xcount;
    public int Ycount;
    public float SquareSize;

    public float distances;

    public float XtimesZ;

    public string tileSize;

    void Start()
    {
        Grid(Xcount,Ycount, distances);
    }

    public void Grid(int xPos, int zPos, float cellSize ){

        for(int x = 0; x < xPos; x++){
            for(int z= 0; z < zPos ; z++){                 
                 StartCoroutine(makeTile(x,z,cellSize));   
               //  Debug.Log( (x * z) + " = " + (xPos * zPos));
                 if((x * z) == XtimesZ){
                     Debug.Log( "last" + (x * z));
                   // StartCoroutine(DoneInstatiating());
                 }
            }
        }

    }

    IEnumerator makeTile(float x, float z, float cellSize ){
        float time = x * z / 50f;
        Debug.Log("makeTile "+time);
        yield return new WaitForSeconds(time);
        GameObject t = Instantiate(tiles) as GameObject;
                 t.transform.position = new Vector3(x * cellSize, .3f , z * cellSize);
                 t.transform.parent = gameObject.transform;
                 //t.transform.localScale = new Vector3(1,1,1);
                 t.name = tileSize+"_tile~"+ x.ToString() + "-" + z.ToString();

    }

   IEnumerator DoneInstatiating(){
       yield return new WaitForSeconds(.5f);
        Debug.Log("deactivating small tiles");
        int children = transform.childCount;
        Debug.Log("children-" + children);
         for (int i = 0; i < children; ++i){
            GameObject kid = transform.GetChild(i).gameObject as GameObject;
            kid.SetActive(false);
            Debug.Log(kid.name + " - " + i);
         }

    }


}
