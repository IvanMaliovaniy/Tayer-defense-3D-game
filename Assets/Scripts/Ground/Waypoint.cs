using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    

    [Header("INSTANTIATE TOWER")]
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isTowerInstantiate = false;

    public bool IsItPath{ get {  return isItPath;  }  }
    [SerializeField] bool isItPath = false;

    //  public bool GetIsItPath() 
    //  {

    //     return isItPath;
    //  }


    private void OnMouseDown()
    {
        if (isItPath == false)
        {
            Debug.Log(transform.name);
            if (isTowerInstantiate == false)
            {
                
               bool isPlased = towerPrefab.CreateTower(towerPrefab, transform.position);


                isTowerInstantiate = isPlased;
                //  Instantiate(tower, transform.position, Quaternion.identity);

            }


        }

        
    }

   

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
