using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	public GameObject newBall;
	Paddle paddle;
	Vector3 paddlePos;
	
	void Start(){
		paddle = GameObject.FindObjectOfType<Paddle>();
	}

	void OnTriggerEnter2D(Collider2D trigger){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoseLife();
		int temp = levelManager.GetLives();
		if(temp <= 0){//no lives left
			levelManager.ResetLives();
			levelManager.LoadLevel("Lose");
		} else{//player has at least 1 life left
			paddlePos = paddle.transform.localPosition;
			Instantiate(newBall, paddlePos, paddle.transform.rotation);//Ball Start function should position it correctly
		}
	}
	
	
}
