using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    essen pg;
    ads ad;
    public Text score;    
    // Start is called before the first frame update
    void Start()
    {
        pg = (GameObject.Find("essentials")).GetComponent<essen>();
        ad = (GameObject.Find("Ads")).GetComponent<ads>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score\n" + pg.score;
    }

    public void Continue()
    {
        ad.showad(gameObject);
    }
    public void Restart()
    {
        
        pg.gameactive = true;
        pg.score = 0;
        SceneManager.LoadScene("Prototype 1");


    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);
    }

    

    public void back()
    {
        pg.score = 0;
        SceneManager.LoadScene("Start");
    }
}
