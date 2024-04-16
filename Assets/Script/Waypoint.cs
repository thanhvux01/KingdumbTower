using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

  /*  public bool GetIsPlaceable() {
        return isPlaceable;
    }*/
    private void OnMouseDown() {
        if (isPlaceable) {
            Vector3 placePosition = new Vector3(transform.position.x, 0, transform.position.z);
            isPlaceable = towerPrefab.CreateTower(towerPrefab,placePosition);
            isPlaceable = !isPlaceable;
     
         
        }
       
    }
}
