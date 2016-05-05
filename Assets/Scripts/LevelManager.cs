using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	static bool easy = false;
	static bool normal = true;
	static bool hard = false;
	
	static string currentLevel;
	static string tries = "5";//default normal setting
	static int lives = 2;//default normal setting
	static int maxLives = 2;//default
		
		
	void Start(){
		if(Application.loadedLevelName == "Lose"){
			if(tries == "0"){
				GameObject retryButton = GameObject.Find ("Restart");
				if(!retryButton){
					Debug.LogError("Retry button not found!");
				}
				retryButton.SetActive(false);
			}
		}
	}
		
	public void LoadLevel(string name){
		Brick.breakableCount = 0;
		if(name == "Start Menu"){
			if(easy){
				tries = "infinite";
			}
			if(normal){
				tries = "5";
			}else if(hard){
				tries = "3";
			}
		}
		ResetLives();
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		ResetLives();
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void SetCurrentLevel(string s){
		currentLevel = s;
		//print ("Current level is " + currentLevel);
	}
	
	public void LoseLife(){
		lives--;
	}
	
	public void GainLife(){
		lives++;
	}
	
	public void ResetLives(){
		lives = maxLives;
	}
	
	public int GetLives(){
		return lives;
	}
	
	public string GetTries(){
		return tries;
	}
	
	public void Retry(){
		if(tries != "infinite"){
			int temp;
			temp = System.Convert.ToInt32(tries);
			temp--;
			tries = System.Convert.ToString(temp);
		}
		LoadLevel(currentLevel);
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			Brick.breakableCount = 0;
			LoadNextLevel();
		}
	}
	
	public void SetDifficulty(string s){
		if(s == "easy"){
			easy = true;
			normal = false;
			hard = false;
			tries = "infinite";
			maxLives = 3;
			lives = 3;
			//print ("Difficulty set to easy.");
		}else if(s == "normal"){
			easy = false;
			normal = true;
			hard = false;
			tries = "5";
			maxLives = 2;
			lives = 2;
			//print ("Difficulty set to normal.");
		}else{
			easy = false;
			normal = false;
			hard = true;
			tries = "3";
			maxLives = 2;
			lives = 2;
			//print ("Difficulty set to hard.");
		}
	}
	
	public string GetDifficulty(){
		if(easy){
			return "easy";
		}else if(normal){
			return "normal";
		}else{
			return "hard";
		}
	}
}
