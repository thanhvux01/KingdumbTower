using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Tower defaultTower;
    [SerializeField] Tower currentTower;
    public Tower CurrentTower { get { return currentTower; } set { currentTower = value; } }
    void Start()
    {
        if (defaultTower)
        {
            currentTower = defaultTower;
        }
        else
        {
            Debug.LogWarning("default tower not found , plz select card before place it");
        }
    }
}
