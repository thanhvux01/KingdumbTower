using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;
    
    [SerializeField] int livePentalty = 1;

    ObjectPool objectPool;
    Eco eco;

    Live live;

    private void Awake()
    {
        eco = FindObjectOfType<Eco>();
        live = FindObjectOfType<Live>();


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
            Debug.Log("Can't find Eco class");
            return;
        }
        eco.Withdraw(goldPenalty);
    }

    public void LivePentalty()
    {
        if (live == null)
        {
            Debug.Log("Can't find live class ");
            return;
        }
        live.LoseLive(livePentalty);
    }

    public void ReachedEnd()
    {
        GoldPenalty();
        LivePentalty();
        gameObject.SetActive(false);
        objectPool = FindAnyObjectByType<ObjectPool>();
        objectPool.GetKilled();

    }


}
