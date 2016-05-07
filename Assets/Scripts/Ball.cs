using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	//private Vector3 paddleToBallVector;
	private LevelManager levelManager;
	public const float verticalStartPos = 0.861f;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		//paddleToBallVector = this.transform.position - paddle.transform.position;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.SetCurrentLevel(Application.loadedLevelName);//for doing a retry
		//print ("Difficulty setting: " + levelManager.GetDifficulty());
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			Vector3 paddlePos = paddle.transform.position;
			paddlePos.y = verticalStartPos;//guarantee ball will be positioned correctly vertically when a new ball is Instantiated
			this.transform.position = paddlePos;// + paddleToBallVector;
			
			if(Input.GetMouseButtonDown(0)){
				hasStarted = true;
				float randomX = Random.Range(-2.5f, 2.5f);//randomize direction ball is fired
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(randomX, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		//ball sometimes doesn't trigger sound when brick is destroyed,
		//this only seems to be the case with instructor's game, mine (this one) works fine
		
		//print ("Ball velocity.x = " + rigidbody2D.velocity.x + "velocity.y = " + rigidbody2D.velocity.y);
		
		//reset ball position
		if(col.gameObject.name == "Lose Collider"){
			//gameObject.transform.position = paddle.transform.position + paddleToBallVector;
			DestroyObject(gameObject);
		}
		
		Vector2 wallBounce = GetComponent<Rigidbody2D>().velocity;
		
		if(col.gameObject.name == "Left Wall" && GetComponent<Rigidbody2D>().velocity.x < 2f){
			wallBounce.x += 1f;
			GetComponent<Rigidbody2D>().velocity = wallBounce;
		} else if (col.gameObject.name == "Right Wall" && GetComponent<Rigidbody2D>().velocity.x < 2f){
			wallBounce.x -= 1f;
			GetComponent<Rigidbody2D>().velocity = wallBounce;
		}		
		
		float tweakX;
		float tweakY;
		
		if(levelManager.GetDifficulty() == "easy"){
			if(GetComponent<Rigidbody2D>().velocity.x > 10f){
				tweakX = -1f;
			} else if(GetComponent<Rigidbody2D>().velocity.x < -10f){
				tweakX = 1f;
			} else if(GetComponent<Rigidbody2D>().velocity.x > 7f || GetComponent<Rigidbody2D>().velocity.x < -7f){
				tweakX = 0f;
			} else if(GetComponent<Rigidbody2D>().velocity.x > 4f){
				tweakX = Random.Range (0f, 0.01f);
			} else if (GetComponent<Rigidbody2D>().velocity.x < -4f){
				tweakX = Random.Range (0f, -0.01f);
			} else if(GetComponent<Rigidbody2D>().velocity.x > 0){
				tweakX = Random.Range (0f, 0.05f);
			}else{
				tweakX = Random.Range (0f, -0.05f);
			}
			if(GetComponent<Rigidbody2D>().velocity.y > 10f){
				tweakY = -0.4f;
			} else if(GetComponent<Rigidbody2D>().velocity.y < -10f){
				tweakY = 0.4f;
			} else if(GetComponent<Rigidbody2D>().velocity.y > 7f || GetComponent<Rigidbody2D>().velocity.y < -7f){
				tweakY = 0f;
			} else if(GetComponent<Rigidbody2D>().velocity.y > 4f){
				tweakY = Random.Range (0f, 0.01f);
			} else if (GetComponent<Rigidbody2D>().velocity.y < -4f){
				tweakY = Random.Range (0f, -0.01f);
			} else if(GetComponent<Rigidbody2D>().velocity.y > 0){
				tweakY = Random.Range (0f, 0.02f);
			}else{
				tweakY = Random.Range (0f, -0.02f);
			}
		}
		else if(levelManager.GetDifficulty() == "normal"){
			if(GetComponent<Rigidbody2D>().velocity.x > 17f){
				tweakX = -0.4f;
			} else if(GetComponent<Rigidbody2D>().velocity.x < -17f){
				tweakX = 0.4f;
			} else if(GetComponent<Rigidbody2D>().velocity.x > 15f || GetComponent<Rigidbody2D>().velocity.x < -15f){
				tweakX = 0f;
			} else if(GetComponent<Rigidbody2D>().velocity.x > 10f){
				tweakX = Random.Range (0f, 0.01f);
			} else if (GetComponent<Rigidbody2D>().velocity.x < -10f){
				tweakX = Random.Range (0f, -0.01f);
			} else if(GetComponent<Rigidbody2D>().velocity.x > 0){
				tweakX = Random.Range (0f, 0.05f);
			}else{
				tweakX = Random.Range (0f, -0.05f);
			}
			if(GetComponent<Rigidbody2D>().velocity.y > 17f){
				tweakY = -0.4f;
			} else if(GetComponent<Rigidbody2D>().velocity.y < -17f){
				tweakY = 0.4f;
			} else if(GetComponent<Rigidbody2D>().velocity.y > 15f || GetComponent<Rigidbody2D>().velocity.y < -15f){
				tweakY = 0f;
			} else if(GetComponent<Rigidbody2D>().velocity.y > 10f){
				tweakY = Random.Range (0f, 0.01f);
			} else if (GetComponent<Rigidbody2D>().velocity.y < -10f){
				tweakY = Random.Range (0f, -0.01f);
			} else if(GetComponent<Rigidbody2D>().velocity.y > 0){
				tweakY = Random.Range (0f, 0.05f);
			}else{
				tweakY = Random.Range (0f, -0.05f);
			}
		}
		else{//hard mode
			if(GetComponent<Rigidbody2D>().velocity.x > 0){
				tweakX = Random.Range (0f, 0.1f);
			}else{
				tweakX = Random.Range (0f, -0.1f);
			}
			if(GetComponent<Rigidbody2D>().velocity.y > 0){
				tweakY = Random.Range (0f, 1f);
			}else{
				tweakY = Random.Range (0f, -1f);
			}
		}
		
		Vector2 tweak = new Vector2(tweakX, tweakY);
		
		if(hasStarted){
			GetComponent<AudioSource>().Play ();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
