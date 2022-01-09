using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed, horizontalInput, forwardinput,turnspeed;
    essen pg;
    // Start is called before the first frame update
    void Start()
    {
        pg = (GameObject.Find("essentials")).GetComponent<essen>();
        speed = pg.speed;
        turnspeed = pg.speed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardinput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.back * Time.deltaTime * speed * forwardinput);


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
