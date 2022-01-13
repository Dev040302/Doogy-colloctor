using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    essen pg;
    float horizontalInput, forwardinput;
    // Start is called before the first frame update
    void Start()
    {
        pg = (GameObject.Find("essentials")).GetComponent<essen>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = pg.horizondal;
        forwardinput = pg.forward;
        
        if (gameObject.CompareTag("Coin"))
        {
            transform.Rotate(0.0f,50.0f * Time.deltaTime, 0.0f);
        }
        else
        {
            if (forwardinput != 0.0f && pg.gameactive) {

                if (horizontalInput == 0.0f)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.Rotate(0.0f, horizontalInput * 20.0f * Time.deltaTime, 0.0f);
                } 
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            pg.gameactive = false;
        }
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }
}
