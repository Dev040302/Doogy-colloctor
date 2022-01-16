using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class essen : MonoBehaviour
{
    public static essen Instance;
    public float speed = 20.0f,forward=0.0f,horizondal=0.0f;
    public int type = 1,score=0;
    public bool gameactive = false;
    public GameObject hiten=null;

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
