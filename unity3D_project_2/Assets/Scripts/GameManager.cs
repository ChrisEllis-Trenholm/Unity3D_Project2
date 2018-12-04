using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
public int HighScore = 0;
public int level = 1;
HUDManager hudManager;
public int HighestLevel = 2;
public int score = 0;
	// Use this for initialization
public static GameManager instance;
	void Awake(){
		if (instance == null){
			instance = this;
		}
		else if (instance!=this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		hudManager = FindObjectOfType<HUDManager>();
	}
	public void IncreaseScore(int amount){
		score += amount;
		hudManager.ResetHud();
		if(score > HighScore){
			HighScore = score;
		}
		
		
	}
	public void reset(){
		score = 0;
		hudManager.ResetHud();
		level = 1;
		SceneManager.LoadScene("Level1");
	}
	public void increaseLevel(){
		if (level<HighestLevel){
			level++;
		}
		else {
			level = 1;
		}
		SceneManager.LoadScene("Level"+level);
	}
}
