using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour {

public int Lives = 3;
Rigidbody rb;
public float walkSpeed;
public float jumpSpeed;
public AudioSource coinSound;
bool HasJumped = false;
Collider col;

Vector3 playerSize;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		col = GetComponent<Collider>();
		playerSize = col.bounds.size;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		WalkHandler();
		JumpHandler();
		
	}
	void WalkHandler(){
		float hAxis = Input.GetAxis("Horizontal");
		
		float vAxis = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3( vAxis * walkSpeed * Time.deltaTime, 0 , hAxis * walkSpeed * Time.deltaTime * -1);
		Vector3 newPos = transform.position + movement;
		rb.MovePosition(newPos);
	}
	void JumpHandler(){
	float jAxis = Input.GetAxis("Jump");
	if(jAxis > 0){
		bool isGrounded = checkGrounded();
		if(!HasJumped && isGrounded)
		{Vector3 jumpVector = new Vector3(0,jAxis * jumpSpeed,0);
		rb.AddForce(jumpVector,ForceMode.VelocityChange);
		HasJumped = true;
		}
	}
	else{
		HasJumped = false;
	}
	}

     bool checkGrounded()
    {
       Vector3 corner1 = transform.position + new Vector3(playerSize.x/2,-playerSize.y/2 + 0.01f,playerSize.z/2);
       Vector3 corner2 = transform.position + new Vector3(-playerSize.x/2,-playerSize.y/2 + 0.01f,playerSize.z/2);
       Vector3 corner3 = transform.position + new Vector3(playerSize.x/2,-playerSize.y/2 + 0.01f,-playerSize.z/2);
       Vector3 corner4 = transform.position + new Vector3(-playerSize.x/2,-playerSize.y/2 + 0.01f,-playerSize.z/2);
	   bool Grounded1 = Physics.Raycast(corner1,-Vector3.up,0.02f);
	   bool Grounded2 = Physics.Raycast(corner2,-Vector3.up,0.02f);
	   bool Grounded3 = Physics.Raycast(corner3,-Vector3.up,0.02f);
	   bool Grounded4 = Physics.Raycast(corner4,-Vector3.up,0.02f);
	   return (Grounded1 || Grounded2 || Grounded3 || Grounded4);
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Coin"){
		Destroy(other.gameObject);
		coinSound.Play();
		GameManager.instance.IncreaseScore(100);
		
		}
		else if(other.tag == "Enemy"){
		SceneManager.LoadScene("GameOver");
		
	
		}
		else if(other.tag == "Goal"){	
			GameManager.instance.increaseLevel();
		}
	}
}
