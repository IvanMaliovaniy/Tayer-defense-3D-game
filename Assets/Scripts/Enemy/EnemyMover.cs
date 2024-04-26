using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]  //тепер коли ми створюємо об'єкт з цим скриптом, автоматично до нього додається скрипт Enemy
public class EnemyMover : MonoBehaviour
{

     List<Node> path = new List<Node>();
    GridManager gridManager;
    Pathfinding pathfinding;

    [SerializeField] [Range(0f, 3f)] float speed = 1f;

    [SerializeField] float timeToDestroyInFinish = 1.0f;

    [SerializeField] Enemy thisEnemy;



    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinding = FindObjectOfType<Pathfinding>();

    }



    void RecalculatePath(bool resetPath) 
    {
        Vector2Int coordinates = new Vector2Int();

        if (resetPath)
        {
            coordinates = pathfinding.StartCoordinates;
        }

        else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }


        StopAllCoroutines();

        path.Clear();

        path = pathfinding.GetNewPath(coordinates);

        StartCoroutine(MoveToWaipoint());
    }
    
    


    void ReturnToStart() 
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinding.StartCoordinates);
    
    }

    void FinishPath()
    {

        thisEnemy.HealthPenalty();
        this.gameObject.SetActive(false);

    }

    void OnEnable()
    {
        ReturnToStart();

        RecalculatePath(true);
      
        
    }

    
    void Update()
    {
        
    }

    IEnumerator MoveToWaipoint() 
    {
        for(int i = 1; i<path.Count; i++ )
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates); ;
            float travelPersent = 0f;

            transform.LookAt(endPosition);  // повертаємо ворога у напрямку руху

            while (travelPersent < 1f)
            {
                travelPersent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPersent);
                yield return new WaitForEndOfFrame();

            }

        }


        FinishPath();
       
    }


   
}
