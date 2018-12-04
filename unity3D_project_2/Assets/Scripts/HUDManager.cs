using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

public Text scoreLabel;
	public static HUDManager instance;

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
		ResetHud();
		
	}
	
	// Update is called once per frame
	public	void ResetHud () {
		scoreLabel.text = "score: " + GameManager.instance.score;
	}
	
}
