using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node 
{
    // Start is called before the first frame update
    public Vector2Int coordinates;
    public bool isSearchable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    public Node(Vector2Int coordinates,bool isSearchable) {
        this.coordinates = coordinates;
        this.isSearchable = isSearchable;
    }
 
}
