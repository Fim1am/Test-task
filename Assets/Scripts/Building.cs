using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : GridObject, IBuildeable
{
    [SerializeField]
    private Sprite lookSprite;

    [SerializeField]
    private int price;

    [SerializeField]
    private string objName;

    public DimensionData GetDimension()
    {
        return DimensionsData;
    }

    public Sprite GetImage()
    {
        return lookSprite;
    }

    public string GetName()
    {
        return objName;
    }

    public int GetPrice()
    {
        return price;
    }

    void Start ()
    {
		
	}

}
