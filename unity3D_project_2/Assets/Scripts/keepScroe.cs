﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepScroe : MonoBehaviour {

	public static keepScroe instance;
	void Awake(){
		if (instance == null){
			instance = this;
		}
		else if (instance!=this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
