using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseModeManager : MonoBehaviour
{
    // Start is called before the first frame update
    MouseMode mouseMode;

    public MouseMode MouseMode { get { return mouseMode; } set { mouseMode = value; } }

    private void Awake()
    {
        mouseMode = MouseMode.Build;
    }

}
