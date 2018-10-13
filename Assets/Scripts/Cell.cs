using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cell : MonoBehaviour
{
    private GameObject visualCell;

    private GridObject objectOn;

    [SerializeField]
    private Material visualMaterial, visualMaterialUnavailable, visualMaterialAvailable;

    [HideInInspector]
    public int cellXCoordinate, cellZCoordinate;

	void Start ()
    {
        visualCell = transform.Find("displayableCell").gameObject;
    }

    public void VisualizeAvailability(bool _available)
    {
        if (visualCell == null)
        {
            visualCell = transform.Find("displayableCell").gameObject;
        }

        if (_available)
            visualCell.GetComponent<MeshRenderer>().material = visualMaterialAvailable;
        else
            visualCell.GetComponent<MeshRenderer>().material = visualMaterialUnavailable;
    }

    public void Visualize(bool _isVisible)
    {
        if(visualCell == null)
        {
            visualCell = transform.Find("displayableCell").gameObject;
        }

        visualCell.GetComponent<MeshRenderer>().material = visualMaterial;

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

    public string GetCellInfo()
    {
        if (IsEmpty())
            return "cell is empty";
        else
            return "on this cell " + objectOn.name;

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
