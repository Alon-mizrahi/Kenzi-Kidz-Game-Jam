using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public ParticleSystem splash;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "floor")
        {
            var main = splash.main;
            splash.transform.position = this.transform.position;
            main.startColor = this.gameObject.GetComponent<Renderer>().material.color;
            splash.Play();
        }
    }
}

