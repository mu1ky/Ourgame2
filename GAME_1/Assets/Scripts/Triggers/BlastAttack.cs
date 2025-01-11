using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlastAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_1")
        {
            Boss1.Instance.isShooting = false;
            Boss1.Instance.blastAttack = true;
        }
    }
}
