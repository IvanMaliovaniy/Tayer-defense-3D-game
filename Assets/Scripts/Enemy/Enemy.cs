using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 30;
    [SerializeField] int healhPenalty = 20;

    Bank bank;



    public void RewardGold() 
    {
        if (bank != null)
        {
            bank.Deposit(goldReward);
        }
       
    }


    public void HealthPenalty() 
    {

        if (bank !=null)
        {
            bank.Withdraw(healhPenalty);
        }

        
    
    }

    private void Awake()
    {
        bank = FindObjectOfType<Bank>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
