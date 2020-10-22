using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {



	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject C = GameObject.FindWithTag("ActiveCamera");
			Camera ActiveCamera = C.GetComponent<Camera>();
			Ray ray = ActiveCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log ("Name = " + hit.collider.name);
				//Debug.Log ("Tag = " + hit.collider.tag);
				//Debug.Log ("Hit Point = " + hit.point);
			//	Debug.Log ("Object position = " + hit.collider.gameObject.transform.position);
				//Debug.Log ("--------------");
				GameObject h = GameObject.Find(hit.collider.name);
				h.SendMessage("GotHit", null, SendMessageOptions.DontRequireReceiver);				
				//targetObj.SendMessage(Message);
				Debug.Log("hitpoint" + hit.point);
				if(h.name != "Map"){
					GameObject Map = GameObject.FindWithTag("Map");
					Map.SendMessage("HideTiles");
				}
			}
		}
	}
}