using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fade_Effect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float fadeDuration = 2f;
    TMP_Text textMesh;
    float currentTime;
    float currentOpacity;

    public bool isRunning = true;

    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (textMesh != null && isRunning)
        {
            currentTime += Time.deltaTime;
            currentOpacity = Mathf.Lerp(1f, 0f, currentTime / fadeDuration);
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, currentOpacity);
            if (currentTime >= fadeDuration)
            {  
                isRunning = false;
                currentTime = 0f;
            }

        }
    }
}
