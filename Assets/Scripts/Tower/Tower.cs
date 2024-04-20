using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] int costForThisTower = 50;

    public bool CreateTower( Tower towerPrefab, Vector3 prefabPosition ) 
    {

        Bank bank = FindObjectOfType<Bank>();

        if (bank !=null)
        {
            int currentGold = bank.CurrentBalance;

            if (currentGold >= costForThisTower)
            {
                bank.PayFromDeposit(costForThisTower);
                Instantiate(towerPrefab, prefabPosition, Quaternion.identity);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

       

        
    
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
