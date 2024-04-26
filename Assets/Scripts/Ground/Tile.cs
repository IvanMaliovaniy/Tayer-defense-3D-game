using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    

    [Header("INSTANTIATE TOWER")]
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isTowerInstantiate = false;

    public bool IsItPath{ get {  return isItPath;  }  }
    [SerializeField] bool isItPath = false;

    GridManager gridManager;
    Pathfinding pathfinder;

    Vector2Int coordinates = new Vector2Int();


    void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (isTowerInstantiate)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();

        pathfinder = FindObjectOfType<Pathfinding>();
    }


    private void OnMouseDown()
    {
       
           // Debug.Log(transform.name);
            if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates) )
            {
                
                bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);


          //  isTowerInstantiate = isPlased;

            if (isSuccessful)
            {
                
                gridManager.BlockNode(coordinates);

                pathfinder.NotifyResivers();  // передаємо сигнал що треба перерахувати шлях для Enemy;
            }
               
               

            }


     

        
    }

   

    

    
    void Update()
    {
        
    }
}
