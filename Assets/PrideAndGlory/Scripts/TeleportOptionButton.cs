using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOptionButton : MonoBehaviour
{
    
    public GameObject ImaginaryCastle;
    public GameObject tiles;
    public GameObject tileWhite;

    void OnMouseDown(){

        ImaginaryCastle.SetActive(true);
        tiles.SetActive(true);
        gameObject.SetActive(false);
        tileWhite.SetActive(false);

    }

}
