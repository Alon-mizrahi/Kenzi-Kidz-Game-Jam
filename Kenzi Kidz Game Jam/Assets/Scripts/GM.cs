using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{

    //UI Tings
    public Image EndOfRoundDisplay;
    public Text Score;
    public Text Wintxt;
    public Text Failtxt;


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
        EndOfRoundDisplay.enabled = true;
    }

    // Call to activate fail condition.
    public void Fail()
    {
        Debug.Log("You Lost:(");
        Failtxt.enabled = true;
        EndOfRoundDisplay.enabled = true;
        EndOfRoundDisplay.enabled = true;
    }

    // Called from Pause button GUI. 
    // Activate pause menu
    public void Pause()
    {
        if(Time.timeScale == 1f){Time.timeScale = 0f;}
        else if(Time.timeScale == 0f){Time.timeScale = 1f;}
        
    }
}
