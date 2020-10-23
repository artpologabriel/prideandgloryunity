﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject tiles;
    public float height = .1f;
    
	public bool click = false;
	public float clickTime = 1;

    public GameObject Canvas_MapClickOptions;

    void Update () {
		
		
		if (Input.GetMouseButtonDown (0)) {
			
			
			GameObject C = GameObject.FindWithTag("ActiveCamera");
			Camera ActiveCamera = C.GetComponent<Camera>();
			Ray ray = ActiveCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {									
				    Debug.Log(" hitpoint" + hit.point);                
                    tiles.transform.position = hit.point;
			}            
            Canvas_MapClickOptions.SetActive(true);
			
		}
		
	}

    void HideTiles(){
                tiles.SendMessage("Hide");
        }

	void OnMouseDown(){
		click = true;
		Debug.Log("MapClick On");
	}

	void OnMouseDrag(){
		click = false;
		clickTime += clickTime;
		Debug.Log("MapClick Off "+ clickTime);
	}
 
	

}
