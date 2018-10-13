using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GridObject buideableObj;

    [SerializeField]
    private Image buildingImage;

    [SerializeField]
    private Text priceText, nameText;

    private void Start()
    {
        buildingImage.sprite = (buideableObj as IBuildeable).GetImage();
        priceText.text = (buideableObj as IBuildeable).GetPrice().ToString();
        nameText.text = (buideableObj as IBuildeable).GetName();
    }


    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        FindObjectOfType<GameCanvas>().gameObject.AddComponent<BuildingController>().SetObjectToBuild(buideableObj);
    }
}
