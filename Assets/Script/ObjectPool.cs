using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Enemy enemy;
    [SerializeField][Range(0, 50)] int poolSize = 5;
    [SerializeField][Range(0.1f, 30f)] float SpawnTime = 1f;
    Enemy[] pool;
    private void Awake()
    {
        PopulatePool();
    }
    private void Start()
    {

        SpawnEnemy();
    }
    // Update is called once per frame
    void PopulatePool()
    {

        pool = new Enemy[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].gameObject.SetActive(false);
        }
    }
    void SpawnEnemy()
    {

        StartCoroutine(EnableObjectInPool());
    }
    IEnumerator EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].gameObject.activeInHierarchy == false)
            {
                pool[i].gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(SpawnTime);
        }
    }

    public void DisableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].gameObject.activeInHierarchy == true)
            {
                pool[i].gameObject.SetActive(false);

            }
        }
    }
    public void ResetEnemies()
    {
        StartCoroutine(ResetEnemiesLoop());
    }

    IEnumerator ResetEnemiesLoop()
    {

        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].gameObject.activeInHierarchy == true)
            {

      
               EnemyMovement enemy =  pool[i].GetComponent<EnemyMovement>();
               enemy.ResetEnemies();

            }
            yield return new WaitForSeconds(1f);
        }

    }
}

