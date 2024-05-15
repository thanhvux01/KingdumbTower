using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;

    }
    void Update()
    {
        gameObject.transform.LookAt(mainCamera.transform);
    }

}
