using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Material[] MaterialList;


    //[SerializeField] private Vector3 _rotation;
    public float speed = 0.1f;
    Vector3 _rotation = new Vector3 (0,0,0);

    private void Start() {
        _rotation = new Vector3(0,speed,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotation*Time.deltaTime);

    }
}
