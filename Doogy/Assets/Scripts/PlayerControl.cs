using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed, horizontalInput, forwardinput,turnspeed;
    essen pg;
    public GameObject car;
    bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        pg = (GameObject.Find("essentials")).GetComponent<essen>();
        car = GameObject.Find("Player");
        speed = pg.speed;
        turnspeed = pg.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (pg.gameactive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardinput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.back * Time.deltaTime * speed * forwardinput);


            if (done || horizontalInput == 0.0f)
            {
                car.transform.rotation = Quaternion.Euler(0,0,0);
            }
            else
            {
                car.transform.Rotate(0.0f, horizontalInput * pg.speed * Time.deltaTime, 0.0f);
                done = false;
            }

            if (forwardinput != 0.0f)
            {

                
                transform.Translate(Vector3.left * Time.deltaTime * turnspeed * horizontalInput);
            }
            if (gameObject.CompareTag("Respawn"))
            {
                if (transform.position.z < -10)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
