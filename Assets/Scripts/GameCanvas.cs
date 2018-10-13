using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{

    [SerializeField]
    private GameObject buildingsPanel, upgradesPanel, shopPanel;

    [SerializeField]
    private GameObject buidingImagePrefab;

    public Transform CreateBuildingImage(IBuildeable _object)
    {
        Image img = Instantiate(buidingImagePrefab, transform).gameObject.GetComponent<Image>();
        img.sprite = _object.GetImage();

        return img.transform;
    }
	
    public void GridButton()
    {
        FindObjectOfType<GameGrid>().DisplayingGrid();
    }

    public void CloseAllPanels()
    {
        upgradesPanel.SetActive(false);
        shopPanel.SetActive(false);
        buildingsPanel.SetActive(false);
    }

    public void ShopButton()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
        buildingsPanel.SetActive(false);
        upgradesPanel.SetActive(false);
    }

    public void BuildingsButton()
    {
        buildingsPanel.SetActive(!buildingsPanel.activeSelf);
        upgradesPanel.SetActive(false);
        shopPanel.SetActive(false);
    }

    public void UpgradesButton()
    {
        upgradesPanel.SetActive(!upgradesPanel.activeSelf);
        buildingsPanel.SetActive(false);
        shopPanel.SetActive(false);
    }
}
