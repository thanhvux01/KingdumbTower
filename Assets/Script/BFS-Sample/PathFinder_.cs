using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder_ : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector2Int startCoord;
    [SerializeField] Vector2Int endCoord;

    Block startBlock;

    Block endBlock;
    Block currentBlock;
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

    // List<Block> neighbors = new List<Block>();
    //put neighbor here cause stacking 
    
    Dictionary<Vector2Int,bool> neigborsChecked = new Dictionary<Vector2Int, bool>();

    List<Block> diplomacy = new List<Block>();

  
    GridManager_ grid;
    void Awake()
    {
        grid = FindObjectOfType<GridManager_>();
    }

    void Start()
    {

        startBlock = grid.GetBlock(startCoord);
        endBlock = grid.GetBlock(endCoord);
        BFS();
        BuildPath();

    }

    void FindingNeighbor(Block block)
    {   
         List<Block> neighbors = new List<Block>();

        foreach (Vector2Int direction in directions)

        {
            Vector2Int neighborCoord = block.coordinate + direction;
            //kiem tra nhung o xung quanh co hop le hay khong
            Block neighborBlock = grid.GetBlock(neighborCoord);
            if (neighborBlock != null)
            {
                neighbors.Add(neighborBlock);
                
            }

        }
        Check(neighbors);
    }

    void Check(List<Block> neighbors)
    {
        foreach (Block neighbor in neighbors)
        {

            //kiem tra hang xom co di duoc khong va them vao danh sach da kiem tra 
             if(!neigborsChecked.ContainsKey(neighbor.coordinate) && neighbor.isWalkable ) {
                 //them vao danh sach ngoai giao
                 diplomacy.Add(neighbor);
                 //connect den node da xuat phat ban dau
                 neighbor.connectedTo = currentBlock;
                 // danh dau la da kham pha
                 neighbor.isExplored = true;      
                 //them vao danh sach da kiem tra    
                neigborsChecked[neighbor.coordinate] = true;     

             }
        }
    }

    void BFS()
    {
        bool isRunning = true;
        diplomacy.Add(startBlock);
        neigborsChecked.Add(startBlock.coordinate,true);        
        //fix infinite loop , goc ban dau khong duoc co diem ket noi

        while (diplomacy.Count > 0 && isRunning)
        {    
             currentBlock = diplomacy[0];
           
             diplomacy.RemoveAt(0);
             

            FindingNeighbor(currentBlock);

            if (currentBlock.coordinate == endBlock.coordinate)
            {
                isRunning = false;
            }
        }
    }

    void BuildPath () {
        List<Block> path = new List<Block>();
        Block currentBlock = endBlock;
        while (currentBlock.connectedTo != null)
        {
              path.Add(currentBlock.connectedTo);
              currentBlock.isPath = true;
              currentBlock = currentBlock.connectedTo;

        }
        path.Add(currentBlock);
       
    }
}
