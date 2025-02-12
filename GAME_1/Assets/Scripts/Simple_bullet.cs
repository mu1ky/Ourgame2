using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_bullet : MonoBehaviour
{
    public bool IsPlayer = false;
    public bool IsEnemy = false;
    public Vector2 shootDir;

    private void Awake()
    {
        if (gameObject.tag == "BulPlayer")
        {
            IsPlayer = true;
        }
        if (gameObject.tag == "BulEnemy")
        {
            IsEnemy = true;
        }
    }
    private void Start()
    {
    }
    private void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayer == true)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject, 1f);
            }
        }
        if (IsEnemy == true)
        {
            if (collision.gameObject.tag == "Player_1")
            {
                Destroy(gameObject, 1f);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 1f);
    }
    public void DirBul(Vector2 DIR)
    {
        shootDir = DIR;
    }
}
