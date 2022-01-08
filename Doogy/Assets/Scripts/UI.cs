using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject settings,OptionWindow;
    public bool options = false;
    public Text diff;
    public Toggle tild, btn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                break;
            case 2:
                diff.text = "MEDIUM";
                break;
            case 3:
                diff.text = "HARD";
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
        }
        else
        {
            opp.isOn = true;
        }



    }
}
