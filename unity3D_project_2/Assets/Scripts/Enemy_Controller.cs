using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour {

public float range = 2;
public float speed = 3;
int direction = 1;
private Vector3 initialPos;
	// Use this for initialization
	void Start () {
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float movementZ = speed * Time.deltaTime * direction;
		float newZ = transform.position.z + movementZ;
		if (Mathf.Abs(newZ - initialPos.z) > range){
			direction *= -1;
		}
		else{
			transform.position += new Vector3(0,0,movementZ);
		}
	}
}
