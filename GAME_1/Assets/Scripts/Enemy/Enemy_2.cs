using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public float boss_health = 1000f;
    public float attackDamage1 = 20f;
    public float attackDamage2 = 50f;
    public void TakeDamage_enemy(float damage)
    {
        boss_health -= damage;
        Debug.Log("Enemy takes damage: " + damage + ". Current health: " + boss_health);

        if (boss_health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Boss was defeated!");
        //Destroy(gameObject); // ������� ����� �� ����
    }
}
