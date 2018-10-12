using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{ 
    public int UNUSED_ZONE_WIDTH = 7;

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

        for(int z = 0; z < GameGrid.GRID_DIMENSIONS; z++)
        {
            for(int x = 0; x < GameGrid.GRID_DIMENSIONS; x++)
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

                                if (gameGrid.GridCells[z, x] != null && !gameGrid.GridCells[z + oL, x + oW].IsEmpty() == go.DimensionsData.GetCells()[oL, oW]) // check all cell that need for object spawn
                                {
                                    nextCell = true;
                                }
                                else
                                {
                                    if(oL == go.DimensionsData.gridSize - 1 && oW == go.DimensionsData.gridSize - 1) // check if we have enough room then spawn an object
                                    {
                                        SpawnObject(z, x, go);
                                    }
                                }
                            }

                            if (nextCell) break;
                        }
                    }              
                }
            }
        }
    }

    private void SpawnObject(int _z, int _x, GridObject _go)
    {
        for (int oL = 0; oL < _go.DimensionsData.gridSize; oL++) // iterate through object dimensions ( lenght and width)
        {
            for (int oW = 0; oW < _go.DimensionsData.gridSize; oW++)
            {
                gameGrid.GridCells[_z + oL, _x + oW].SetObjectOn(_go);
            }
        }

        Instantiate(_go, gameGrid.GridCells[_z, _x].transform.position, Quaternion.identity, objectsStorage);
    }
	
}
