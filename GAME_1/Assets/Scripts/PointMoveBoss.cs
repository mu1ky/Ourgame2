using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMoveBoss : MonoBehaviour
{
    public float radius = 5f;
    public float speed = 2f;
    private float t = 0f; // Параметр времени
    public float StartCenterX = 43.1f;
    public float StartCenterY = 43.1f;
    private float lastAttackTime_boss;
    private float attackCooldown_boss = 1f;
    private GameObject bullet;
    private GameObject grenada;
    //параметры центра вращения поменять нужно

    private void Start()
    {
        Boss1.Instance.Attack_1 += CreateBullet;
        Boss1.Instance.Attack_2 += CreateGrenada;
    }
    private void CreateBullet(object sender, System.EventArgs e)
    {
        if (Time.time >= lastAttackTime_boss + attackCooldown_boss)
        {
            lastAttackTime_boss = Time.time;
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
    private void CreateGrenada(object sender, System.EventArgs e)
    {
        if (Time.time >= lastAttackTime_boss + attackCooldown_boss)
        {
            lastAttackTime_boss = Time.time;
            Instantiate(grenada, transform.position, Quaternion.identity);
        }
    }
    private Vector2 GetPositionOnCircle(float centerX, float centerY)
    {
        // Параметрическое уравнение окружности: x = centerX + radius * cos(t), y = centerY + radius * sin(t)
        float x = centerX + radius * Mathf.Cos(t);
        float y = centerY + radius * Mathf.Sin(t);

        t += speed * Time.deltaTime; // Изменяем параметр времени
        return new Vector2(x, y);
    }

    void Update()
    {
        Vector2 newPos = GetPositionOnCircle(StartCenterX, StartCenterY); 
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
