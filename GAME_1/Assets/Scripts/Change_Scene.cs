using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    public GameObject g_1;
    public float Health_new;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision != null) & (collision.gameObject.tag == "Player_1")){
            Health_new = GameObject.FindGameObjectWithTag("Player_1").GetComponent<Player>().health_hero;
            HPbarKey_hero h = collision.gameObject.GetComponent<HPbarKey_hero>();
            
            if (h != null)
            {
                /*
                if (h.count_Key >= 3)
                {
                    DontDestroyOnLoad(gameObject); //��������� ��� ������
                    NextLevel();
                }
                */
                DontDestroyOnLoad(gameObject); //��������� ��� ������
                NextLevel();
            }
        }
    }
    public void NextLevel()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        var ind = SceneManager.GetSceneByName("Win").buildIndex;
        if (index != ind - 1) { 
            SceneManager.LoadScene(index + 1);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive); //, LoadSceneMode.Additive);

            // ���������, ���� ��������� �������� ��������� ����������, ����� ������� ���-����
            asyncLoad.completed += operation =>
            {
                Scene newScene = SceneManager.GetSceneByBuildIndex(index + 1);
                GameObject newG1 = Instantiate(g_1, new Vector3(0f, 0f, 0f), Quaternion.identity); // ������ ����� �� �������
                //��� ���� ����� �� ������ ��������� �������� ���������� (���������� ��� ���������� ������ ������� � ������� �� ����������)
                SceneManager.MoveGameObjectToScene(newG1, newScene);
                g_1 = newG1;
                g_1.GetComponent<Player>().health_hero = Health_new;
                g_1.GetComponent<HPbarKey_hero>().HP = Health_new;
            };
        }
        else
        {
            SceneManager.LoadScene(index + 1);
        }
    }
}
