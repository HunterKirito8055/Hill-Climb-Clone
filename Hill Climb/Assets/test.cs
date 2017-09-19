using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {
    public Text score;
    public GameObject gameOverCanv;
    public Text finalScore;
    public GameObject gameCanv;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("enter");
        Debug.Log(col.tag);
        if (col.tag == "Land")
        {
            gameOverCanv.SetActive(true);
            finalScore.text = score.text;
            gameCanv.SetActive(false);
        }
    }
}
