using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class truckControll : MonoBehaviour {

    public WheelJoint2D frontWheel;
    public WheelJoint2D backWheel;

    JointMotor2D frontMotor;
    JointMotor2D backMotor;

    public float frontSpeed;
    public float backSpeed;

    public float frontTorque;
    public float backTorque;

    public Text score;
    public GameObject gameOverCanv;
    public Text finalScore;
    public GameObject gameCanv;
    public Text scoreCoins;
    public bool isAlive = true;
    public Text finalScoreCoins;
    int scoreC = 0;
    // Use this for initialization
    void Start () {
        gameCanv.SetActive(true);
        gameOverCanv.SetActive(false);
        score.text = transform.position.x.ToString("0.00");
        scoreCoins.text = scoreC.ToString();
        isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isAlive)
        {
            score.text = transform.position.x.ToString("0.00");
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                frontMotor.motorSpeed = frontSpeed * -1;
                frontMotor.maxMotorTorque = frontTorque;
                frontWheel.motor = frontMotor;

                backMotor.motorSpeed = frontSpeed * -1;
                backMotor.maxMotorTorque = frontTorque;
                backWheel.motor = backMotor;
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                frontMotor.motorSpeed = backSpeed * -1;
                frontMotor.maxMotorTorque = backTorque;
                frontWheel.motor = frontMotor;

                backMotor.motorSpeed = backSpeed * -1;
                backMotor.maxMotorTorque = backTorque;
                backWheel.motor = backMotor;
            }
            else
            {
                frontWheel.useMotor = false;
                backWheel.useMotor = false;

            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        isAlive = false;
        if (col.tag=="Land")
        {
            gameOverCanv.SetActive(true);
            finalScore.text = score.text;
            finalScoreCoins.text = scoreCoins.text;
            gameCanv.SetActive(false);
            frontWheel.useMotor = false;
            backWheel.useMotor = false;
        }
        if (col.tag=="Coin")
        {
            scoreC++;
            scoreCoins.text = scoreC.ToString();
            Destroy(col.gameObject);
        }
    }
}
