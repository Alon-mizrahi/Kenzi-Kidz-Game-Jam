using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDisk : MonoBehaviour
{
    public GM GM;


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Player")
        {
            GM.Win();
            //start particals and other stuff
        }
    }

}
