using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject road, current;
    public GameObject[] obstacles;
    public float x;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        count = obstacles.Length;
        current = obstacles[Random.Range(0, 6)];
    }

    // Update is called once per frame
    void Update()
    {
        x = (road.transform.position.x) + 1.0f; 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            current = obstacles[Random.Range(0, count)];
            Instantiate(current, new Vector3(x + Random.Range(-8.0f, 7.0f), current.transform.position.y, 100), current.transform.rotation);
        }
    }
}
