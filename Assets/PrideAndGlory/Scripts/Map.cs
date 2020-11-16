using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject tiles;
	public GameObject[] tilesChilds;
	public GameObject[] tilesChildsToDisable;
	public GameObject[] tilesChildsToEnable;
	public GameObject[] tilesChildsToResetTexture;
    public float height = .1f;
    
	public bool click = false;
	public float clickTime = 1;

    public GameObject Canvas_MapClickOptions;
	public GameObject MapObstacles;


	public Texture2D textureDefault;

	public bool showMapMenu = true;
	public GameObject[] showMapMenuObjs; 

    void Update () {
		
		/*
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
		*/
	}

    void HideTiles(){
                tiles.SendMessage("Hide");
        }

	void OnMouseDown(){
		click = true;
		//Debug.Log("MapClick On");
	}

	void OnMouseDrag(){
		click = false;
		clickTime += clickTime;
		//Debug.Log("MapClick Off "+ clickTime);
	}
	
	void OnMouseUp(){

		



		if(clickTime < 100){
			GameObject C = GameObject.FindWithTag("ActiveCamera");
			Camera ActiveCamera = C.GetComponent<Camera>();
			Ray ray = ActiveCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {									
				   //Debug.Log(" hitpoint" + hit.point);                
                    tiles.transform.position = hit.point;
			}            
            
			if(showMapMenu){
				showMapMenuObjs[0].SetActive(false);
				showMapMenuObjs[1].SetActive(false);
				showMapMenu = false;
			}else{
				showMapMenuObjs[0].SetActive(true);
				showMapMenuObjs[1].SetActive(true);
				showMapMenu = true;
			}

			tiles.SetActive(true);
			//Canvas_MapClickOptions.SetActive(true);	
			
			
			MapObstacles.SendMessage("MapDragged");
			
		}
		clickTime = 1f;

		PositionKids();
		DisAble();
		SetBackTexture();
		
	}
	
	void PositionKids(){
		for(int i = 0 ; i < tilesChilds.Length; i++){
			tilesChilds[i].transform.position = tiles.transform.position;
			//StartCoroutine(DisAble(tilesChilds[i].gameObject));
		}
	}

	void DisAble(){
		tilesChildsToDisable[0].SetActive(false);
		tilesChildsToDisable[1].SetActive(false);
		tilesChildsToDisable[2].SetActive(false);
	}

	void EnableKids(){
		for(int i=0; i < tilesChildsToEnable.Length; i++){
			tilesChildsToEnable[i].SetActive(true);
		}
	}

	void SetBackTexture(){

		for(int i = 0 ; i < tilesChildsToResetTexture.Length; i++){
			tilesChildsToResetTexture[i].GetComponent<Renderer>().material.mainTexture = textureDefault;
		}
		
	}

}
