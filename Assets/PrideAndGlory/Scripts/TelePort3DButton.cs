using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePort3DButton : MonoBehaviour
{
    

    public GameObject Castle;

    void GotHit(){

        Castle.SendMessage("TeleportNow");

    }
}
