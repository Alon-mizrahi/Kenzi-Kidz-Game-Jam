using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//skrr skrr

public class GM : MonoBehaviour
{

    //UI Tings
    public Image EndOfRoundDisplay;
    public Text Score;
    public Text Wintxt;
    public Text Failtxt;

    public Text StartTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call to activate win condition.
    public void Win()
    {
        Debug.Log("You Won!");
        Wintxt.enabled = true;
        EndOfRoundDisplay.gameObject.SetActive(true);
    }

    // Call to activate fail condition.
    public void Fail()
    {
        Debug.Log("You Lost:(");
        Failtxt.enabled = true;
        EndOfRoundDisplay.gameObject.SetActive(true);
    }

    // Called from Pause button GUI. 
    // Activate pause menu
    public void Pause()
    {
        if(Time.timeScale == 1f){Time.timeScale = 0f;}
        else if(Time.timeScale == 0f){Time.timeScale = 1f;}
        
    }

    public void StartScoreCount()
    {
        StartTxt.enabled = false;
        


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
