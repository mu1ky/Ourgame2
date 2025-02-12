using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;
using System;
using System.Net;

public class Gun : MonoBehaviour
{
    public static Gun Instance { get; private set; }
    public Transform _shotpoint; //пустой объект - первоначальное положение пули
    private Vector3 _shotpoint_dir;
    private float lastAttack;
    public float attackCooldown_hero = 1f;
    public float dam = 10f;
    public GameObject DamageEffect;
    public GameObject pref_1;
    public GameObject bul_hero;
    public float bul_speed_1;
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private bool isCollider = false;
    public LayerMask ignoreLayer_2;

    public bool IsAttacking()
    {
        return isAttacking;
    }
    public bool IsCollider()
    {
        return isCollider;
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Player.Instance.NowIsShooting_1())
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (Player.Instance.IsShootingDown())
        {
            _shotpoint_dir = -_shotpoint.up;
        }
        if (Player.Instance.IsShootingUp())
        {
            _shotpoint_dir = _shotpoint.up;
        }
        if (Player.Instance.IsShootingLeft())
        {
            _shotpoint_dir = -_shotpoint.right;
        }
        if (Player.Instance.IsShootingRight())
        {
            _shotpoint_dir = _shotpoint.right;
        }
        if (InputControl.Instance.IsGetSpace_() == true)
        {
            if (Time.time >= lastAttack + attackCooldown_hero)
            {
                isAttacking = true;
                RaycastHit2D hit = Physics2D.Raycast(_shotpoint.position, _shotpoint_dir, Mathf.Infinity, ~ignoreLayer_2);
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Enemy")
                    {
                        Enemy_1 enemy = hit.collider.GetComponent<Enemy_1>();
                        Debug.Log("Attack! Damage: " + dam);
                        enemy.TakeDamage_enemy(dam);
                        bul_hero = Instantiate(pref_1, _shotpoint.position, Quaternion.identity);
                        if (bul_hero != null)
                        {
                            bul_hero.GetComponent<Rigidbody2D>().velocity = _shotpoint_dir * bul_speed_1;
                        }
                    }
                    //Debug.Log("Attack! Damage: " + dam + " " + hit.collider.tag);
                    /*
                    isCollider = true;
                    obstacle = Instantiate(DamageEffect, hit.point, Quaternion.identity);
                    if (obstacle == null)
                    {	
                        isCollider = false;
                    }
                    */
                }
                lastAttack = Time.time;
            }
        }
        else
        {
            isAttacking = false;
        }
    }
}