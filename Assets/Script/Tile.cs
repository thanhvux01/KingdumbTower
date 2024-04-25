using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable;

    [SerializeField] bool isBarricaded;
    public bool IsPlaceable { get { return isPlaceable; } }
    public bool IsBarricaded { get { return isBarricaded; } set { isBarricaded = value;}}
   GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

  /*  public bool GetIsPlaceable() {
        return isPlaceable;
    }*/
     private void Awake() {
        gridManager = FindObjectOfType<GridManager>();
     }
    private void Start() {
        if(gridManager != null) {
            coordinates = gridManager.ConvertPositionToCoordinate(transform.position);
            if(!isPlaceable){
                gridManager.BlockNode(coordinates);
            }
        }
    }
 
    private void OnMouseDown() {
        if (gridManager.GetNode(coordinates).isWalkable) {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab,new Vector3(transform.position.x,0,transform.position.z));
            isPlaceable = !isPlaced;
            gridManager.BlockNode(coordinates);
        }
       
    }
}
