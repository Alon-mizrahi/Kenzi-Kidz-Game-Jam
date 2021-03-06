using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapColourChange : MonoBehaviour
{


    // Start is called before the first frame update
    public int CurrColour= 0;
    public string Colour;
    public ParticleSystem splash;

    public bool hasStarted = false;
    public GM GM;
    public bool EndofRound = false;

    Animator CubeRoll;
    Animator JellyRoll;

    public bool AudioPlay;

    Vector3 startingPos;

    public Material[] Colours = new Material[3];

    public float speed = 0;

    public float amount = 0;

    void Start()
    {
        // CubeRoll = gameObject.GetComponent<Animator>();
        // JellyRoll = gameObject.GetComponent<Animator>();

        gameObject.GetComponent<Renderer>().material = Colours[CurrColour];
        Colour = "Red";
        // Vector3 originalPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Tap to change colour mechanic
        
        if( Input.GetMouseButtonDown(1) && (hasStarted == true)) //Input.GetTouch(0).phase == TouchPhase.Began
        {  
            if(CurrColour ==0){CurrColour=1; Colour = "Blue";}
            else if(CurrColour ==1){CurrColour=2; Colour = "Yellow";}
            else if(CurrColour ==2){CurrColour=0; Colour = "Red";}

            gameObject.GetComponent<Renderer>().material = Colours[CurrColour];
            colourSplash();
        }
        
        // Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * amount);
        // newPos.z = transform.position.z;
        // newPos.y = transform.position.y;

        // transform.position = newPos;
    }

    //Colour vfx testing below
    public void colourSplash(){
            var main = splash.main;
            main.startColor = this.gameObject.GetComponent<Renderer>().material.color;
            splash.transform.position = this.gameObject.transform.position;
            splash.Play();
    }



//For Animation States and Speeds
    // private void OnCollisionEnter(Collision other) 
    // {
    //     if(other.gameObject.tag == "DiskSlice" || other.gameObject.tag == "Slit")
    //     {
    //         if(other.transform.parent.GetComponent<BaseDisk>().RotationOffset >= 0) // forwards roll
    //         {
    //             CubeRoll.Play("CubeRoll");
    //             JellyRoll.Play("JellyRoll");  
    //         } 
    //         else if(other.transform.parent.GetComponent<BaseDisk>().RotationOffset < 0)// Backwards roll
    //         {
    //             CubeRoll.Play("BackwardsRoll");
    //             JellyRoll.Play("JellyBackRoll");
    //         }
    //     }

    //     if (other.gameObject.tag == "Goal"){
    //         JellyRoll.StopPlayback();
    //     }

    // }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "DiskSlice" || other.gameObject.tag == "Slit"){
            if (other.transform.parent.GetComponent<BaseDisk>().DiskComplete() == true){
                GM.GetComponent<AudioSource>().Play();
            }
        }
    }
    
}
