using Pathfinding;
using System.Collections;
using UnityEngine;
using Game.Utils_1;
using System;

public class Boss1: MonoBehaviour
{
    public static Boss1 Instance { get; private set; }

    private float moveSpeed = 2f; // Скорость движения врага
    private float attackCooldown = 0.3f; // Время между атаками
    public float attackDamage = 20f; // Урон от атаки врага
    private float lastAttackTime; // Время последней атаки
    public Vector2 directionToPlayer;
    public float distanceToPlayer;

    public bool isShooting = false;
    public bool blastAttack = false;
    public bool blastAttack_1 = false;
    public bool blastAttack_2 = false;
    public bool blastAttack_3 = false;
    public bool blastAttack_4 = false;
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
    public Rigidbody2D rb_2;

    public event EventHandler Attack_1;
    public event EventHandler Attack_2;

    void Start()
    {
        rb_2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Получаем компонент Animator
        player = GameObject.FindGameObjectWithTag("Player_1").transform; // Находим игрока по тегу
        Health = GetComponent<Enemy_2>().boss_health;
    }
    private void Move_boss()
    {
        if (transform.position == startingPosition)
            rb_2.MovePosition(Common2.GetRandomirPoint());
        else
            rb_2.MovePosition(startingPosition);
    }
    void FixedUpdate()
    {
        if (isWaiting)
        {
            Move_boss();
        }
        else
        {
            if (isShooting)
            {
                Move_boss();
                Attack_1?.Invoke(this, EventArgs.Empty);
            }
            if (blastAttack)
            {
                Move_boss();
                Attack_2?.Invoke(this, EventArgs.Empty);
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