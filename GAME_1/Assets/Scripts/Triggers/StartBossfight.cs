using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartBossfight : MonoBehaviour
{
    //скрипт прикрёплен к объекту у входу в комнату босса
    //триггер срабатывает тогда, когда герой входит в комнату
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_1")
        {
            Boss1.Instance.isWaiting = false; //босс выходит из режима ожидания
            Boss1.Instance.isShooting = true; //и переходит в режим атаки
        }
    }
}
