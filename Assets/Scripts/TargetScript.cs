using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

	private DeathObserver death;
	private GameObject thanatos;
	private bool killed = false;
	private SpriteRenderer sprite;
	private Rigidbody2D theRigidBody;
	// Use this for initialization
	void Start () {
		thanatos = GameObject.Find("Thanatos");
		death = thanatos.GetComponent<DeathObserver> ();
		sprite = GetComponent<SpriteRenderer> ();
		theRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Bullet")) {
			if (!killed) {
				killed = true;
				death.TargetDeath ();
				theRigidBody.constraints = RigidbodyConstraints2D.None;
			}

			sprite.color = Color.red;
		}
	}

}
