using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDisk : MonoBehaviour
{
    public GM GM;
    bool _Won = false;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Player" && !_Won)
        {
            _Won = true;
            GM.Win();
            //start particals and other stuff
        }
    }

}
