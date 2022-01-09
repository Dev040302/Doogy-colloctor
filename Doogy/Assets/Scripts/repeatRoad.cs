using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatRoad : MonoBehaviour
{
    private Vector3 StartPos;
    public float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < StartPos.z - repeatWidth)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, StartPos.z);
        }
    }

}
