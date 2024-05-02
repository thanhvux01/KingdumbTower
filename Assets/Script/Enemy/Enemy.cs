using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;
    
    
    ObjectPool objectPool;
    Eco eco;
    
    private void Awake()
    {
        eco = FindObjectOfType<Eco>();
        
    }
    public void RewardGold()
    {
        if (eco == null)
        {  
            Debug.Log("Can't find Eco ");
            return;
        }
        eco.Deposit(goldReward);
    }
    public void GoldPenalty()
    {
        if (eco == null)
        {   
            Debug.Log("Can't find Eco ");
            return;
        }
        eco.Withdraw(goldPenalty);
    }

    public void ReachedEnd()
    {
        GoldPenalty();
        gameObject.SetActive(false);
        objectPool = FindAnyObjectByType<ObjectPool>();
        objectPool.GetKilled();
        
    }


}
