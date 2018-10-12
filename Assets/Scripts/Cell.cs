using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cell : MonoBehaviour
{
    private GameObject visualCell;

    private GridObject objectOn;

	void Start ()
    {
        visualCell = transform.Find("displayableCell").gameObject;
    }
	
    public void Visualize(bool _isVisible)
    {
        if(visualCell == null)
        {
            visualCell = transform.Find("displayableCell").gameObject;
        }

        visualCell.SetActive(_isVisible);
    }

    public void SetObjectOn(GridObject _object)
    {
        objectOn = _object;
    }

    public void ClearCell()
    {
        objectOn = null;
    }

    public string GetCellData()
    {
        if (IsEmpty())
            return "cell is empty";
        else
            return "on this cell " + objectOn;

    }

    public bool IsVisualized()
    {
        return visualCell.activeSelf;
    }

    public bool IsEmpty()
    {
        return objectOn == null;
    }
}
