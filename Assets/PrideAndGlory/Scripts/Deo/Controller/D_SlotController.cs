using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System.IO;
using System;
using System.Linq;
using System.Text;

public class D_SlotController : MonoBehaviour
{
    // Start is called before the first frame update
     JSONArray cav_array;
         JSONArray hos_array;
         JSONArray siegeworkshop;
        JSONArray infantrybarracks;
        JSONArray embassy;
        JSONArray archery;

    void Awake(){
       StartCoroutine(CheckSlotData());
    }


IEnumerator CheckSlotData(){
          yield return new WaitForSeconds(2f);
          string id = Main.InitCredential;
          Debug.Log("Deo U_Id"+Main.InitCredential);
          string route = "slots";
          string data =  route+ "-" + "LoadSlotData"+"-"+id; 
          gameObject.SendMessage("GetData", data);
    }


    void LoadSlotData(string data){
        var N = JSON.Parse(data);
   
        
        cav_array = N["cavalry"].AsArray;
        hos_array = N["hospital"].AsArray;

     


       for(int i =0; i < cav_array.Count; i++)
       {
               var c_id =cav_array[i]["_id"].Value;
        var c_slot =cav_array[i]["slotname"].Value;
         var c_level =cav_array[i]["level"].Value;
         var c_uid =cav_array[i]["u_id"].Value;


        string dataJson = "cavalry"+"-"+c_id+"-"+c_level+"-"+c_uid;
        GameObject cavobj =  GameObject.Find(c_slot);
        cavobj.SendMessage("SetData",dataJson);
        cavobj.SendMessage("buildingContent");
       }

            //Cavalry Data

     
        //Hospital Data
                          Debug.Log("Deo slot name Hospital size "+hos_array.Count);

          for(int h =0; h < hos_array.Count; h++)
       {
        var h_id =hos_array[h]["_id"].Value;
        var h_slot =hos_array[h]["slotname"].Value;
         var h_level =hos_array[h]["level"].Value;
         var h_uid =hos_array[h]["u_id"].Value;
         string hospitalData = "hospital"+"-"+h_id+"-"+h_level+"-"+h_uid;

        GameObject hosObj =  GameObject.Find(h_slot);
        hosObj.SendMessage("SetData",hospitalData);
        hosObj.SendMessage("buildingContent");
       }
       

    //siegeworkshop
               siegeworkshop= N["siegeworkshop"].AsArray;
      for(int h =0; h < siegeworkshop.Count; h++)
       {
        var s_id =siegeworkshop[h]["_id"].Value;
        var s_slot =siegeworkshop[h]["slotname"].Value;
         var s_level =siegeworkshop[h]["level"].Value;
         var s_uid =siegeworkshop[h]["u_id"].Value;
         string siegeworkshopData = "siegeworkshop"+"-"+s_id+"-"+s_level+"-"+s_uid;

        GameObject hosObj =  GameObject.Find(s_slot);
        hosObj.SendMessage("SetData",siegeworkshopData);
        hosObj.SendMessage("buildingContent");
       }


           //infantrybarracks
         infantrybarracks= N["infantrybarracks"].AsArray;

      for(int h =0; h < infantrybarracks.Count; h++)
       {
        var s_id =infantrybarracks[h]["_id"].Value;
        var s_slot =infantrybarracks[h]["slotname"].Value;
         var s_level =infantrybarracks[h]["level"].Value;
         var s_uid =infantrybarracks[h]["u_id"].Value;
         string infantrybarracksData = "infantrybarracks"+"-"+s_id+"-"+s_level+"-"+s_uid;
        GameObject hosObj =  GameObject.Find(s_slot);
        hosObj.SendMessage("SetData",infantrybarracksData);
        hosObj.SendMessage("buildingContent");
       }


           //embassy
         embassy= N["embassy"].AsArray;

      for(int h =0; h < embassy.Count; h++)
       {
        var s_id =embassy[h]["_id"].Value;
        var s_slot =embassy[h]["slotname"].Value;
         var s_level =embassy[h]["level"].Value;
         var s_uid =embassy[h]["u_id"].Value;
         string embassyData = "embassy"+"-"+s_id+"-"+s_level+"-"+s_uid;

        GameObject hosObj =  GameObject.Find(s_slot);
        hosObj.SendMessage("SetData",embassyData);
        hosObj.SendMessage("buildingContent");
       }


         //archery
         archery= N["archery"].AsArray;

      for(int h =0; h < archery.Count; h++)
       {
        var s_id =archery[h]["_id"].Value;
        var s_slot =archery[h]["slotname"].Value;
         var s_level =archery[h]["level"].Value;
         var s_uid =archery[h]["u_id"].Value;
         string archeryData = "archery"+"-"+s_id+"-"+s_level+"-"+s_uid;

        GameObject hosObj =  GameObject.Find(s_slot);
        hosObj.SendMessage("SetData",archeryData);
        hosObj.SendMessage("buildingContent");
       }



       


    }

}
