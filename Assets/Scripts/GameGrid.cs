using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameGrid : MonoBehaviour
{

    [SerializeField]
    private GameObject visualGrid;

    [SerializeField]
    private CellsLine[] rowsWidth;

    [SerializeField]
    private CellsLine[] rowsLength;

    [SerializeField]
    private Cell[] cells;

    private int gridDimension = 18;

    public void DisplayingGrid()
    {
        visualGrid.SetActive(!visualGrid.activeSelf);
    }

}


[System.Serializable]
class CellsLine
{
    public Cell[] cells = new Cell[18];
}
