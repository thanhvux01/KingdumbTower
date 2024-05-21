using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] Vector2 limitXOffset = new Vector2(-300, 300);
    [SerializeField] Vector2 limitZOffset = new Vector2(100, 100);
    // Update is called once per frame
    void Update()
    {

        // float verticalInput = Input.GetAxis("Vertical");
        // float horizontalInput = Input.GetAxis("Horizontal");
        // if (verticalInput != 0)
        // {
        //     float offset = Mathf.Clamp(transform.localPosition.z + (verticalInput * speed * Time.deltaTime), limitZOffset.x, limitZOffset.y);
        //     transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, offset);
        // }
        // if (horizontalInput != 0)
        // {
        //     float offset = Mathf.Clamp(transform.localPosition.x + (horizontalInput * speed * Time.deltaTime), limitXOffset.x, limitXOffset.y);
        //     transform.localPosition = new Vector3(offset, transform.localPosition.y, transform.localPosition.z);
        // }
        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log(verticalInput);

    }
}
