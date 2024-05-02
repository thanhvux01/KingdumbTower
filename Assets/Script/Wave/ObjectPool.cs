using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Pool[] pools;
    public int currentEnemies = 0;
    public int CurrentEnemies { get { return currentEnemies; } }
    
    Wave wave;
    Enemy[,] enemies = new Enemy[10, 10];
    private void Awake()
    {
        wave = FindObjectOfType<Wave>();
        PopulatePool();

    }
    private void Start()
    { 
        SpawnEnemy();
    }
    // Update is called once per frame
    void PopulatePool()
    {

        for (int i = 0; i < pools.Length; i++)
        {

            for (int j = 0; j < pools[i].quantity; j++)
            {

                enemies[i, j] = Instantiate(pools[i].enemy, transform);
                enemies[i, j].gameObject.SetActive(false);
                currentEnemies++;
            }
        }
    }
    void SpawnEnemy()
    {
        StartCoroutine(EnableObjectInPool());
    }
    IEnumerator EnableObjectInPool()
    {
        for (int i = 0; i < pools.Length; i++)
        {

            for (int j = 0; j < pools[i].quantity; j++)
            {
                if (enemies[i, j].gameObject.activeInHierarchy == false)
                {
                    enemies[i, j].gameObject.SetActive(true);
                }
                yield return new WaitForSeconds(pools[i].spawnTime);
            }

        }
    }
    public void ResetEnemies()
    {
        StartCoroutine(ResetEnemiesLoop());
    }
    public void GetKilled()
    {
        currentEnemies--;
        if (currentEnemies <= 0)
        {
            wave.GoNextWave();
        }
    }
    IEnumerator ResetEnemiesLoop()
    {

        for (int i = wave.CurrentWave; i < pools.Length; i++)
        {

            for (int j = 0; j < pools[i].quantity; j++)
            {
                if (enemies[i, j])
                {
                    if (enemies[i, j].gameObject.activeInHierarchy == true)
                    {

                        EnemyMovement enemy = enemies[i, j].GetComponent<EnemyMovement>();
                        enemy.ResetEnemies();
                    }
                }
                yield return new WaitForSeconds(.2f);
            }

        }

    }
}

