using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartBossfight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_1")
        {
            Boss1.Instance.isWaiting = false;
            Boss1.Instance.isWaiting = true;
        }
    }
}
