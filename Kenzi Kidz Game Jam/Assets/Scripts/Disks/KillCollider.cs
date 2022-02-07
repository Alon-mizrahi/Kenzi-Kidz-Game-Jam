using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollider : MonoBehaviour
{
    GM GM;

    private void Start() {
        GM =  GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
        
    }

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player")
        {
            GM.Fail();
        }

        Destroy(other.gameObject);
    } 
}
