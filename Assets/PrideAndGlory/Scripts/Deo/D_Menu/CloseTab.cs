using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTab : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject CloseObject;
    public GameObject OpenObject;
    public void close() {
        CloseObject.SetActive(false);
                 }

    public void open()
    {
        OpenObject.SetActive(true);


    }

}
