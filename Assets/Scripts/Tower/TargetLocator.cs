using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem progectileParticle;

    [SerializeField] float range = 20f;

    Transform target;


    

    void Start()
    {
        //target = FindObjectOfType<EnemyMover>().transform;
    }

   
    void Update()
    {
        FindClosestTarget();
        AimEnemy();  
    }


    void FindClosestTarget() 
    {
        Enemy[] enemys = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistans = Mathf.Infinity;

        foreach (var enemy in enemys)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistans)
            {
                closestTarget = enemy.transform;
                maxDistans = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimEnemy() 
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position); 

        weapon.transform.LookAt(target);

        if (targetDistance <= range )
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }


    void Attack(bool isActive)
    {

        var emissionModule = progectileParticle.emission;
        emissionModule.enabled = isActive;

    }
}
