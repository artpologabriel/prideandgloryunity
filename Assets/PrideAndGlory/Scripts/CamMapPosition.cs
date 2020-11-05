using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamMapPosition : MonoBehaviour
{
    
    public InputField IFX;
    public InputField IFZ;
    public Text MapPosition;
    public GameObject Obj;
    public float height = 18f;

    public GameObject PanelCamGoTo;    

    float xValue;
    float zValue;

    void Start(){

        PanelCamGoTo.SetActive(false);
    }

    void LateUpdate(){
        RefreshMapText();
    }

    public void OpenCamGoToPanel(){

            PanelCamGoTo.SetActive(true);
    }

    
    public void Goto(){

        if((IFX.text=="") || (IFZ.text=="")){
            PanelCamGoTo.SetActive(false);
            return;
        }


        if((!IsAllDigits(IFX.text)) || (!IsAllDigits(IFZ.text))){            
            xValue = 0;
            zValue = 0;
        }else{            
            xValue = float.Parse(IFX.text);
            zValue = float.Parse(IFZ.text);
        }



        if((float.IsNaN(xValue)) || (float.IsNaN(zValue))){
            return;
        }

        if(xValue > 1100){
            xValue =1100;
        }
        if(xValue < 0){
            xValue = 0;    
        }

        if(zValue > 1100){
            zValue = 1100;
        }
        if(zValue < 0){
            zValue = 0;    
        }

        Obj.transform.position = new Vector3( xValue , height, zValue);
        IFX.text = xValue.ToString();
        IFZ.text = zValue.ToString();
        MapPosition.text = "X:"+xValue.ToString()+" - Y:"+ zValue.ToString();
        StartCoroutine(ClosePanelCamGoTo()); 
    }

    


    IEnumerator ClosePanelCamGoTo(){
        yield return new WaitForSeconds(2f);
        PanelCamGoTo.SetActive(false);
    }

    void RefreshMapText(){
        
        float xVal = Mathf.Round(Obj.transform.position.x) ;
        float zVal = Mathf.Round(Obj.transform.position.z) ;
        MapPosition.text = "X:"+xVal.ToString()+" - Y:"+ zVal.ToString();
        
    }

    bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

}
