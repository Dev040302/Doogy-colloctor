using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tild : MonoBehaviour
{
    public float forward = 0.0f, horizondal = 0.0f;
    bool up = false;
    public Text score;
    essen pg;
    // Start is called before the first frame update
    void Start()
    {
        pg = (GameObject.Find("essentials")).GetComponent<essen>();
        if (pg.type == 1)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score\n" + pg.score;

        pg.forward = forward;
        pg.horizondal = horizondal;
        if (up && forward != 1.0f)
        {
            forward = forward + (Time.deltaTime) * 3;
            if (forward > 1.0f) { forward = 1.0f; }
        }
        else if (!up && forward != 0.0f)
        {
            forward = forward - (Time.deltaTime) * 3;
            if (forward < 0.0f) { forward = 0.0f; }
        }

        horizondal = (Input.acceleration.x)*3;
    }
    public void press()
    {
        up = true; 
    }
    public void release()
    {
        up = false;
    }
}
