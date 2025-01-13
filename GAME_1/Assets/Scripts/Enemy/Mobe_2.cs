using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobe_2 : Enemy_AI
{
    private Transform player_pos; // Ссылка на игрока
    private Vector3 startingPosition; // Начальная позиция врага
    private Animator animator;
    private float moveSpeed = 2f;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb_2 = GetComponent<Rigidbody2D>();
        player_pos = GameObject.FindGameObjectWithTag("Player_1").transform;
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void Update()
    {
        rb_2.velocity = direction * moveSpeed;
    }
}
