using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

	public DeathObserver death;

	private bool killed = false;
	private SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Bullet")) {
			if (!killed) {
				killed = true;
				death.TargetDeath ();
			}

			sprite.color = Color.red;
		}
	}

}
