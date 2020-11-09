﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GotoScene());
    }


    IEnumerator GotoScene(){
            yield return new WaitForSeconds(15f);
             SceneManager.LoadScene("PrideAndGlory");
    }

}
