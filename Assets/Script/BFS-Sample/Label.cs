using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[ExecuteAlways]
public class Label : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text text;

    [SerializeField] Color blockedColor = Color.red;

    [SerializeField] Color defaultColor = Color.white;

    [SerializeField] Color pathColor = Color.green;

    [SerializeField] Color isExploredColor = Color.yellow;
    Vector2Int coordinate = new Vector2Int();

    GridManager_ grid;
    void Awake()
    {
        grid = FindObjectOfType<GridManager_>();
             
    }

    void Start() {
        grid = FindObjectOfType<GridManager_>();
        ShowCoordinate();
        ColorizeLabel();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void ColorizeLabel()
    {   
        Block block = grid.GetBlock(coordinate);
        
        if (block == null) { return; };
        if (!block.isWalkable)
        {
            text.color = blockedColor;
        }
        else if (block.isPath)
        {
            text.color = pathColor;

        }else if(block.isExplored){

            text.color = isExploredColor;
        }
        else
        {
            text.color = defaultColor;
        }

    }
    void ShowCoordinate()
    {
        if (text != null)
        {
            coordinate.x = Mathf.RoundToInt(transform.position.x);
            coordinate.y = Mathf.RoundToInt(transform.position.z);
            text.SetText($"{coordinate.x}/{coordinate.y}");
        }

    }
}
