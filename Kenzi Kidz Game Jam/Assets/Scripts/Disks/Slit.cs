using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slit : MonoBehaviour
{
    bool isDiskPrimary;
    Material[] MaterialList;

    public string BaseColour;
    public string SlitColour;
    string PlayerColour;

    public string[] TargetColours;

    bool _Failed = false;
    public bool isComplete = false;
    GM GM;


    // Start is called before the first frame update
    void Start()
    {
        MaterialList = transform.parent.transform.parent.GetComponent<Rotation>().MaterialList;

        BaseColour = transform.parent.GetComponent<BaseDisk>().Colour.name;
        SlitColour =gameObject.GetComponent<Renderer>().material.name;

        GM = GameObject.FindWithTag("GM").GetComponent<GM>();

        isDiskPrimary = transform.parent.GetComponent<BaseDisk>().isPrimary;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {   
            PlayerColour = other.gameObject.GetComponent<TapColourChange>().Colour;
            
            if(CompareColours())//correct colour
            {
                ChangeColour(other.gameObject);
                // if (isComplete == false)
                // {
                //     FindObjectOfType<TapColourChange>().colourSplash();
                // }
            }
            else{
                if(!_Failed){_Failed=true;GM.Fail();}
                
            }
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Player")
        {   
            
            PlayerColour = other.gameObject.GetComponent<TapColourChange>().Colour;
            
            if(!CompareColours() && !_Failed)//Wrong colour
            {
                _Failed=true;
                GM.Fail();
            }
        }
    }






    bool CompareColours()
    {

        if(!isComplete)
        {
           for(int i = 0; i<TargetColours.Length; i++ )
            {
                if(PlayerColour == TargetColours[i])
                { 
                    return true;
                }
            }
            return false; 
        }
        return true;
        
    }

    void ChangeColour(GameObject Player)
    {
        //If Disk Primary Colour Slit is White??
        if(isDiskPrimary)
        {
            if(SlitColour == "White (Instance)" || SlitColour == "White")
            {
                SlitColour = Player.GetComponent<TapColourChange>().Colour;
                        
                for(int i=0; i<MaterialList.Length; i++)
                {
                    if(SlitColour == MaterialList[i].name)
                    {
                        //FindObjectOfType<TapColourChange>().colourSplash();
                        gameObject.GetComponent<Renderer>().material = MaterialList[i];
                        if (isComplete == false)
                        {
                            Player.gameObject.GetComponent<AudioSource>().Play();
                            FindObjectOfType<TapColourChange>().colourSplash();
                        }
                        break;
                    }
                }
            }
        }
        //Disk is Secondary colour
        //If Disk is a Secondary colour Slit can be white or a primary colour;
        else
        {
            if(SlitColour == "Red (Instance)" || SlitColour == "Red")
            {
                if(Player.GetComponent<TapColourChange>().Colour == "Yellow")
                {
                    SlitColour = "Orange";
                }
                else if(Player.GetComponent<TapColourChange>().Colour == "Blue")
                {
                    SlitColour = "Violet";
                }
            }
            else if(SlitColour == "Yellow (Instance)" || SlitColour == "Yellow")
            {
                if(Player.GetComponent<TapColourChange>().Colour == "Red")
                {
                    SlitColour = "Orange";
                }
                else if(Player.GetComponent<TapColourChange>().Colour == "Blue")
                {
                    SlitColour = "Green";
                }
            }
            else if(SlitColour == "Blue (Instance)" || SlitColour == "Blue")
            {
                if(Player.GetComponent<TapColourChange>().Colour == "Yellow")
                {
                    SlitColour = "Green";
                }
                else if(Player.GetComponent<TapColourChange>().Colour == "Red")
                {
                    SlitColour = "Violet";
                }
            }
            else if(SlitColour == "White (Instance)" || SlitColour == "White")
            {
                SlitColour = Player.GetComponent<TapColourChange>().Colour;
            }

            //Change colour from list
            for(int i=0; i<MaterialList.Length; i++)
            {
                if(SlitColour == MaterialList[i].name)
                {
                    //FindObjectOfType<TapColourChange>().colourSplash();
                    gameObject.GetComponent<Renderer>().material = MaterialList[i];
                    if (isComplete == false)
                    {
                        Player.gameObject.GetComponent<AudioSource>().Play();
                        FindObjectOfType<TapColourChange>().colourSplash();
                    }
                    break;
                }
            }
        }

        if(SlitColour == BaseColour)
        {
            isComplete = true;
        }
    }

}
