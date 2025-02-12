using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonBoss : MonoBehaviour
{
    public int health_button = 140;
    public float LastAttackTime;
    public float AttackCoolDown = 1f;
    public GameObject pref_mobe;//префаб моба
    public static event EventHandler isDestroy;
    private void Update()
    {
        if (health_button <= 140 && health_button >= 120)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(pref_mobe, transform.position, Quaternion.identity);
            }
        }
        if (health_button < 120 && health_button >= 80)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(pref_mobe, transform.position, Quaternion.identity);
            }
        }
        if (health_button < 120 && health_button >= 80)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(pref_mobe, transform.position, Quaternion.identity);
            }
        }
        if (health_button < 80 && health_button >= 40)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(pref_mobe, transform.position, Quaternion.identity);
            }
        }
        if (health_button < 40 && health_button > 0)
        {
            Instantiate(pref_mobe, transform.position, Quaternion.identity);
        }
        if (health_button <= 0)
        {
            isDestroy?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject, 1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "GunPlayer")
            {
                if (Time.time >= LastAttackTime + AttackCoolDown)
                {
                    health_button -= 10;
                    LastAttackTime = Time.time;
                }
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "GunPlayer")
            {
                if (Time.time >= LastAttackTime + AttackCoolDown)
                {
                    health_button -= 10;
                    LastAttackTime = Time.time;
                }
            }
        }
    }
}
