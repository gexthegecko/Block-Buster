using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level_09 : MonoBehaviour {

	//TODO: add code to lower the Eyes and Shades once Shield bricks are all destroyed.  Also destroy the two
	//lower invincible bricks once this happens.
	
	public GameObject[] defenseWall;
	public GameObject smoke;
	public GameObject eyes;
	List<GameObject> shield;//all bricks in Defense Wall GameObject
	int storedSize;
	bool eyesMoved = false;
	
	void Start(){
		/*GameObject temp = GameObject.Find("Defense Wall");
		Transform[] temp2 = temp.GetComponentsInChildren<Transform>();
		foreach(Transform t in temp2){
			if(t.gameObject.name != "Defense Wall"){//for some reason the gameobject gets added in addition to its children
				shield.Add(t.gameObject);
				Debug.Log ("Added " + t.gameObject.name);
			}
		}
	
		storedSize = shield.Count;
		if(storedSize == 0){
			Debug.LogError("List found no objects!");
		}
		Debug.Log ("List has " + storedSize + " elements.");*/
		
		storedSize = defenseWall.Length;
	}
	
	void Update(){
		//Debug.Log("storedSize = " + storedSize);
		if(storedSize > 2){
			int minus = 0;
			for(int i = 0; i < defenseWall.Length; i++){
				if(defenseWall[i] == null){
					minus++;
				}
			}
			if(storedSize > defenseWall.Length - minus){
				storedSize = defenseWall.Length - minus;
			}
		}
		if(storedSize == 2){
			Instantiate(smoke, defenseWall[16].transform.position, Quaternion.identity);
			DestroyObject(defenseWall[16]);
			Instantiate(smoke, defenseWall[17].transform.position, Quaternion.identity);
			DestroyObject(defenseWall[17]);
			storedSize = 0;
		}
		if(storedSize == 0 && !eyesMoved){
			GameObject ball = GameObject.Find ("Ball");
			if(ball.transform.position.y <= 8.8f){
				Vector3 moveEyes = new Vector3(0f, -3.8f, 0);
				eyes.transform.position = moveEyes;
				eyesMoved = true;
			}
		}
		
		
		/*if(shield.Count > 0){//if List still exists
			shield.TrimExcess();
			if(storedSize < shield.Count){
				storedSize = shield.Count;
				Debug.Log("Brick left in Defense Wall = " + storedSize);
				if(storedSize == 2){//only invincible bricks left in array
					DestroyObject(shield[1]);
					DestroyObject(shield[0]);
				}
			}
		}*/
	}
}
