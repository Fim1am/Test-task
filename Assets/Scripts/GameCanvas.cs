using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{

    [SerializeField]
    private GameObject buildingsPanel, upgradesPanel, shopPanel;
	
	void Start ()
    {
		
	}
	
    public void GridButton()
    {
        FindObjectOfType<GameGrid>().DisplayingGrid();
    }

    public void ShopButton()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }

    public void BuildingsButton()
    {
        buildingsPanel.SetActive(!buildingsPanel.activeSelf);
    }

    public void UpgradesButton()
    {
        upgradesPanel.SetActive(!upgradesPanel.activeSelf);
    }
}
