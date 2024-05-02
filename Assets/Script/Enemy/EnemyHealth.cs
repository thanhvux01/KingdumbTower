using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHP = 5;
    [Tooltip("Add amount to max maxHP when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] Material material;
    [SerializeField] GameObject corpse;
    
    Enemy enemy;
    Animator animator;
    ObjectPool objectPool;
    int currentHP = 0;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        objectPool = FindObjectOfType<ObjectPool>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        currentHP = maxHP;
    }
    private void OnParticleCollision(GameObject other)
    {

        ProcessHit();
    }

    void ProcessHit()
    {
        currentHP--;
        if (currentHP <= 0)
        {  
            maxHP += difficultyRamp;
            enemy.RewardGold();
            objectPool.GetKilled();
            gameObject.SetActive(false);
            CreateCorpse();
        }
    }
    void CreateCorpse()
    {
        Instantiate(corpse, transform.position,transform.rotation);
 
    }
}
