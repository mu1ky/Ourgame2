using Pathfinding;
using System.Collections;
using UnityEngine;
using Game.Utils_1;
using System;

public class Boss1: MonoBehaviour
{
    public static Boss1 Instance { get; private set; }

    private float moveSpeed = 2f; // —корость движени€ врага
    private float attackCooldown_b1 = 3f; // ¬рем€ между атаками
    public float attackDamage = 20f; // ”рон от атаки врага
    private float lastAttackTime_b1; // ¬рем€ последней атаки
    public Vector2 directionToPlayer;
    public float distanceToPlayer;

    public bool isShooting = false;
    public bool blastAttack = false;
    public bool blastAttack_1 = false;
    public bool blastAttack_2 = false;
    public bool blastAttack_3 = false;
    public bool blastAttack_4 = false;
    public bool isWaiting = true;
    public float Health_1;
    private bool isDie;
    private bool Left_shooting;
    private bool Right_shooting;
    private bool Left;
    private bool Right;
    private bool BlastAttack;
    private bool IsColliderFind;

    public Transform shootpoint;
    private Transform player; // —сылка на игрока
    private Animator animator; //Animator дл€ визуализации
    private Vector3 startingPosition; // Ќачальна€ позици€ врага
    public LayerMask ignoreLayer_1;
    public Rigidbody2D rb_2;

    public event EventHandler Attack_1;
    public event EventHandler Attack_2;

    //инициализируем необходимые компоненты
    void Start()
    {
        rb_2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // ѕолучаем компонент Animator
        player = GameObject.FindGameObjectWithTag("Player_1").transform; // Ќаходим игрока по тегу
        Health_1 = GetComponent<Enemy_2>().boss_health;
    }
    //описание движени€ босса по комнате
    //движение будет происходить по одной координате
    private void Move_boss()
    {
        //если движение ещЄ не началось, и босс стоит на месте
        if (transform.position == startingPosition)
            rb_2.MovePosition(Common2.GetRandomirPoint(55, 73));
        //движение к выбранной рандомно точке
        else
            rb_2.MovePosition(startingPosition);
    }
    void FixedUpdate()
    {
        if (isWaiting == true)
        {
            Move_boss();
            //если герой находитс€ вне команты, то босс просто ходит
        }
        else
        {
            if (isShooting)
            {
                //если герой не подошЄл к укрыти€м, то босс стрел€ет множество пуль во все стороны
                Move_boss();
                Attack_1?.Invoke(this, EventArgs.Empty);
                //событие выше запускает вылет пуль
            }
            if (blastAttack)
            {
                //если герой уже подошЄл к укрыти€м, то босс стрел€ет именно в ту область, где находитс€ герой
                Attack_Boss();
                //Move_boss();
                //Attack_2?.Invoke(this, EventArgs.Empty);
            }
        }
        Health_1 = GetComponent<Enemy_2>().boss_health;
        //обновл€ем компонент здоровь€ босса
    }
    private void Attack_Boss()
    {
        if(Time.time >= lastAttackTime_b1 + attackCooldown_b1)
        {
            Move_boss(); //всЄ ещЄ двигаетс€
            Attack_2?.Invoke(this, EventArgs.Empty);
            //событие запускает выпуск гранат
            lastAttackTime_b1 = Time.time;
        }
        //дл€ налаживани€ регул€рности и последоватльности атак
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
    //логика смены анимации
}