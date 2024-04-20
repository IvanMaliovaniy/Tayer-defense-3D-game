using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    GameObject[] pool;


    [SerializeField] [Range(1, 50)]int poolSize = 5;


    [SerializeField][Range(0.1f, 30f )] float timeBeetwenSpawnEnemy;
    [SerializeField] bool isCanSpawn = true;



    IEnumerator Spawn() 
    {
        while (isCanSpawn)
        {
            EnableObjectsOnPool();

            yield return new WaitForSeconds(timeBeetwenSpawnEnemy);

        }
    
    }


    void EnableObjectsOnPool() 
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
            
        }
    
    }

    void PopulatePool() 
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    
    }

    private void Awake()
    {
        PopulatePool();  
    }

    void Start()
    {
        isCanSpawn = true;
        StartCoroutine(Spawn());
    }

    
    void Update()
    {
        
    }
}
