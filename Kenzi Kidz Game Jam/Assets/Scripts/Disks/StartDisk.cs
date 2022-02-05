using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDisk : MonoBehaviour
{
Transform[] allChildren;

//Individual Rotation
public float RotationOffset = 0f;
Vector3 _rotation = new Vector3 (0,0,0);

public TapColourChange Player;


private void Start() {
    _rotation = new Vector3(0,RotationOffset,0);

    allChildren = gameObject.GetComponentsInChildren<Transform>();
}

    private void Update() {

        transform.Rotate(_rotation*Time.deltaTime);

        if(Player.hasStarted){
            //gameObject.SetActive(false);
            for (int i=0; i<allChildren.Length; i++){
                allChildren[i].GetComponentInChildren<Rigidbody>().isKinematic = false;
                allChildren[i].GetComponentInChildren<Rigidbody>().AddExplosionForce(5f, Vector3.zero, 1f, 3f);
            }
        }
    }

}
