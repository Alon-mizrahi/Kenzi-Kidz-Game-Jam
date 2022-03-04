using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//skrr skrr

public class GM : MonoBehaviour
{

    //UI Tings
    //public Image EndOfRoundDisplay;
    public Text Score;
    public Text Wintxt;
    public Text Failtxt;

    public Text StartTxt;
    public Text FinalScore;

    public Image PauseDisplay;

    public AudioClip WinSound;
    public AudioClip FailSound;

    bool isScoring = false;
    bool _Failed= false;
    float time;
    float ScoreVal=100f;

    // Start is called before the first frame update
    void Start()
    {
        Score.text =""+ScoreVal;
        Time.timeScale= 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isScoring && ScoreVal>0)
        {
            ScoreVal -= Time.deltaTime*1.5f;
            Score.text = ""+(int) ScoreVal;
        }
        else if(ScoreVal <=0 && !_Failed)
        {
            Fail();
        }

        if(Input.GetKeyDown(KeyCode.R)){Restart();}
    }

    // Call to activate win condition.
    public void Win()
    {
        isScoring = false;
        Debug.Log("You Won!");
        Wintxt.enabled = true;
        //EndOfRoundDisplay.gameObject.SetActive(true);

        FinalScore.text = ""+ (int)ScoreVal;
        gameObject.GetComponent<AudioSource>().clip = WinSound;
        gameObject.GetComponent<AudioSource>().Play();


    }

    // Call to activate fail condition.
    public void Fail()
    {
        Debug.Log("SKKRRRR");
        _Failed=true;
        gameObject.GetComponent<AudioSource>().clip = FailSound;
        gameObject.GetComponent<AudioSource>().Play();
        isScoring = false;
        Debug.Log("You Lost:(");
        Failtxt.enabled = true;
        //EndOfRoundDisplay.gameObject.SetActive(true);
        FinalScore.text = "000";
        Time.timeScale= 0f;
    }

    // Called from Pause button GUI. 
    // Activate pause menu
    public void Pause()
    {
        if(Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            PauseDisplay.gameObject.SetActive(true);
        }
        else if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            PauseDisplay.gameObject.SetActive(false);
        }
        
    }

    public void StartScoreCount()
    {
        StartTxt.enabled = false;
        isScoring = true;
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
