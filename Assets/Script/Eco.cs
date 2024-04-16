using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eco : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;


    [SerializeField] TextMeshProUGUI displaceBalance;
    private void Awake() {
        currentBalance = startingBalance;
        UpdateDisplace();
    }
    public int CurrentBalance { get { return currentBalance; } }

    public void Deposit(int amount) {

        currentBalance += Mathf.Abs(amount);
        UpdateDisplace();
    }

    public void Withdraw(int amount) {

        UpdateDisplace();
        currentBalance -= Mathf.Abs(amount);
        if (currentBalance < 0) {
            ReloadScene();
        }

    }

    private void UpdateDisplace() {
        displaceBalance.text = "Gold: " + currentBalance;
    }

    private void ReloadScene() {

        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

}
