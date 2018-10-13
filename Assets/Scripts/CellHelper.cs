using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CellHelper : MonoBehaviour
{

    [SerializeField]
    private Cell cell;

    [SerializeField]
    private Transform cellsParent;

    int cellsCount = 0;

    void Start ()   
    {
		for(int x = 0; x < GameGrid.GRID_DIMENSIONS; x++)
        {
            for (int z = 0; z < GameGrid.GRID_DIMENSIONS; z++)
            {
                Vector3 pos = new Vector3(x, 0, z);

                Cell newCell = Instantiate(cell, transform.position + pos, Quaternion.identity, cellsParent);
                newCell.cellXCoordinate = x;
                newCell.cellZCoordinate = z;
                newCell.gameObject.name = ("cell_" + cellsCount++);

            }
        }
	}
	
}
