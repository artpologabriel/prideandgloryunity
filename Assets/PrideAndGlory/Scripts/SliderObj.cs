using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderObj : MonoBehaviour
{
    
    public Slider mainSlider;
    public string NameOfObjToSendValue;
    public float oldValue;
    public float newValue;


    public void Start()
    {
        Slider mainSlider = gameObject.GetComponent<Slider>();        
       StartCoroutine(CheckIfChange());
    }

   
    public void ValueChangeCheck()
    {
       Debug.Log(mainSlider.value);
    }

    IEnumerator CheckIfChange(){
        if(oldValue != mainSlider.value){
            GameObject g = GameObject.Find(NameOfObjToSendValue);
            g.SendMessage("SliderValue", mainSlider.value.ToString());
            oldValue = mainSlider.value;
        }
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(CheckIfChange());
    }



}
