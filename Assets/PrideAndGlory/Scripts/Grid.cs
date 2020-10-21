using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    private int xPos;
    private int zPos;
    private float cellSize;
    private int[,] gridArray;
 


    public Grid(int xPos, int zPos, float cellSize ){
        this.xPos = xPos;
        this.zPos = zPos;
        this.cellSize = cellSize;


        for(int x = 0; x < gridArray.GetLength(0); x++){
            for(int z= 0; z < gridArray.GetLength(1); z++){
                           
            }
        }

    }


}
