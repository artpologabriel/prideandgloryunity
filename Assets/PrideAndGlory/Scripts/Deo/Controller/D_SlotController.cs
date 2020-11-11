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
        bool mainId =false;

    void Awake(){
        StartCoroutine(CheckSlotData());
    }
    void Update(){
        // StartCoroutine(CheckSlotData());
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
      for(int si =0; si < siegeworkshop.Count; si++)
       {
        var s_id =siegeworkshop[si]["_id"].Value;
        var s_slot =siegeworkshop[si]["slotname"].Value;
         var s_level =siegeworkshop[si]["level"].Value;
         var s_uid =siegeworkshop[si]["u_id"].Value;
         string siegeworkshopData = "siegeworkshop"+"-"+s_id+"-"+s_level+"-"+s_uid;

        GameObject hosObj =  GameObject.Find(s_slot);
        hosObj.SendMessage("SetData",siegeworkshopData);
        hosObj.SendMessage("buildingContent");
       }


           //infantrybarracks
         infantrybarracks= N["infantrybarracks"].AsArray;

      for(int inf =0; inf < infantrybarracks.Count; inf++)
       {
        var s_id =infantrybarracks[inf]["_id"].Value;
        var s_slot =infantrybarracks[inf]["slotname"].Value;
         var s_level =infantrybarracks[inf]["level"].Value;
         var s_uid =infantrybarracks[inf]["u_id"].Value;
         string infantrybarracksData = "infantrybarracks"+"-"+s_id+"-"+s_level+"-"+s_uid;
        GameObject hosObj =  GameObject.Find(s_slot);
        hosObj.SendMessage("SetData",infantrybarracksData);
        hosObj.SendMessage("buildingContent");
       }


           //embassy
         embassy= N["embassy"].AsArray;

      for(int em =0; em < embassy.Count; em++)
       {
        var s_id =embassy[em]["_id"].Value;
        var s_slot =embassy[em]["slotname"].Value;
         var s_level =embassy[em]["level"].Value;
         var s_uid =embassy[em]["u_id"].Value;
         string embassyData = "embassy"+"-"+s_id+"-"+s_level+"-"+s_uid;

        GameObject hosObj =  GameObject.Find(s_slot);
        hosObj.SendMessage("SetData",embassyData);
        hosObj.SendMessage("buildingContent");
       }


         //archery
         archery= N["archery"].AsArray;

      for(int arc =0; arc < archery.Count; arc++)
       {
        var s_id =archery[arc]["_id"].Value;
        var s_slot =archery[arc]["slotname"].Value;
         var s_level =archery[arc]["level"].Value;
         var s_uid =archery[arc]["u_id"].Value;
         string archeryData = "archery"+"-"+s_id+"-"+s_level+"-"+s_uid;

        GameObject hosObj =  GameObject.Find(s_slot);
        hosObj.SendMessage("SetData",archeryData);
        hosObj.SendMessage("buildingContent");
       }



       


    }

}
