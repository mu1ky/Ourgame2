using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    public float health_enemy = 100f; // �������� �����
    public float attackDamage = 10f; // ���� �� �����
    public void TakeDamage_enemy(float damage)
    {
        health_enemy -= damage;
        Debug.Log("Enemy takes damage: " + damage + ". Current health: " + health_enemy);

        if (health_enemy <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Enemy has died!");
        // ������ ������ ����� (��������, ������������ �����, �������� � �.�.)
        //Destroy(gameObject); // ������� ����� �� ����
    }
}
