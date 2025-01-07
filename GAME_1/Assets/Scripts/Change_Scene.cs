using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    /*
    public void GoToLevel(int number)
    {
        SceneManager.LoadScene(number);
    }
    */
    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision != null) & (collision.gameObject.tag != "Player_1")){
            HPbarKey_hero h = collision.gameObject.GetComponent<HPbarKey_hero>();
            if (h != null)
            {
                if (h.count_Key >= 3)
                {
                    NextLevel();
                }
            }
        }
    }
    public void NextLevel()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
}
