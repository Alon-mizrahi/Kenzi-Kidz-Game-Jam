using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDisk : MonoBehaviour
{
Transform[] allChildren;

//Individual Rotation
public float RotationOffset = 0f;
Vector3 _rotation = new Vector3 (0,0,0);

public Vector3 ExplodeForce;

public TapColourChange Player;
public GM GM;

public bool audioPlay;
private void Start() {
    _rotation = new Vector3(0,RotationOffset,0);

    allChildren = gameObject.GetComponentsInChildren<Transform>();

    audioPlay = false;
}

    private void LateUpdate() {

        transform.Rotate(_rotation*Time.deltaTime);

        if(Input.GetMouseButtonDown(1)){
            for (int i=0; i<allChildren.Length; i++){
                allChildren[i].GetComponentInChildren<Rigidbody>().isKinematic = false;
                allChildren[i].GetComponentInChildren<Rigidbody>().AddRelativeForce(ExplodeForce, ForceMode.Impulse);
            }

            Player.hasStarted = true;
            GM.StartScoreCount();
            if (audioPlay == false){
                GM.GetComponent<AudioSource>().Play();
                audioPlay = true;
            } 
        }
    }

}
