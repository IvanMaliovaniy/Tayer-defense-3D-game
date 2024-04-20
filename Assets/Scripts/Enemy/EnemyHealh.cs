using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]  //тепер коли ми створюємо об'єкт з цим скриптом, автоматично до нього додається скрипт Enemy
public class EnemyHealh : MonoBehaviour
{
    [SerializeField] int healthPoints = 5;

    [Tooltip("Додаємо хп ворогу для балансу кількості поставлених башен")]
    [SerializeField] int difficultyRamp = 1;

    [SerializeField] int damagePerOneShot = 1;
    [SerializeField] bool isCanHit = true;

    [SerializeField] int currentHealth;

    [SerializeField] Enemy thisEnemy;

    
    void OnEnable()
    {
        currentHealth = healthPoints;
        isCanHit = true;
    }


    private void OnParticleCollision(GameObject other)
    {
        if (isCanHit)
        {
            isCanHit = false;
            currentHealth = currentHealth - damagePerOneShot;
            DamageControl();
            isCanHit = true;
        }
    }


    void DamageControl() 
    {
        if (currentHealth <= 0)
        {
            thisEnemy.RewardGold();

            healthPoints += difficultyRamp;   //додаємо кількість базового життя щоб сбалансувати складність гри


            this.gameObject.SetActive(false);
        }
    
    }

    void Update()
    {
        
    }
}
