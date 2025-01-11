using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;

public class CameraControl : MonoBehaviour
{
    private Vector3 player;
    public DataHero dat_1;
    public Vector3 temp;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player_1").transform.position;
        dat_1 = GameObject.FindGameObjectWithTag("Player_1").GetComponent<DataHero>();
        temp.x = 0f;
        temp.y = 0f;
        temp.z = -10f;
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player_1").transform.position;
        temp.x = player.x;
        temp.y = player.y;
        temp.z = -10f;
        dat_1.pos = temp;
    }
}
