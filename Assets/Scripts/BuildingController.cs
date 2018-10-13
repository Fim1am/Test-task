using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingController : MonoBehaviour
{
    private GridObject objectToBuild;

    private Transform objectImage;

    private GameObject camContainer;

    private ScrollRect[] scrollRects;

    private GameGrid gameGrid;

    private List<Cell> touchedCells;

    private int spawnZ, spawnX;

    private bool canSpawn;

    private float dragOffset = 50f, offsetMultiplier = 60f;
    Vector3 mousePosition;

    private void Start()
    {
        dragOffset = dragOffset / Screen.height * offsetMultiplier;
        touchedCells = new List<Cell>();
        camContainer = FindObjectOfType<CameraMotor>().gameObject;
        scrollRects = FindObjectsOfType<ScrollRect>();
        gameGrid = FindObjectOfType<GameGrid>();
    }

    public void SetObjectToBuild(GridObject _object)
    {
        objectToBuild = _object;
        objectImage = GetComponent<GameCanvas>().CreateBuildingImage(_object as IBuildeable);
    }


    void Update()
    {
        mousePosition = Input.mousePosition;

        mousePosition += Vector3.up * dragOffset;

#if (UNITY_ANDROID && !UNITY_EDITOR) || (UNITY_IPHONE && !UNITY_EDITOR)
        mousePosition += Vector3.up * dragOffset * 75;
#endif

        Debug.Log(mousePosition + "  " + Input.mousePosition);

        if (objectToBuild == null)
            return;

        if (objectImage != null && Input.GetMouseButton(0))
        {
            objectImage.transform.position = mousePosition;

            for (int i = 0; i < scrollRects.Length; i++)
                scrollRects[i].enabled = false;

            if(!gameGrid.IsGridVisualized)
            {
                gameGrid.DisplayingGrid(true);
            }

           
            GridChecking();
            

            Destroy(camContainer.GetComponent<CameraMotor>());
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                Destroy(this);
                return;
            }

            if(canSpawn)
            {

                Debug.Log(canSpawn + "btnUp");
                FindObjectOfType<Ground>().SpawnObject(spawnZ, spawnX, objectToBuild);
                Destroy(this);
            }
            else
            {
                Destroy(this);
            }

        }

    }

    private void GridChecking()
    {
        touchedCells.ForEach(c => c.Visualize(true));

        touchedCells.Clear();

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Cell cell = hit.transform.GetComponent<Cell>();

            if (cell != null)
            {
                int cellX = cell.cellXCoordinate, cellZ = cell.cellZCoordinate;

                for (int oLv = 0; oLv < objectToBuild.DimensionsData.gridSize; oLv++)       
                    for (int oWv = 0; oWv < objectToBuild.DimensionsData.gridSize; oWv++)
                    {
                        touchedCells.Add(gameGrid.GridCells[cellZ + oLv, cellX + oWv]);

                        if(!objectToBuild.DimensionsData.GetCells()[oLv, oWv] || gameGrid.GridCells[cellZ + oLv, cellX + oWv].IsEmpty() == objectToBuild.DimensionsData.GetCells()[oLv, oWv])
                            gameGrid.GridCells[cellZ + oLv, cellX + oWv].VisualizeAvailability(true);
                        else
                            gameGrid.GridCells[cellZ + oLv, cellX + oWv].VisualizeAvailability(false);
                    }

                for (int oL = 0; oL < objectToBuild.DimensionsData.gridSize; oL++)
                {
                    for (int oW = 0; oW < objectToBuild.DimensionsData.gridSize; oW++)
                    {

                        if (cellZ + oL >= GameGrid.GRID_DIMENSIONS || cellX + oW >= GameGrid.GRID_DIMENSIONS)
                        {
                            canSpawn = false;
                            return;
                        }

                        if (!objectToBuild.DimensionsData.GetCells()[oL, oW] || gameGrid.GridCells[cellZ + oL, cellX + oW].IsEmpty() == objectToBuild.DimensionsData.GetCells()[oL, oW])
                        {

                            if (oL == objectToBuild.DimensionsData.gridSize - 1 && oW == objectToBuild.DimensionsData.gridSize - 1)
                            {
                               // touchedCells.ForEach(c => c.Visualize(true));
                                spawnX = cellX;
                                spawnZ = cellZ;
                                canSpawn = true;
                                return;
                            }
                        }
                        else
                        {
                            gameGrid.GridCells[cellZ + oL, cellX + oW].VisualizeAvailability(false);
                            canSpawn = false;
                            return;
                        }
                    }
                }
            }
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < scrollRects.Length; i++)
            scrollRects[i].enabled = true;

        camContainer.AddComponent<CameraMotor>();
        gameGrid.DisplayingGrid(false);
        Destroy(objectImage.gameObject);
    }
}