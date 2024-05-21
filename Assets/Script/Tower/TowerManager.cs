using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Tower defaultTower;
    [SerializeField] Tower currentTower;
    [SerializeField] List<TowerCard> towerCards;
    GameObject towerPlaceHolder;
    MouseModeManager mouseModeManager;
    public Tower CurrentTower { get { return currentTower; } set { currentTower = value; } }
    void Awake()
    {
        mouseModeManager = FindObjectOfType<MouseModeManager>();
        if (defaultTower)
        {
            currentTower = defaultTower;
        }
        else
        {
            Debug.LogWarning("default tower not found , plz select card before place it");
        }
    }

    public bool CreateTower(Vector3 position)
    {
        if (mouseModeManager.MouseMode == MouseMode.Build)
        {
            towerPlaceHolder = GameObject.FindGameObjectWithTag("TowerPlaceHolder");

            Eco eco = FindAnyObjectByType<Eco>();

            if (eco == null)
            {

                return false;

            }

            if (eco.CurrentBalance >= currentTower.cost)
            {
                GameObject towerInstance = Instantiate(currentTower.gameObject, position, Quaternion.identity);
                eco.Withdraw(currentTower.cost);
                towerInstance.transform.parent = towerPlaceHolder.transform;
                return true;

            }

            return false;

        }
        return false;
    }

    public void ChangeCurrentTower(Tower tower)
    {   
        Debug.Log("here");
        if (currentTower != tower)
        {
            currentTower = tower;
            foreach (TowerCard card in towerCards)
            {
                card.UnSelectColor();
            }
        }


    }

}
