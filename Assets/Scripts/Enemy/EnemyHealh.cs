using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]  //����� ���� �� ��������� ��'��� � ��� ��������, ����������� �� ����� �������� ������ Enemy
public class EnemyHealh : MonoBehaviour
{
    [SerializeField] int healthPoints = 5;

    [Tooltip("������ �� ������ ��� ������� ������� ����������� �����")]
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

            healthPoints += difficultyRamp;   //������ ������� �������� ����� ��� ������������ ��������� ���


            this.gameObject.SetActive(false);
        }
    
    }

    void Update()
    {
        
    }
}
