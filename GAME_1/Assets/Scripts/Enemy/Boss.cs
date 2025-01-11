using Pathfinding;
using System.Collections;
using UnityEngine;

public class Boss1: Enemy_AI
{
    private float moveSpeed = 2f; // Скорость движения врага
    private float attackCooldown = 0.3f; // Время между атаками
    public float attackDamage = 20f; // Урон от атаки врага
    private float lastAttackTime; // Время последней атаки
    public Vector2 directionToPlayer;
    public float distanceToPlayer;

    public bool isShooting = false;
    public bool blastAttack = false;
    public bool isWaiting = true;
    public float Health;
    private bool isDie;
    private bool Left_shooting;
    private bool Right_shooting;
    private bool Left;
    private bool Right;
    private bool BlastAttack;
    private bool IsColliderFind;

    public Transform shootpoint;
    private Transform player; // Ссылка на игрока
    private Animator animator; //Animator для визуализации
    private Vector3 startingPosition; // Начальная позиция врага
    public LayerMask ignoreLayer_1;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb_2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Получаем компонент Animator
        player = GameObject.FindGameObjectWithTag("Player_1").transform; // Находим игрока по тегу
        Health = GetComponent<Enemy_2>().boss_health;
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }
    void FixedUpdate()
    {
        if (isWaiting)
        {

        }
        else
        {
            if (isShooting)
            {

            }
            if (blastAttack)
            {

            }
        }
        Health = GetComponent<Enemy_2>().boss_health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            IsColliderFind = true;
        }
        else
        {
            IsColliderFind = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            IsColliderFind = true;
        }
        else
        {
            IsColliderFind = false;
        }
    }
    private void Shooting()
    {

    }
    private void Blastattack()
    {
        
    }
}