using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
    [SerializeField]
    private GridObject buideableObj;

    [SerializeField]
    private Image buildingImage;

    [SerializeField]
    private Text priceText;

    private void Start()
    {
        buildingImage.sprite = (buideableObj as IBuildeable).GetImage();
        priceText.text = (buideableObj as IBuildeable).GetPrice().ToString();
    }



    public void RequestBuilding()
    {

    }
}
