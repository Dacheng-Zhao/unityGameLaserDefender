﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	// Use this for initialization
	public ScoreKeeper ScoreKeeper;
	void Start () {
		Text mytext = GetComponent<Text> (); 
	
		mytext.text = ScoreKeeper.score.ToString ();
		ScoreKeeper.Reset ();
	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
