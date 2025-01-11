using Pathfinding;
using System.Collections;
using UnityEngine;

public class Boss1: Enemy_AI
{
    private float moveSpeed = 2f; // �������� �������� �����
    private float attackCooldown = 0.3f; // ����� ����� �������
    public float attackDamage = 20f; // ���� �� ����� �����
    private float lastAttackTime; // ����� ��������� �����
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
    private Transform player; // ������ �� ������
    private Animator animator; //Animator ��� ������������
    private Vector3 startingPosition; // ��������� ������� �����
    public LayerMask ignoreLayer_1;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb_2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // �������� ��������� Animator
        player = GameObject.FindGameObjectWithTag("Player_1").transform; // ������� ������ �� ����
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