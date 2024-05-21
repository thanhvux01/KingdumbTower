using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    Tower towerPrefab;
    [SerializeField] bool isPlaceable;

    [SerializeField] bool isBarricaded;
    public bool IsPlaceable { get { return isPlaceable; } }
    public bool IsBarricaded { get { return isBarricaded; } set { isBarricaded = value; } }
    GridManager gridManager;
    TowerManager towerManager;
    Vector2Int coordinates = new Vector2Int();

    /*  public bool GetIsPlaceable() {
          return isPlaceable;
      }*/
    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        towerManager = FindObjectOfType<TowerManager>();
    }
    private void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.ConvertPositionToCoordinate(transform.position);
            
            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && towerManager)
        {
            if (MouseModeManager.instance.MouseState == MouseState.Ready)
            {
                bool isPlaced = towerManager.CreateTower(new Vector3(transform.position.x, 0, transform.position.z));
                isPlaceable = !isPlaced;
                gridManager.BlockNode(coordinates);
                return;
            }
        }
        Debug.LogWarning("Can't find tower manager or your node is blocked");

    }
}
