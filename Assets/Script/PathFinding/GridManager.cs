using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector2Int GridSize;

    [Tooltip("UnityEditor Gridsize if you're using raw position no need to use it")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize;}}    


    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }
    private void Awake() {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinates) {
        if(grid.ContainsKey(coordinates)){
              return grid[coordinates];
        }
        return null;
    }
    public void ResetNode(){
        foreach(KeyValuePair<Vector2Int,Node> entry in grid){
            entry.Value.connectedTo = null;
            entry.Value.isExplored = false;
            entry.Value.isPath = false;
        }
    }
    public void BlockNode(Vector2Int coordinates){
        if(grid.ContainsKey(coordinates)){
            grid[coordinates].isWalkable = false;
        }
    }
    
    public Vector2Int ConvertPositionToCoordinate(Vector3 position) {
       
       Vector2Int coordinates = new Vector2Int();

        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);

        return coordinates;
    }

       public Vector3 ConvertCoordinateToPosition(Vector2Int coordinates) {
       
       Vector3 position = new Vector3();

       position.x = coordinates.x * unityGridSize;
       position.z = coordinates.y * unityGridSize;

        return position;
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
                // Debug.Log(grid[coordinates].coordinates + "=" + grid[coordinates].isWalkable);
            }
        }
    }
}
