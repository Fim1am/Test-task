using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
    public void GridButton()
    {
        FindObjectOfType<GameGrid>().DisplayingGrid();
    }
}
