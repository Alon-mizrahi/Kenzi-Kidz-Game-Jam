using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class BaseDisk : MonoBehaviour {

public GameObject[] TotalSlits = new GameObject[11];
int index =0;

public bool isPrimary;
Transform[] allChildren;
public Material Colour;

private void Awake() {
    if(Colour.name == "Blue" || Colour.name == "Yellow" || Colour.name == "Red"){isPrimary = true;}
    else{isPrimary = false;}
}

private void Start() {
    allChildren = gameObject.GetComponentsInChildren<Transform>();

    foreach(Transform child in allChildren)
    {
        if(child.gameObject.tag == "Slit")
        {
            TotalSlits[index] = child.gameObject;
            index++;
        }
    }
}


    
    private void Update() {

        if(Application.isEditor)
        {
            allChildren = gameObject.GetComponentsInChildren<Transform>();

            foreach(Transform child in allChildren)
            {
                if(child.gameObject.tag == "DiskSlice")
                {
                    child.GetComponent<Renderer>().material = Colour;
                }

            }

        }

        if(Application.isPlaying)
        {
            if(DiskComplete()){gameObject.SetActive(false);}
        }
        
        

        
        
    }


    bool DiskComplete()
    {
        for(int i=0; i<TotalSlits.Length; i++)
        {
            if(TotalSlits[i] != null && !TotalSlits[i].GetComponent<Slit>().isComplete)//if a slit is not complete
            {
                return false;
            }
        }
        return true;
    }


}
