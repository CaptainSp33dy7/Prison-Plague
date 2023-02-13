using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    public TextMeshProUGUI stopWatch;
    public TextMeshProUGUI highScore;
    private float startTime;
    public bool end = false;
    public float t;
    private string minutes;
    private string seconds;

    private string score;
    private float hst;
    private string hsminutes;
    private string hsseconds;
    public string hscore;

    /// <summary>
    /// Metoda, ktera se vola jeste pred vyrenderovanim prvniho frameu a nastavuje promennou zacatecneho casu na cas tohoto frameu (prvniho frameu),
    /// dale vola metodu CalcHighScore() a prepise text High score v Game Over Menu.
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        CalcHighScore();
        highScore.text = "High Score: " + hscore;
    }

    /// <summary>
    /// Metoda, ktera se vola kazdy frame a v tomto pripade obsahuje podminku s parametrem end, ktery je az do smrti hrace false. Podminka tim padem az do smrti hrace
    /// pokracuje na "else" fazi, kde se pocita cas a prepisuje se text stopek v UI.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            return;
        }
        else
        {
        t = Time.time - startTime;
        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f2");

        HighScoreToString();

        stopWatch.text = score;
        }
        
    }

    /// <summary>
    /// Metoda, ktera pocita High score podle posledneho ulozeneho High score.
    /// </summary>
    public void CalcHighScore()
    {
        hst = PlayerPrefs.GetFloat("HighScore", 0);

        hsminutes = ((int)hst / 60).ToString();
        hsseconds = (hst % 60).ToString("f2");

        hscore = hsminutes + ":" + hsseconds;
    }

    /// <summary>
    /// Metoda, ktera prepisuje string "score" na aktualni cas ve formatu minut a sekund.
    /// </summary>
    void HighScoreToString()
    {
        score = minutes + ":" + seconds;
    }
}
