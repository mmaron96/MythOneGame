using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool fireButton = Input.GetButtonDown("Jump");
		if (fireButton) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
