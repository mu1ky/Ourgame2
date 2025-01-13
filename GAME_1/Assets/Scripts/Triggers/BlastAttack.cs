using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlastAttack : MonoBehaviour
{
    public GameObject explosion;
    public bool PlayerHere = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_1")
        {
            PlayerHere = true;
            Boss1.Instance.isShooting = false;
            Boss1.Instance.blastAttack = true;
            if (gameObject.tag == "Blast1")
            {
                Boss1.Instance.blastAttack_1 = true;
                Boss1.Instance.blastAttack_2 = Boss1.Instance.blastAttack_3 = Boss1.Instance.blastAttack_4 = false;
            }
            if (gameObject.tag == "Blast2")
            {
                Boss1.Instance.blastAttack_2 = true;
                Boss1.Instance.blastAttack_1 = Boss1.Instance.blastAttack_3 = Boss1.Instance.blastAttack_4 = false;
            }
            if (gameObject.tag == "Blast3")
            {
                Boss1.Instance.blastAttack_3 = true;
                Boss1.Instance.blastAttack_1 = Boss1.Instance.blastAttack_2 = Boss1.Instance.blastAttack_4 = false;
            }
            if (gameObject.tag == "Blast4")
            {
                Boss1.Instance.blastAttack_4 = true;
                Boss1.Instance.blastAttack_1 = Boss1.Instance.blastAttack_2 = Boss1.Instance.blastAttack_3 = false;
            }
        }
        if ((collision.gameObject.tag == "Bullet") || (collision.gameObject.tag == "Grenada"))
        {
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            if (collision.gameObject.tag == "Grenada")
            {
                if (PlayerHere == true)
                {
                    Player.Instance.TakeDamage_hero(Boss1.Instance.attackDamage);
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_1")
        {
            PlayerHere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_1")
        {
            PlayerHere = false;
            Boss1.Instance.blastAttack_1 = Boss1.Instance.blastAttack_2 = false;
            Boss1.Instance.blastAttack_3 = Boss1.Instance.blastAttack_4 = false;
        }
    }
}
