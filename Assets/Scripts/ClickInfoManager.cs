using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInfoManager : MonoBehaviour
{
	
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Cell cell = hit.transform.GetComponent<Cell>();

                if (cell != null)
                {
                    Debug.Log("cell coordinates " + cell.cellXCoordinate + " / " + cell.cellZCoordinate 
                        + "-- "+ cell.GetCellInfo() +" --");
                }
            }
        }

    }
}
