using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Work : MonoBehaviour
{
    public static SendDataHero testScript;
    // Start is called before the first frame update
    void Start()
    {
        //AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        DontDestroyOnLoad(this);
        testScript = gameObject.AddComponent<SendDataHero>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
