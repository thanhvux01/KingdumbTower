using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHP = 5;
    [SerializeField] TextMeshProUGUI hp_text;
    [SerializeField] Transform hp_text_placeholder;

    [SerializeField] Image hp_bar;
    [Tooltip("Add amount to max maxHP when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] Material material;
    [SerializeField] GameObject corpse;

    Enemy enemy;
    ObjectPool objectPool;
    int currentHP = 0;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        objectPool = FindObjectOfType<ObjectPool>();
       

    }
    private void OnEnable()
    {
        currentHP = maxHP;
        hp_bar.fillAmount = 1;
    }
    private void OnParticleCollision(GameObject other)
    {
        DamagedEnemy damage = other.gameObject.GetComponent<DamagedEnemy>();
        if (damage != null)
        {
            int numberDamage = damage.damageStat.numberDamage;
            currentHP -= numberDamage;
            HPTextProcess(Instantiate(hp_text, hp_text_placeholder), numberDamage);
            ProcessHit();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        DamagedEnemy damage = other.gameObject.GetComponent<DamagedEnemy>();
        if (damage != null)
        {
            int numberDamage = damage.damageStat.numberDamage;
            currentHP -= numberDamage;
            HPTextProcess(Instantiate(hp_text, hp_text_placeholder), numberDamage);
            ProcessHit();
        }

    }
    private void HPTextProcess(TextMeshProUGUI text, int number)
    {
        text.SetText("-" + number);
    }
    void ProcessHit()
    {

        hp_bar.fillAmount = (float)currentHP / maxHP;
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
        Instantiate(corpse, transform.position, transform.rotation);

    }

    
}
