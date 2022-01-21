using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject settings,OptionWindow;
    public bool options = false;
    public Text diff,HS;
    public Toggle tild, btn;
    essen pg;

    // Start is called before the first frame update
    void Start()
    {
        pg = (GameObject.Find("essentials")).GetComponent<essen>();
        

    }

    // Update is called once per frame
    void Update()
    {
        HS.text = "High Score\n" + pg.HS;
    }

    public void OptionTrigger()
    {
        if (options)
        {
            closeoption();
        }
        else
        {
            options = true;
            OptionWindow.SetActive(true);
        }
    }

    public void closeoption()
    {
        options = false;
        OptionWindow.SetActive(false);
    }

    public void Diff(int x)
    {
        switch (x)
        {
            case 1:
                diff.text = "EASY";
                pg.speed = 20.0f;
                break;
            case 2:
                diff.text = "MEDIUM";
                pg.speed = 40.0f;
                break;
            case 3:
                diff.text = "HARD";
                pg.speed = 80.0f;
                break;
        }
    }

    public void toogle(int x)
    {
        Toggle opp, self;
        int oppn;

        if (x == 1)
        {
            opp = tild;
            self = btn;
            oppn = 2;
        }
        else
        {
            opp = btn;
            self = tild;
            oppn = 1;
        }

        if (self.isOn)
        {
            opp.isOn = false;
            pg.type = x;
        }
        else
        {
            opp.isOn = true;
            pg.type = oppn;
        }

    }

    public void StartStop(int x)
    {
        if (x == 1)
        {
            pg.gameactive = true;
            SceneManager.LoadScene("Prototype 1");
        }
        else
        {
            Application.Quit();
        }
    }

}
