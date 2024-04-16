using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;
    private void Awake() {

        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying) {
            DisplayCoordinates();
            UpdateObjectName();
        }
        StyleCoordinate();
        ToggleLabel();
    }

    private void StyleCoordinate() {
        if(waypoint.IsPlaceable) {
            label.color = defaultColor;
        }
        else {
            label.color = blockedColor;
        }
    }
    private void ToggleLabel() {
        if(Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.enabled;
            
        }
    }
    private void UpdateObjectName() {
        transform.parent.name = coordinates.ToString();
    }
    void DisplayCoordinates() {

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = $"{coordinates.x},{coordinates.y}";
    }
}
