using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class essen : MonoBehaviour
{
    public static essen Instance;
    public float speed = 20.0f;
    public int type = 1;
    public bool gameactive = false;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
