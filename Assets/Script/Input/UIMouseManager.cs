using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseModeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static MouseModeManager instance;
    MouseMode mouseMode;
    MouseState mouseState;
    public MouseState MouseState { get => mouseState; set => mouseState = value; }
    public MouseMode MouseMode { get => mouseMode; set => mouseMode = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            MouseMode = MouseMode.Build;
            MouseState = MouseState.Ready;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
     
  

}
