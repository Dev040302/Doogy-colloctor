using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUi : MonoBehaviour
{
    public float forward = 0.0f, horizondal = 0.0f;
    bool up = false,left=false,right=false;
    essen pg;
    // Start is called before the first frame update
    void Start()
    {
        pg = (GameObject.Find("essentials")).GetComponent<essen>();
    }

    private void FixedUpdate()
    {
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
        if(right && horizondal != 1.0f)
        {
            horizondal = horizondal + (Time.deltaTime) * 3;
            if (horizondal > 1.0f) { horizondal = 1.0f; }
        }
        if (left && horizondal != -1.0f)
        {
            horizondal = horizondal - (Time.deltaTime) * 3;
            if (horizondal < -1.0f) { horizondal = -1.0f; }
        }
    }

   
    

    public void press(int x)
    {
        switch (x)
        {
            case 1:up = true;break;
            case 2:left = true;break;
            case 3:right = true;break;
        }
            
    }
    public void release(int x)
    {
        if (x == 1)
        {
            up = false;
        }

        if (x == 2)
        {
            left = false;
            right = false;
            horizondal = 0.0f;
        }
    }

}
