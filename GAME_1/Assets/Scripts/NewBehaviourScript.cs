using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static CameraControl Instance { get; private set; }
    private Transform player;
    private string filePath;
    public Vector3 temp;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player_1").transform;
        temp.x = 0f;
        temp.y = 0f;
        temp.z = -10f;
        transform.position = temp;
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player_1").transform;
        temp.x = player.position.x;
        temp.y = player.position.y;
        temp.z = -10f;
        transform.position = temp;
    }
}
