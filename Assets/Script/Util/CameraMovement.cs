using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] Vector2 limitXOffset = new Vector2(-300, 300);
    [SerializeField] Vector2 limitZOffset = new Vector2(100, 100);
    enum ZoomMode
    {
        Low = 45,
        Medium = 55,
        High = 65,
    }

    ZoomMode currentZoom;
    private void Start()
    {
        currentZoom = ZoomMode.Low;
    }
    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        if (verticalInput != 0)
        {
            float offset = Mathf.Clamp(transform.localPosition.z + (verticalInput * speed * Time.deltaTime), limitZOffset.x, limitZOffset.y);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, offset);
        }
        if (horizontalInput != 0)
        {
            float offset = Mathf.Clamp(transform.localPosition.x + (horizontalInput * speed * Time.deltaTime), limitXOffset.x, limitXOffset.y);
            transform.localPosition = new Vector3(offset, transform.localPosition.y, transform.localPosition.z);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (currentZoom)
            {
                case ZoomMode.Low:
                    currentZoom = ZoomMode.Medium;
                    break;
                case ZoomMode.High:
                    currentZoom = ZoomMode.Low;
                    break;
                case ZoomMode.Medium:
                    currentZoom = ZoomMode.High;
                    break;
            }
            transform.localPosition = new Vector3(transform.localPosition.x, (int)currentZoom, transform.localPosition.z);
        }


    }
}
