using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpen : MonoBehaviour
{
    

    public GameObject ObjToEnable;

    public void EnableObj(){
        ObjToEnable.SetActive(true);
    }


}
