using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GridManager_ : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector2Int gridSize;
    Dictionary<Vector2Int,Block> grid = new Dictionary<Vector2Int,Block>();

    public Dictionary<Vector2Int,Block> Grid { get { return grid; } }
    void Awake()
    {
        InitMap();
    }
    
    // Update is called once per frame
    public Block GetBlock(Vector2Int coordinate) {
        if(grid.ContainsKey(coordinate)){
            return grid[coordinate];
        }
        return null;
    }
    void InitMap () {
        for(int i = 0;i<gridSize.x;i++){
             for(int j = 0;j<gridSize.y;j++){
                 Vector2Int newCoordinate = new Vector2Int(i,j);
                 Block newBlock =  new Block(newCoordinate,true);
                 grid.Add(newCoordinate,newBlock);
             }
        }
    }
}
