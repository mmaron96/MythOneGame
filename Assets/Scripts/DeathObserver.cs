using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObserver : MonoBehaviour {

	public int targetNum = 2;
	public float timer = 12f;
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
		if (targetNum == 0) {
			if (!won) {
				winCanvas.SetActive (true);
				won = true;
			} else {
				timer -= 0.1f;
				if (timer >= 0) {
					//TODO go to Next Scene
				}
			}
		}
	}

	public void TargetDeath(){
		targetNum -= 1;
	}
}
