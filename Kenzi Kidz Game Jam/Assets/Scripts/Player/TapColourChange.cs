using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapColourChange : MonoBehaviour
{


    // Start is called before the first frame update
    int CurrColour= 0;
    public string Colour;

    public Material[] Colours = new Material[3];
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = Colours[CurrColour];
        Colour = "Red";
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0)) //Input.GetTouch(0).phase == TouchPhase.Began
        {
            if(CurrColour ==0){ CurrColour=1; Colour = "Blue";}
            else if(CurrColour ==1){CurrColour=2; Colour = "Yellow";}
            else if(CurrColour ==2){CurrColour=0; Colour = "Red";}

            gameObject.GetComponent<Renderer>().material = Colours[CurrColour];
        }

    }


/*
//For Animation States and Speeds
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "DiskSlice" || other.gameObject.tag == "Slit")
        {
            if(other.transform.parent.GetComponent<BaseDisk>().RotationOffset == 0)
            {
                gameObject.GetComponent<Animator>().speed=1.7f;
            }
            else if(other.transform.parent.GetComponent<BaseDisk>().RotationOffset > 0)
            {
                gameObject.GetComponent<Animator>().speed=1.9f;
            }
            else if(other.transform.parent.GetComponent<BaseDisk>().RotationOffset < 0)
            {
                gameObject.GetComponent<Animator>().speed = -gameObject.GetComponent<Animator>().speed;
            }
        }
    }
*/

}
