using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageLabel : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text textMesh;

    Color color;
    [SerializeField] int fontSize = 50;

    Fade_Effect fade_Effect;
    void Awake()
    {
        textMesh = GetComponent<TMP_Text>();
        fade_Effect = GetComponent<Fade_Effect>();

    }
    void Start()
    {

        if (textMesh != null)
        {
            textMesh.fontSize = fontSize;
            color = textMesh.color;
        }
        NewWaveLabel(0);
    }

    // Update is called once per frame
    public void NewWaveLabel(int wave)
    {
        
        if (textMesh)
        {
            if (fade_Effect)
            {
                fade_Effect.isRunning = true;
                textMesh.color = color;
                wave++;
                textMesh.text = $"WAVE{wave} START!!";
            }
        }

    }
}
