using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] int costForThisTower = 50;

    [SerializeField] GameObject topTower;
    [SerializeField] GameObject downTower;

    [SerializeField] float timeToAktivateParts = 0.5f;


    private void Awake()
    {
        topTower.SetActive(false);
        downTower.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(Build());
    }


    IEnumerator Build() 
    {

        downTower.SetActive(true);
        yield return new WaitForSeconds(timeToAktivateParts);
        topTower.SetActive(true);

    }

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
    

    
    void Update()
    {
        
    }
}
