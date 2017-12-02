﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FiringScript : MonoBehaviour {
    private bool fired = false;
    public float xVel = 5f;
    public float yVel = 0f;
    public int shots = 3;
    public float time = 6f;
    
	public GameObject bullet;

	private float winTime;
    private bool won;
    private Text txt;
    private GameObject cannon;
    private GameObject winCanvas;
    //private GameObject shotCanvas;
    private Transform ejectPoint;

    //private Rigidbody2D theRigidBody;
    private Vector2 initPos;
    private int SceneNum;
    private float timer;
    private float loseTimer;
    // Use this for initialization
    void Start () {

		cannon = GameObject.Find("Cannon");
        ejectPoint = cannon.transform.Find("EjectPoint");
        
		//winCanvas = GameObject.Find("WinCanvas");
        //winCanvas.SetActive(false);

        //won = false;

        //shotCanvas = GameObject.Find("ShotCanvas");
        //txt = shotCanvas.AddComponent<Text>();
        //txt.text = "Shots: " + shots;
        //Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        //txt.font = ArialFont;
        //txt.material = ArialFont.material;
        
		SceneNum = SceneManager.GetActiveScene().buildIndex;
        initPos = transform.position;
        timer = time;
        loseTimer = timer + 3f;
        winTime = time;
    }
	
	// Update is called once per frame
	void Update () {
        if (fired != true) {
            
            bool fireButton = Input.GetButtonDown("Jump");
            if (fireButton) {
                fired = true;
                fire();
            }
        }

		if (fired) {
			timer -= 0.1f;
			if (timer <= 0f) {
				timer = time;
				fired = false;
			}
		}
	}

    void fire() {
		GameObject tmpBullet = Instantiate (bullet);
        tmpBullet.transform.position = ejectPoint.position;
		float z = cannon.transform.rotation.z;
		var theRigidBody = tmpBullet.GetComponent<Rigidbody2D>();
        theRigidBody.velocity = new Vector2(xVel*Mathf.Cos(z),yVel*Mathf.Sin(z));
    }

    
}
