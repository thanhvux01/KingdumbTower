using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barricades : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int totalBarricade = 0;
    public int TotalBarricade { get { return totalBarricade; } }
    [SerializeField] GameObject barricadePlaceholder; 
    [SerializeField] Wave wave;
    ObjectPool objectPool;
    [SerializeField] OrderPathfinder orderPathfinder;

    private void Awake()
    {
        CountBarricades();
    }

    private void CountBarricades()
    {
        foreach (Transform child in barricadePlaceholder.transform)
        {
            if (child.gameObject.activeSelf)
            {
                totalBarricade++;
            }
        }
    }


    public Barricade GetLastestBarricade()
    {

        foreach (Transform child in barricadePlaceholder.transform)
        {
            if (child.gameObject.activeSelf)
            {
                if (child.GetComponent<Barricade>() != null)
                {
                    return child.GetComponent<Barricade>();
                }
            }
        }
        return null;
    }
    public void BarricadeBeDestroyed()
    {

        totalBarricade--;
        if (orderPathfinder != null)
        {
            orderPathfinder.FindPath();
        }
        if (wave != null)
        {   
            //  StartCoroutine(objectPool.ResetEnemies());
            objectPool = FindAnyObjectByType<ObjectPool>();
            // Gan du lieu voi object pool hien tai
            objectPool.ResetEnemies();
        }
    }
}
