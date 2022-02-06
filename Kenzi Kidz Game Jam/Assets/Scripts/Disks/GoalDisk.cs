using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDisk : MonoBehaviour
{
    public GM GM;


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<TapColourChange>().EndofRound = true;
            GM.Win();
            other.gameObject.GetComponent<Animator>().StopPlayback();
            other.gameObject.GetComponent<Rigidbody>().constraints = 0;

            //start particals and other stuff
        }
    }

}
