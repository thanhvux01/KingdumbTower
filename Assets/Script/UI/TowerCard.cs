using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class TowerCard : MonoBehaviour
{
    [SerializeField] Tower tower;

    [SerializeField] Color color = new Color(0, 0, 0, 0);
    [SerializeField] Color selectColor = new Color(0, 0, 0, 0);
    TowerManager towerManager;

    Image image;



    // Start is called before the first frame update

    void Awake()
    {
        towerManager = FindObjectOfType<TowerManager>();
        image = GetComponent<Image>();
        if (towerManager == null)
        {
            Debug.LogWarning("Can't find tower manager , plz check scene");
        }
        if (image == null)
        {
            Debug.LogWarning("Can't find image component , plz check gameobject");
        }
    }

    private void Start()
    {
        if (image != null)
        {
            image.color = color;
            if (towerManager.CurrentTower.towerName == tower.towerName)
            {
                image.color = selectColor;
            }
        }

    }


    public void OnClick()
    {
        MouseModeManager.instance.MouseMode = MouseMode.Build;
        if (towerManager && tower)
        {
            towerManager.ChangeCurrentTower(tower);
            image.color = selectColor;
            return;
        }
        Debug.LogWarning("Plz check your tower variant and tower manager");
    }

    public void UnSelectColor()
    {
        if (image != null)
        {
            image.color = color;
        }
    }

    public void EnterHover()
    {
        MouseModeManager.instance.MouseState = MouseState.NotReady;
    }

    public void ExitHover()
    {
        MouseModeManager.instance.MouseState = MouseState.Ready;

    }
}

