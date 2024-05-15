using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Only One Object Pool at the same time , it's object pool will spawn enemy in the current wave")]
    [SerializeField] int currentWave = 0;
    [SerializeField] StageLabel stageLabel;
    public int CurrentWave { get { return currentWave; } }

    //Need to run after pool instantiate all enemies
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == currentWave)
            {
                Transform childTransform = transform.GetChild(i);
                childTransform.gameObject.SetActive(true);
            }
            else
            {
                Transform childTransform = transform.GetChild(i);
                childTransform.gameObject.SetActive(false);
            }

        }
    }
    public void GoNextWave()
    {

        currentWave++;  
        stageLabel.NewWaveLabel(currentWave);

        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == currentWave)
            {
                Transform childTransform = transform.GetChild(i);
                childTransform.gameObject.SetActive(true);
            }
            else
            {
                Transform childTransform = transform.GetChild(i);
                childTransform.gameObject.SetActive(false);
            }

        }
    }
}
