#if UNITY_EDITOR
using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = Color.green;   //new Color(0.0.0);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    GridManager gridManager;

    private void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager == null)
        {
            Debug.LogWarning("Can't find gridsystem for label tile");
        }
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {

            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }
        ColorizeCoordinate();
        ToggleLabel();

    }

    private void ColorizeCoordinate()
    {

        if (gridManager == null)
        {
            return;
        }

        Node node = gridManager.GetNode(coordinates);

        if (node == null)
        {   
            return;
        }

        if (!node.isWalkable)
        {
            label.color = blockedColor;
           
        }
        else if (node.isPath)
        {
            label.color = pathColor;

        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
           
        }
        else
        {
            label.color = defaultColor;
           
        }



    }
    private void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }


    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
    void DisplayCoordinates()
    {

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinates.x},{coordinates.y}";

    }
}
#endif
