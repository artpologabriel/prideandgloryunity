using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_BuildingController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] building;
    public GameObject BuildingOption;
    GameObject intantiateObject;
    public bool click = false;
    bool buildingCreated = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
		click = true;
		Debug.Log("MapClick On");

        GameObject C = GameObject.FindWithTag("ActiveCamera");
			Camera ActiveCamera = C.GetComponent<Camera>();
			Ray ray = ActiveCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {									
				// Debug.Log("Deo hitpoint" + hit.point); 
                if(!buildingCreated)
                {
                ShowOption();         
                }
			}  
	}


        void ShowOption()
        {

            BuildingOption.SetActive(true);
        }

        public void CreateCavalry(){
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[0],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(0,139,0);
            t.name = "cavalry-";
            buildingCreated = true;
            BuildingOption.SetActive(false);

        }

          public void CreateHospital(){
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[1],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(0,139,0);
            t.name = "hospital-";
            buildingCreated = true;
            BuildingOption.SetActive(false);

        }

        public void Back(){
         BuildingOption.SetActive(false);
        }
    
}
