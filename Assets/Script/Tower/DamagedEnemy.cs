using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int numberDamage;
    [SerializeField] string effect;
    public DamageStat damageStat;
    void Awake()
    {
        damageStat = new DamageStat(numberDamage,effect);
    }

    
    
}
