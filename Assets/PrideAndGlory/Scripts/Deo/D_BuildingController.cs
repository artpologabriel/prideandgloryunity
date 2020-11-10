using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System.IO;
using System;

public class D_BuildingController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] building;
    public GameObject BuildingOption;
    public GameObject BuildingDO;

    GameObject intantiateObject;
    	public float clickTime = 1;

        public string cav_id;

    public bool click = false;
    bool buildingCreated = false;
    void Start()
    {
                    

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake(){
    //    StartCoroutine(CheckSlotData());
    }

IEnumerator CheckSlotData(){
      yield return new WaitForSeconds(1f);
       //Debug.Log("CheckName: " + id);
          //yield return new WaitForSeconds(2f);
        //   string data = "5fa3be217becc9bb11eed783" + "-" + "LoadSlotData";
        //   gameObject.SendMessage("GetData", data);
    }  

    	void OnMouseDrag(){
		click = false;
        		clickTime += clickTime;

		// Debug.Log("Mouse drag ");
	}

    void OnMouseUp(){
	Debug.Log("MapClick On");
    Debug.Log("Click status"+click);

    if(clickTime < 100){
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
                else{
                ShowBuildingDo();         

                }
			} 

    } 

    		clickTime = 1f;

    }

    

    public void SetSlotNumber(string data){
        //   Debug.Log("Deo GetSlot Number"+data);

    }

    void OnMouseDown(){
		click = true;
        		Debug.Log("Mouse Down ");

	}


    //  void CheckName(){
    //       //Debug.Log("CheckName: " + id);
    //       //yield return new WaitForSeconds(2f);
    //       string v = gameObject.name;          
    //       string[] na =   v.Split('-');
    //       string id = na[1];
    //       string data = id + "-" + "SetLevel";
    //       Debug.Log("Deo slot"+id);
    //     //   gameObject.SendMessage("GetData", data);
    // }

        void ShowOption()
        {
            BuildingOption.SetActive(true);
        } 
         void ShowBuildingDo()
        {
            BuildingDO.SetActive(true);
        }


      
        public void CreateCavalry(){
            string data ="u_id:"+Main.InitCredential+",slotname:"+gameObject.name+",route:/cavalry,action:ReturnData,receiverObj:"+gameObject.name;
            gameObject.SendMessage("PostDataToServer", data);
            buildingCreated = true;
            BuildingOption.SetActive(false);
        }

      

        public void ReturnData(string data){
            LoadSlotData(data);
        }

          public void CreateHospital(){
             string data ="u_id:"+Main.InitCredential+",slotname:"+gameObject.name+",route:/hospital,action:LoadHospital,receiverObj:"+gameObject.name;
            gameObject.SendMessage("PostDataToServer", data);
            buildingCreated = true;
            BuildingOption.SetActive(false);

        }

   public void CreateSiegeWorkshop(){
            string data ="u_id:"+Main.InitCredential+",slotname:"+gameObject.name+",route:/siegeworkshop,action:LoadSiegeWorkshop,receiverObj:"+gameObject.name;
            gameObject.SendMessage("PostDataToServer", data);
            buildingCreated = true;
            BuildingOption.SetActive(false);
        }

   void LoadSiegeWorkshop(string data){
       Debug.Log("SiegeWorshop "+data);
         var N = JSON.Parse(data);
         var cav_name =N["level"].Value;
         var c_id = N["_id"].Value;
         var slotname = N["slotname"].Value;
         if(slotname == gameObject.name)
         {
            buildingCreated = true;
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[3],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(0,139,0);
            t.name = "siegeworkshop-"+c_id;
         }

          
    }

     public void CreateArchery(){
            string data ="u_id:"+Main.InitCredential+",slotname:"+gameObject.name+",route:/archery,action:LoadArchery,receiverObj:"+gameObject.name;
            gameObject.SendMessage("PostDataToServer", data);
            buildingCreated = true;
            BuildingOption.SetActive(false);
        }

   void LoadArchery(string data){
       Debug.Log("SiegeWorshop "+data);
         var N = JSON.Parse(data);
         var cav_name =N["level"].Value;
         var c_id = N["_id"].Value;
         var slotname = N["slotname"].Value;
         if(slotname == gameObject.name)
         {
            buildingCreated = true;
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[2],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(0,139,0);
            t.name = "archery-"+c_id;
         }

          
    }

        void LoadHospital(string data){
         var N = JSON.Parse(data);
         var cav_name =N["h_level"].Value;
         var c_id = N["_id"].Value;
         var slotname = N["slotname"].Value;
         if(slotname == gameObject.name)
         {
            buildingCreated = true;
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[1],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(0,139,0);
            t.name = "hospital-"+c_id;
         }

          
    }

     void LoadSlotData(string data){
         var N = JSON.Parse(data);
         var cav_name =N["cav_level"].Value;
         var c_id = N["_id"].Value;
         var slotname = N["slotname"].Value;

         if(slotname == gameObject.name)
         {
            buildingCreated = true;
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[0],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(0,139,0);
            t.name = "cavalry-"+c_id;
         }

          
    }



    
     public void CreateInfantrybarracks(){
            string data ="u_id:"+Main.InitCredential+",slotname:"+gameObject.name+",route:/infantrybarracks,action:LoadInfantrybarracks,receiverObj:"+gameObject.name;
            gameObject.SendMessage("PostDataToServer", data);
            buildingCreated = true;
            BuildingOption.SetActive(false);
        }

   void LoadInfantrybarracks(string data){
         var N = JSON.Parse(data);
         var cav_name =N["level"].Value;
         var c_id = N["_id"].Value;
         var slotname = N["slotname"].Value;
         if(slotname == gameObject.name)
         {
            buildingCreated = true;
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[3],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(0,139,0);
            t.name = "infantrybarracks-"+c_id;
         }

          
    }



    public void CreateEmbassy(){
            string data ="u_id:"+Main.InitCredential+",slotname:"+gameObject.name+",route:/embassy,action:LoadEmbassy,receiverObj:"+gameObject.name;
            gameObject.SendMessage("PostDataToServer", data);
            buildingCreated = true;
            BuildingOption.SetActive(false);
        }

   void LoadEmbassy(string data){
         var N = JSON.Parse(data);
         var cav_name =N["level"].Value;
         var c_id = N["_id"].Value;
         var slotname = N["slotname"].Value;

         if(slotname == gameObject.name)
         {
            buildingCreated = true;
            GameObject targetObj  =GameObject.Find(gameObject.name);
            GameObject t = Instantiate(building[2],transform.position,transform.rotation) as GameObject;
            t.transform.parent = gameObject.transform;
            t.transform.eulerAngles = new Vector3(0,139,0);
            t.name = "embassy-"+c_id;
         }

          
    }
   


        public void Back(){
         BuildingOption.SetActive(false);
        }

        public void BuildingDoBack(){
         BuildingDO.SetActive(false);
        }


        public void buildingContent(){
            buildingCreated = true;
        }

    
}
