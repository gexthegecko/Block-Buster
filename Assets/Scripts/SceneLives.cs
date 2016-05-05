using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneLives : MonoBehaviour {
	
	LevelManager levelManager;
	int lives;
	
	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		lives = levelManager.GetLives();
		gameObject.GetComponent<Text>().text = lives.ToString();
	}
	
	void Update(){
		if(lives != levelManager.GetLives()){
			lives = levelManager.GetLives();
			gameObject.GetComponent<Text>().text = lives.ToString();
		}
	}
	
}
