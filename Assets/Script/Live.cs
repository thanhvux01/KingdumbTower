using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Live : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int lives = 5;
    [SerializeField] int currentLives;

    [SerializeField] TextMeshProUGUI textMesh;

    [SerializeField] Image healthBar;

    void Start()
    {
        currentLives = lives;
        if (textMesh == null)
        {
            Debug.LogWarning("textmesh is not assigned"); ;
        }
        if (healthBar == null)
        {
            Debug.LogWarning("health bar is not assigned"); ;
        }
    }

    public void LoseLive(int number)
    {
        currentLives -= number;
        if (textMesh != null)
        {
            textMesh.text = currentLives + "/" + lives;
        }
        if (healthBar != null)
        {
            healthBar.fillAmount = currentLives / lives;
        }
        if (currentLives <= 0)
        {
            Debug.Log("Game Restart");

            ReloadScene();
        }

    }
    private void ReloadScene()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
