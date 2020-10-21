using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapQuad : MonoBehaviour
{
    
    
    void GotHit(){

        Destroy(gameObject, 2f);

    }

    void OnBecameVisible()
    {
        enabled = true;
    }

    void OnBecameInvisible()
    {
        enabled = false;
    }



}
