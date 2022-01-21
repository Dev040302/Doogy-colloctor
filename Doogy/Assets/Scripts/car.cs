using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class car : MonoBehaviour
{
    essen pg;
    float horizontalInput, forwardinput;
    public GameObject end,Ad,endscore;
    public AudioSource speker;
    public AudioClip ignition,coin,bang;
    public Text HS;
    public float time=0.0f;
    bool done = true;
    // Start is called before the first frame update
    void Start()
    {
        pg = (GameObject.Find("essentials")).GetComponent<essen>();
        end.SetActive(false);
        endscore.SetActive(false);
        //speker.PlayOneShot(ignition);
    }

    // Update is called once per frame
    void Update()
    {

        time = time + Time.deltaTime;
        horizontalInput = pg.horizondal;
        forwardinput = pg.forward;

        if (gameObject.CompareTag("Coin"))
        {
            transform.Rotate(0.0f,50.0f * Time.deltaTime, 0.0f);
        }
        else
        {
            if (forwardinput != 0.0f && pg.gameactive && pg.type==1) {

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
            speker.PlayOneShot(bang);
            if (pg.HS < pg.score)
            {
                endscore.SetActive(true);
                pg.HS = pg.score;
                HS.text = "New High Score\n" + pg.HS;
                StartCoroutine(stopscreen());
                
            }
            else
            {
                end.SetActive(true);
            }

            pg.hiten = other.gameObject;
        }
        if (other.gameObject.CompareTag("Coins"))
        {
            pg.score = pg.score + 1;
            Destroy(other.gameObject);
            speker.PlayOneShot(coin);
        }
        if (other.gameObject.CompareTag("Finish")) {
            pg.gameactive = false;
            if (pg.HS < pg.score)
            {
                done = false;
                endscore.SetActive(true);
                pg.HS = pg.score;
                HS.text = "New High Score\n" + pg.HS;
                StartCoroutine(stopscreen());
            }
            else {
                if(done)
                {
                    end.SetActive(true);
                }
            }

            Ad.SetActive(false);
        }

    }

    IEnumerator stopscreen()
    {
        yield return new WaitForSeconds(5);

        pg.SavaScore();
        end.SetActive(true);
        endscore.SetActive(false);
    }
}
