using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageLabel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Wave wave;

    TMP_Text textMesh;
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        NewWaveLabel();
    }

    // Update is called once per frame
    void NewWaveLabel()
    {
        if (textMesh)
        {
            int currentWave = wave.CurrentWave+1;
            textMesh.text = $"WAVE{currentWave} START!!";
        }

    }
}
