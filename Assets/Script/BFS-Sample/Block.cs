using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Block 
{
    public Vector2Int coordinate;
    public Block connectedTo;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;

    public Block(Vector2Int coordinate,bool isWalkable) {
        this.coordinate = coordinate;
        this.isWalkable = isWalkable;
    }


    
}
