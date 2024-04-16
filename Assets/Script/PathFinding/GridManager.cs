using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector2Int GridSize;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake() {
        CreateGrid();
    }
    private void CreateGrid() {

        for(int x =0; x < GridSize.x;x++) {
            for(int y =0; y < GridSize.y;y++) {

                Vector2Int coordinates = new Vector2Int(x,y);
                grid.Add(coordinates, new Node(coordinates,true));
                //jsobject grid:{"x,y,z":{
                           //coordinate:"x,y,z"
                           //isSearchable:"true"
                //}}
                Debug.Log(grid[coordinates].coordinates + "=" + grid[coordinates].isSearchable);
            }
        }
    }
}
