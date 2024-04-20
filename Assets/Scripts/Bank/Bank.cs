using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 500;
    [SerializeField] int currentBalance;
    [SerializeField] int currentLife = 100;

    [SerializeField] TextMeshProUGUI coinsYouHave;

    [SerializeField] TextMeshProUGUI lifePoints;


    void LifePointsTextControl() 
    {

        lifePoints.text = "LIFE: " + CurrentLife.ToString();
    
    }

    void CoinsTextControl() 
    {

        coinsYouHave.text = "COINS: " + currentBalance.ToString();
    }


    public int CurrentLife 
    {

        get 
        {

            return currentLife;
        }
    
    }
    public int CurrentBalance 
    {
        get
        {
           return currentBalance;
        }
    }


    public void Deposit(int amount) 
    {

        currentBalance += Mathf.Abs(amount);
        CoinsTextControl();
    }

    public void PayFromDeposit(int amount)
    {

        currentBalance -= Mathf.Abs(amount);
        CoinsTextControl();
    }

    public void Withdraw(int amount)
    {

        currentLife -= Mathf.Abs(amount);
        if (currentLife < 0)
        {
            currentLife = 0;
        }
        LifePointsTextControl();

        if (CurrentLife <= 0)
        {
            // Lose the game

            ReloadScene();
        }
    }


    void ReloadScene() 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    
    }

    void Start()
    {
        currentBalance = startingBalance;
        CoinsTextControl();
        LifePointsTextControl();
    }

    
    void Update()
    {
        
    }
}
