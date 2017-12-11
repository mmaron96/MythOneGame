using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathObserver : MonoBehaviour {

	public int targetNum = 2;
	private float timer = 30f;
	private GameObject winCanvas;
	private bool won = false;
	// Use this for initialization
	void Start () {
		winCanvas = GameObject.Find("WinCanvas");
		winCanvas.SetActive(false);

		won = false;
	}
	
	// Update is called once per frame
	void Update () {
		bool lvlSkip = Input.GetButtonDown("Cancel");
		if(lvlSkip){
			targetNum = 0;
		}
		if (targetNum == 0) {
			if (!won) {
				winCanvas.SetActive (true);
				won = true;
			} else {
				timer -= 0.1f;
				if (timer <= 0) {
					//TODO go to Next Scene
					SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
				}
			}
		}
	}

	public void TargetDeath(){
		targetNum -= 1;
	}
}
