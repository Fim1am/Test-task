using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildeable
{
    Sprite GetImage();
    int GetPrice();
    DimensionData GetDimension();
    string GetName();
}
