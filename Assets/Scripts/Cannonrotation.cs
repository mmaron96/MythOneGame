using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonrotation : MonoBehaviour {
    public float rotationSpeed = 3f;

   // private SpriteRenderer theSpriteRenderer;

    // Use this for initialization
    void Start () {
       // theSpriteRenderer = GetComponent<>
    }
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Vertical");
        print(transform.rotation.z);

        if(inputX > 0 && transform.rotation.z <= 57.952/120)
        {
            transform.Rotate(Vector3.forward, inputX * rotationSpeed);
        }
        else if(inputX < 0 && transform.rotation.z >= -38.535/120)
        {
            transform.Rotate(Vector3.forward, inputX * rotationSpeed);
        }



    }
}
