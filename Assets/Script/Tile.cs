using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

   GridManager gridManager;

    Vector2Int coordinates = new Vector2Int();

  /*  public bool GetIsPlaceable() {
        return isPlaceable;
    }*/
     private void Awake() {
        gridManager = FindAnyObjectByType<GridManager>();
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
        if (isPlaceable) {
            Vector3 placePosition = new Vector3(transform.position.x, 0, transform.position.z);
            isPlaceable = towerPrefab.CreateTower(towerPrefab,placePosition);
            isPlaceable = !isPlaceable;
     
         
        }
       
    }
}
