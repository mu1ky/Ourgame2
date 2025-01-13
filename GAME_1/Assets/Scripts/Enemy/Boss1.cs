using Pathfinding;
using System.Collections;
using UnityEngine;
using Game.Utils_1;
using System;

public class Boss1: MonoBehaviour
{
    public static Boss1 Instance { get; private set; }

    private float moveSpeed = 2f; // �������� �������� �����
    private float attackCooldown = 0.3f; // ����� ����� �������
    public float attackDamage = 20f; // ���� �� ����� �����
    private float lastAttackTime; // ����� ��������� �����
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
    private Transform player; // ������ �� ������
    private Animator animator; //Animator ��� ������������
    private Vector3 startingPosition; // ��������� ������� �����
    public LayerMask ignoreLayer_1;
    public Rigidbody2D rb_2;

    public event EventHandler Attack_1;
    public event EventHandler Attack_2;

    void Start()
    {
        rb_2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // �������� ��������� Animator
        player = GameObject.FindGameObjectWithTag("Player_1").transform; // ������� ������ �� ����
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