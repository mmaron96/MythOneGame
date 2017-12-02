using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour {
    private bool fired = false;
    public float xVel = 5f;
    public float yVel = 0f;
    public int shots = 3;
    public float time = 6f;
    private float winTime;
    private bool won;
    private Text txt;
    private GameObject cannon;
    private GameObject winCanvas;
    private GameObject shotCanvas;
    private Transform ejectPoint;
    private Rigidbody2D theRigidBody;
    private Vector2 initPos;
    private int SceneNum;
    private float timer;
    private float loseTimer;
    // Use this for initialization
    void Start () {

		cannon = GameObject.Find("cannon");
        ejectPoint = cannon.transform.Find("EjectPoint");
        winCanvas = GameObject.Find("WinCanvas");
        winCanvas.SetActive(false);

        won = false;

        shotCanvas = GameObject.Find("ShotCanvas");
        txt = shotCanvas.AddComponent<Text>();
        txt.text = "Shots: " + shots;
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        txt.font = ArialFont;
        txt.material = ArialFont.material;
        SceneNum = SceneManager.GetActiveScene().buildIndex;
        initPos = transform.position;
        timer = time;
        loseTimer = timer + 3f;
        winTime = time;
    }
	
	// Update is called once per frame
	void Update () {
        theRigidBody = GetComponent<Rigidbody2D>();

        if(shots <= 0 && !won)
        {
            loseTimer -= Time.deltaTime;
            if (loseTimer <= 0) {
                SceneManager.LoadScene(0);
            }
        }

        if (won) {
            winTime -= Time.deltaTime;
            if (winTime <= 0f) {
                SceneManager.LoadScene(SceneNum + 1);
            }
        }

        if (fired == true) {
                timer -= Time.deltaTime;
            if (timer <= 0f) {
                timer = time;
                fired = false;
                transform.position = initPos;
                theRigidBody.velocity = new Vector2(0, 0);
            }
        }
        if (fired != true) {
            
            bool fireButton = Input.GetButtonDown("Jump");
            if (fireButton && shots > 0) {
                fired = true;
                shots -= 1;
                txt.text  = "Shots: " + shots;
                fire();
            }
        }
	}

    void fire() {
        transform.position = ejectPoint.position;
        float z = cannon.transform.rotation.z;
        theRigidBody.velocity = new Vector2(xVel*Mathf.Cos(z),yVel*Mathf.Sin(z));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Win"))
        {
            winCanvas.SetActive(true);
            won = true;
            //GUI.Button(Rect(Screen.height - 10, Screen.width - 40), "You Win!");
        }
    }
}
