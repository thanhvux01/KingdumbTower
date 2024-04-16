using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Eco eco;

    private void Start() {
        eco = FindObjectOfType<Eco>();

    }
    public void RewardGold() {
        if (eco == null) {
            return;
        }
        eco.Deposit(goldReward);
    }
    public void GoldPenalty() {
        if (eco == null) {
            return;
        }
        eco.Withdraw(goldPenalty);
    }

}
