using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    public static ObjectsManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != this)
        {
            Instance = this;
        }
    }

    [SerializeField]
    private GridObject[] unusedZoneObjects; // prefabs

    private List<GridObject> buildableObjects; // prefabs
	
    public GridObject GetRandomUnused()
    {
        return unusedZoneObjects[Random.Range(0, unusedZoneObjects.Length)];
    }

    public GridObject GetObjectById(int _id)
    {
        return buildableObjects.Find(o => o.Id == _id);
    }


}
