using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class TowerCard : MonoBehaviour
{
    [SerializeField] Tower tower;

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
      
    }

    public void OnClick()
    {   
        if (towerManager && tower)
        {
            towerManager.CurrentTower = tower;
            return;
        }
        Debug.LogWarning("Plz check your tower variant and tower manager");
    }
}

