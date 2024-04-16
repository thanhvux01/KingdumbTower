using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHP = 5;
    [Tooltip("Add amount to max maxHP when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    Enemy enemy;
    int currentHP = 0;

    private void Start() {
        enemy = GetComponent<Enemy>();
    }
    private void OnEnable() {
        currentHP = maxHP;
    }
    private void OnParticleCollision(GameObject other) {
    
        ProcessHit();
    }

    void ProcessHit() {
        currentHP--;
        if(currentHP <= 0) {
              maxHP += difficultyRamp;
              gameObject.SetActive(false);
              enemy.RewardGold();
        
        }
    }
}
