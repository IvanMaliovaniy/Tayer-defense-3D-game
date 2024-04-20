using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]  //тепер коли ми створюємо об'єкт з цим скриптом, автоматично до нього додається скрипт Enemy
public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    [SerializeField] [Range(0f, 3f)] float speed = 1f;

    [SerializeField] float timeToDestroyInFinish = 1.0f;

    [SerializeField] Enemy thisEnemy;


    void FindPath() 
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        //  GameObject[] waipoints = GameObject.FindGameObjectsWithTag("Path");


        foreach (Transform child in parent.transform)
        {

            Waypoint way = child.GetComponent<Waypoint>();

            if (way != null)
            {
                path.Add(way);
            }

            
        }

     /*   foreach (var waipoint in waipoints)
        {
            path.Add(waipoint.GetComponent<Waypoint>());
        }  */
    
    
    }


    void ReturnToStart() 
    {
        transform.position = path[0].transform.position;
    
    }

    void OnEnable()
    {
      FindPath();
      ReturnToStart();
      StartCoroutine(MoveToWaipoint());
    }

    
    void Update()
    {
        
    }

    IEnumerator MoveToWaipoint() 
    {
        foreach (Waypoint item in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = new Vector3(item.transform.position.x, transform.position.y, item.transform.position.z);
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


    void FinishPath() 
    {

        thisEnemy.HealthPenalty();
        this.gameObject.SetActive(false);

    }
}
