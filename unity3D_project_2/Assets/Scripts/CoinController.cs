using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
	public float RotationSpeed = 100;
	
	
	// Update is called once per frame
	void Update () {
		float angleRot = RotationSpeed * Time.deltaTime;
		transform.Rotate(Vector3.up * angleRot, Space.World);
	}
}
