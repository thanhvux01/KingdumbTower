using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0,50)]int poolSize = 5;
    [SerializeField] [Range(0.1f,30f)]float SpawnTime = 1f;
    GameObject[] pool;
    private void Awake() {
        PopulatePool();
    }
    private void Start() {
        StartCoroutine(SpawnEnemy());
    }
    // Update is called once per frame
    void PopulatePool() {

        pool = new GameObject[poolSize];

        pool = new GameObject[poolSize]; 
        for(int i = 0; i < poolSize; i++) {
            pool[i] = Instantiate(enemy,transform);
            pool[i].SetActive(false);
        }
    }
    IEnumerator SpawnEnemy() {
        while (true) {
            EnableObjectInPool();
            yield return new WaitForSeconds(SpawnTime);
        }
    }
    private void EnableObjectInPool() {
        for(int i = 0;i < pool.Length;i++) { 
             if (pool[i].activeInHierarchy == false) {
                pool[i].SetActive(true);
                return;
            }
        }
    }



}
