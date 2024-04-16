using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int cost = 75;
    GameObject towerPlaceHolder;
    
    public bool CreateTower(Tower tower,Vector3 position) {
        towerPlaceHolder = GameObject.FindGameObjectWithTag("TowerPlaceHolder");

        Eco eco = FindAnyObjectByType<Eco>();

        if (eco == null) {

            return false;

        }

        if(eco.CurrentBalance >= cost) {
            GameObject towerInstance = Instantiate(tower.gameObject, position, Quaternion.identity);
            eco.Withdraw(cost);
            towerInstance.transform.parent = towerPlaceHolder.transform;
            return true;

        }

        return false;
      
    }
}
