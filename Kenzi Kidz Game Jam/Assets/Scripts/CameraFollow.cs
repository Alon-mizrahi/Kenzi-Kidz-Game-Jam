using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float LastPos;

	public float Adjustment;

	public Vector3 offset;

	private void LateUpdate() {
		StartCoroutine("Delay");

		float calc = LastPos-target.position.y;

		Debug.Log("Calc: "+ calc);

		if(LastPos - target.position.y < Adjustment && LastPos-target.position.y > Adjustment)
		{
			transform.position = new Vector3(target.position.x, LastPos ,target.position.z) + offset;

		}else{
			transform.position = target.position + offset;
		}

		

	}

	IEnumerator Delay()
	{
		yield return new WaitForSeconds(2f);
		LastPos = target.position.y;
		StopCoroutine("Delay");
	}





	/*
    public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void FixedUpdate ()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(target);
	}
	*/

    
}
