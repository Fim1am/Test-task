using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingController : MonoBehaviour
{

    private GridObject objectToBuild;
	
	
    public void SetObjectToBuild(GridObject _object)
    {
        objectToBuild = _object;
    }


	void Update ()
    {
        if (objectToBuild == null)
            return;
	}
}
