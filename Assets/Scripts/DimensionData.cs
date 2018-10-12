using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dimension_Data", menuName = "Grid/DimensionData")]
public class DimensionData : ScriptableObject
{
    private const int defaultGridSize = 3;

    [Range(1, 5)]
    public int gridSize = defaultGridSize;

    public CellRow[] cells = new CellRow[defaultGridSize];


    public bool[,] GetCells()
    {
        bool[,] ret = new bool[gridSize, gridSize];

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                ret[i, j] = cells[i].row[j];
            }
        }

        return ret;
    }

    /// <summary>
    /// Just an example, you can remove this.
    /// </summary>
    public int GetCountActiveCells()
    {
        int count = 0;

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (cells[i].row[j]) count++;
            }
        }

        return count;
    }


    [System.Serializable]
    public class CellRow
    {
        public bool[] row = new bool[defaultGridSize];
    }
}
