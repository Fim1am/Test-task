using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CellHelper : MonoBehaviour
{

    [SerializeField]
    private GameObject cell;

    [SerializeField]
    private Transform cellsParent;

    int cellsCount = 0;

    void Start ()   
    {
		for(int x = 0; x < GameGrid.GRID_DIMENSIONS; x++)
        {
            for (int y = 0; y < GameGrid.GRID_DIMENSIONS; y++)
            {
                Vector3 pos = new Vector3(x, 0, y);

                Instantiate(cell, transform.position + pos, Quaternion.identity, cellsParent).gameObject.name = ("cell_" + cellsCount++);

            }
        }
	}
	
}
