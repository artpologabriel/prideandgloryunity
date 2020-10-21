using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraDragZoom : MonoBehaviour
{
    
    private float dragX, dragY;
    private Vector2 zoomX,zoomY;
    private float cameraHeight = 3;
    private Vector3 screenPoint;
    public Text TextLog;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         processDrag ();
    }


    void  processDrag (){

        string action = "";

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
            if(Input.touchCount == 1){
                action = "drag";
            }else if(Input.touchCount == 2){
                action = "zoom";
            }
            

        } else {
           // action = "drag";
            //nowDown = (Input.GetMouseButton (0) || Input.GetAxis ("Mouse ScrollWheel")!=0);
        }


        if(action == "drag"){
            dragX = Input.GetTouch (0).position.x;
            dragY = Input.GetTouch (0).position.y;

            GameObject C = GameObject.FindWithTag("ActiveCamera");
		    Camera ActiveCamera = C.GetComponent<Camera>();
		    Vector3 curScreenPoint = new Vector3(Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, screenPoint.z);
		    //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, Input.mousePosition.z);
		    Vector3 curPosition = ActiveCamera.ScreenToWorldPoint (curScreenPoint);// &#43; offset;

            transform.position = curPosition;
            TextLog.text = "drag " + dragX + " : " + dragY ;
        }

        if(action == "zoom"){
            zoomX = Input.GetTouch (0).position;
            zoomY = Input.GetTouch (1).position;

             float dist = Vector3.Distance(zoomX, zoomY);
            
            transform.position = new Vector3(dragX, cameraHeight + dist, dragY);

            TextLog.text = "zoom " + cameraHeight + " - " + dist  ;
        }


    }

}
