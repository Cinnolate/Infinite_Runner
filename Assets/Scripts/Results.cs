using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour {

    public Text score;
    public Text highScore;

	// Use this for initialization
	void Start () {
        score.text = "Score: " + GlobalVar.score;
        highScore.text = "High Score: " + GlobalVar.highScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
