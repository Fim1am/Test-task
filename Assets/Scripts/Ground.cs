using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{ 
    [Range(0, 10)]
    public int UNUSED_ZONE_WIDTH = 6;

    [SerializeField]
    private GameGrid gameGrid;

    private Transform objectsStorage;
    
	
	void Start ()
    {
        objectsStorage = GameObject.FindGameObjectWithTag("ObjectsStorage").transform;
        GenerateUnusedZone();
	}

    private void GenerateUnusedZone()
    {
        bool nextCell = false;

        for(int x = 0; x < GameGrid.GRID_DIMENSIONS; x++)
        {
            for(int z = 0; z < GameGrid.GRID_DIMENSIONS; z++)
            {

                nextCell = false;

                if((x < UNUSED_ZONE_WIDTH ) || (x > GameGrid.GRID_DIMENSIONS - UNUSED_ZONE_WIDTH - 1) || (z < UNUSED_ZONE_WIDTH) || (z > GameGrid.GRID_DIMENSIONS - UNUSED_ZONE_WIDTH - 1))
                {

                    if (gameGrid.GridCells[z, x].IsEmpty())
                    {
                        GridObject go = ObjectsManager.Instance.GetRandomUnused();

                        for(int oL = 0; oL < go.DimensionsData.gridSize; oL++) // iterate through object dimensions ( lenght and width)
                        {
                            for(int oW = 0; oW < go.DimensionsData.gridSize; oW++)
                            {
                                if(z + oL >= GameGrid.GRID_DIMENSIONS || x + oW >= GameGrid.GRID_DIMENSIONS)
                                {
                                    continue;
                                }

                                if (!go.DimensionsData.GetCells()[oL, oW] || gameGrid.GridCells[z + oL, x + oW].IsEmpty() == go.DimensionsData.GetCells()[oL, oW]) // check all cell that need for object spawn
                                {
                                    if(oL == go.DimensionsData.gridSize - 1 && oW == go.DimensionsData.gridSize - 1) // check if we have enough room then spawn an object
                                    {
                                        SpawnObject(z, x, go);
                                    }
                                }
                                else
                                {
                                    nextCell = true;
                                }
                            }

                            if (nextCell) break;
                        }
                    }              
                }
            }
        }
    }

    public void SpawnObject(int _z, int _x, GridObject _go)
    {
        for (int oL = 0; oL < _go.DimensionsData.gridSize; oL++) // iterate through object dimensions ( lenght and width)
        {
            for (int oW = 0; oW < _go.DimensionsData.gridSize; oW++)
            {
                gameGrid.GridCells[_z + oL, _x + oW].SetObjectOn(_go);
            }
        }

        Instantiate(_go, gameGrid.GridCells[_z, _x].transform.position, Quaternion.identity, objectsStorage);
        Debug.Log(_z + "z /" + _x + "x" + " - go " + _go.name);
    }
	
}
