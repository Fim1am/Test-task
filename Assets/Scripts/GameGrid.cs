using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameGrid : MonoBehaviour
{
    public const int GRID_DIMENSIONS = 19;

    private Cell[,] gridCells;

    public Cell[,] GridCells {
        get
            {
            if (gridCells == null)
                InitGrid();

            return gridCells;

            }
         }

    [SerializeField]
    private Cell[] cells;

    private bool isVisualized;

    public void DisplayingGrid()
    {
        isVisualized = !isVisualized;

        for(int i = 0; i < cells.Length; i++)
        {
            cells[i].Visualize(isVisualized);
        }
    }

    private void InitGrid()
    {
        gridCells = new Cell[GRID_DIMENSIONS, GRID_DIMENSIONS];

        for (int l = 0; l < GRID_DIMENSIONS; l++)
        {
            for (int w = 0; w < GRID_DIMENSIONS; w++)
            {
                GridCells[l, w] = cells[(l * GRID_DIMENSIONS) + w];
            }
        }
    }


}
