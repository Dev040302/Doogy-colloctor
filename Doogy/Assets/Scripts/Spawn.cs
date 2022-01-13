using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject road, current,coin;
    public GameObject[] obstacles;
    public float x, forwardinput, timer;
    public int count;
    essen pg;
    // Start is called before the first frame update
    void Start()
    {
        count = obstacles.Length;
        current = obstacles[Random.Range(0, 6)];
        pg = (GameObject.Find("essentials")).GetComponent<essen>();
    }

    // Update is called once per frame
    void Update()
    {
        x = (road.transform.position.x) + 1.0f;
        forwardinput = pg.forward;

        if (forwardinput != 0.00f)
        {
            timer += Time.deltaTime;

            if (timer > 0.5f)
            {
                Instantiate(coin, new Vector3(x + Random.Range(-8.0f, 7.0f), coin.transform.position.y, 80), coin.transform.rotation);
                timer = 0.0f;
            }
        }
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
