using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

public class PickDrag : MonoBehaviour
{
	
	private Vector3 screenPoint;
	private Vector3 offset;
	
	public GameObject thisObj;

	public Quaternion rots;
	public float rX;
	public float rY;
	public float rZ;
	public string activeObjName;

	public bool Moving = false;

	public string CameraFollowObj;

	void OnMouseDown(){
		GameObject C = GameObject.FindWithTag("ActiveCamera");
		Camera ActiveCamera = C.GetComponent<Camera>();
		screenPoint = ActiveCamera.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - ActiveCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		//offset = gameObject.transform.position - ActiveCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, Input.mousePosition.z));
	}
	void OnMouseUp(){
		Debug.Log("MouseUP");
		
		GameObject M = GameObject.FindWithTag("Main");
		float xPos = transform.position.x;
		float yPos = transform.position.y;
		float zPos = transform.position.z;
	//	string data = "action:moveObject,receiverObj:"+gameObject.name+",objectName:"+gameObject.name+",xPos:"+xPos+",yPos:"+yPos+",zPos:"+ zPos;
	//	M.SendMessage("SendDataToSocket", data);
		
		Moving = false;
		EnableCameraPan();
	}
	
	void OnMouseDrag(){
		Moving = true;
		GameObject C = GameObject.FindWithTag("ActiveCamera");
		Camera ActiveCamera = C.GetComponent<Camera>();
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		//Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, Input.mousePosition.z);
		Vector3 curPosition = ActiveCamera.ScreenToWorldPoint (curScreenPoint);// &#43; offset;
		transform.TransformPoint(Vector3.zero);
		transform.position = curPosition;

		DisableCameraPan();
	}


	void Update(){
		if(Moving){
			gameObject.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
		}
		
	} 

	void EnableCameraPan(){
		GameObject C = GameObject.FindWithTag("ActiveCamera");
		C.GetComponent<CameraHandler>().enabled = true;
	}

	void DisableCameraPan(){
		GameObject C = GameObject.FindWithTag("ActiveCamera");
		C.GetComponent<CameraHandler>().enabled = false;
		C.SendMessage("FollowObjectNow", CameraFollowObj);		
	}
	
}