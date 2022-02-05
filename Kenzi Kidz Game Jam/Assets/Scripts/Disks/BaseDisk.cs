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

//Individual Rotation
public float RotationOffset = 0f;
Vector3 _rotation = new Vector3 (0,0,0);


private void Awake() {
    if(Colour.name == "Blue" || Colour.name == "Yellow" || Colour.name == "Red"){isPrimary = true;}
    else{isPrimary = false;}
}

private void Start() {
    _rotation = new Vector3(0,RotationOffset,0);

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
            transform.Rotate(_rotation*Time.deltaTime);

            if(DiskComplete()){
                //gameObject.SetActive(false);
                for (int i=0; i<allChildren.Length; i++){
                    allChildren[i].GetComponentInChildren<Rigidbody>().isKinematic = false;
                    allChildren[i].GetComponentInChildren<Rigidbody>().AddExplosionForce(5f, Vector3.zero, 1f, 3f);
                }
            }
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
