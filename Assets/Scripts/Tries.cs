using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tries : MonoBehaviour {

	LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		string tries = levelManager.GetTries();
		gameObject.GetComponent<Text>().text = tries;
	}
}
