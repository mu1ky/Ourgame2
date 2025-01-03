using System.Collections;
using UnityEngine;
public class Robot : Enemy_1
{
    private float moveSpeed = 2f; // �������� �������� �����
    private float attackCooldown = 1f; // ����� ����� �������
    private float agroRange = 5f; // ���������, ��� ������� ���� �������� ��������� ������
    private float chaseDistance = 15f; // ��������� �������������
    private float shootingRange = 10f; // ������������ ��������� ��� ��������
    public Vector2 directionToPlayer;
    public Vector2 shootingDirection;
    public float distanceToPlayer;
    public float distanceToStart;
    public bool isAttacking = false;
    public bool isReturning = false;
    public bool isMoving = false;
    private bool Left_1;
    private bool Right_1;
    private bool Left;
    private bool Right;
    private bool Up;
    private bool Down;
    private bool Idle;

    public Transform shootpoint;

    private Transform player; // ������ �� ������
    private float lastAttackTime; // ����� ��������� �����
    private Rigidbody2D rb; // Rigidbody2D ��� ��������
    private Animator animator; //Animator ��� ������������
    private Vector3 startingPosition; // ��������� ������� �����
    public LayerMask ignoreLayer_1;
    void Start()
    {
        animator = GetComponent<Animator>(); // �������� ��������� Animator
        player = GameObject.FindGameObjectWithTag("Player_1").transform; // ������� ������ �� ����
        rb = GetComponent<Rigidbody2D>(); // �������� ��������� Rigidbody2D
        startingPosition = transform.position; // ���������� ��������� ������� �����
    }
    void FixedUpdate()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < agroRange) { isAttacking = true; }
        if (distanceToPlayer > shootingRange) { isAttacking = false; }

        if (isAttacking == true)
        {
            AttackPlayer();
        }
        else
        {
            if (distanceToPlayer < chaseDistance)
            {
                MoveTowardsPlayer();

            }
            else
            {
                ReturnToStartingPosition();

            }
        }
    }
    void AttackPlayer()
    {
        Left = false;
        Right = false;
        Up = false;
        Down = false;
        Left_1 = false;
        Right_1 = false;
        Idle = false;

        float playerX = player.position.x;
        float playerY = player.position.y;
        float enemyX = transform.position.x;
        float enemyY = transform.position.y;
        float yDiff = Mathf.Abs(playerY - enemyY);
        float xDiff = Mathf.Abs(playerX - enemyX);

        if ((playerY > enemyY) && (yDiff > xDiff))
        {
            Up = true;
            shootingDirection = Vector2.up;
            if (playerX > enemyX)
            {
                rb.velocity = new Vector2(moveSpeed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, 0);
            }
        }
        if ((playerY < enemyY) && (yDiff > xDiff))
        {
            Down = true;
            shootingDirection = -Vector2.up;
            if (playerX > enemyX)
            {
                rb.velocity = new Vector2(moveSpeed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, 0);
            }
        }
        if ((playerX > enemyX) && (xDiff > yDiff))
        {
            Right = true;
            shootingDirection = Vector2.right;
            if (playerY > enemyY)
            {
                rb.velocity = new Vector2(0, moveSpeed);
            }
            else
            {
                rb.velocity = new Vector2(0, -moveSpeed);
            }
        }
        if ((playerX < enemyX) && (xDiff > yDiff))
        {
            Left = true;
            shootingDirection = -Vector2.right;
            if (playerY > enemyY)
            {
                rb.velocity = new Vector2(0, moveSpeed);
            }
            else
            {
                rb.velocity = new Vector2(0, -moveSpeed);
            }
        }
        animator.SetBool("Left_1", Left_1);
        animator.SetBool("Right_1", Right_1);
        animator.SetBool("At_right", Right);
        animator.SetBool("At_left", Left);
        animator.SetBool("At_up", Up);
        animator.SetBool("At_down", Down);
        animator.SetBool("Idle", Idle);

        if (Time.time >= lastAttackTime + attackCooldown)
        {
            RaycastHit2D hit = Physics2D.Raycast(shootpoint.position, shootingDirection, Mathf.Infinity, ~ignoreLayer_1);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player_1")
                {
                    Player player_1 = hit.collider.GetComponent<Player>();
                    Debug.Log("Attack! Damage: " + attackDamage);
                    player_1.TakeDamage_hero(attackDamage);
                }
                //Debug.Log("Attack! Damage: " + hit.collider.tag);
            }
            lastAttackTime = Time.time;
        }
    }
    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > agroRange)
        {
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        AnimationMove();
    }
    void ReturnToStartingPosition()
    {
        // ������������ �� ��������� ���������
        distanceToStart = Vector2.Distance(transform.position, startingPosition);

        if (distanceToStart > 0.1f) // ��� �������������� ��������
        {
            Vector2 direction = (startingPosition - transform.position).normalized;
            rb.velocity = direction * moveSpeed; // ������������ � ��������� �����
        }
        else
        {
            rb.velocity = Vector2.zero; // ���������������, ��� ������ �������� ��������� �������
        }
        AnimationMove();
    }
    void AnimationMove()
    {
        Left = false;
        Right = false;
        Up = false;
        Down = false;
        Left_1 = false;
        Right_1 = false;
        Idle = false;
        Vector2 distance = player.position - transform.position;
        distanceToStart = Vector2.Distance(transform.position, startingPosition);
        if (distance.x < 0)
        {
            Left_1 = true;
        }
        else
        {
            Right_1 = true;
        }
        if (distanceToStart < 0.1f)
        {
            Idle = true;
            Left_1 = false;
            Right_1 = false;
        }
        animator.SetBool("Left_1", Left_1);
        animator.SetBool("Right_1", Right_1);
        animator.SetBool("At_right", Right);
        animator.SetBool("At_left", Left);
        animator.SetBool("At_up", Up);
        animator.SetBool("At_down", Down);
        animator.SetBool("Idle", Idle);
    }
}

