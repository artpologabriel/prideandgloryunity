using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class PlayersMapPositionController : MonoBehaviour
{
    
    public GameObject PlayerPosition;
    public GameObject CastleController;

    public float height = .5f;
   
    public void SetPlayersPosition(string data){
                Debug.Log(data);
                
                var N = JSON.Parse(data);                 
                var results = N["data"].Value;
                
                for(int i = 0; i < 10000 ; i++){
                    var id = N["data"]["map_position"][i]["u_id"].Value;
                    var x_pos = N["data"]["map_position"][i]["x_pos"].AsFloat;
                    var z_pos = N["data"]["map_position"][i]["z_pos"].AsFloat;
                    if(id != ""){
                        if(id != Main.InitCredential){
                            GameObject Obj = Instantiate(PlayerPosition) as GameObject;
                            Obj.name = "castle_point-"+id;
                            Obj.transform.position = new Vector3(x_pos, height, z_pos);
                            GameObject Castle = Instantiate(CastleController) as GameObject;
                            Castle.name = "castle-"+id;
                            Castle.transform.parent = Obj.transform;
                        }                                                
                    }   
                }
                
    }
    
}
