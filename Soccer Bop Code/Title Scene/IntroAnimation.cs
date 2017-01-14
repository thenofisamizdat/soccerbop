using UnityEngine;
using DG.Tweening;

// Neil Byrne - 2015

// This classcontrols the intro Animation. 
// The animation is in 2 phases, viewing into the stadium and then panning to title screen.

public class IntroAnimation : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Invoke ("moveCrowd", 3.5f);
		this.transform.DOMove (new Vector3 (-0.02f, -4.74f, 0f), 3);
		GameObject.Find("stadiumMove").transform.DOMove (new Vector3 (-0.0f, -0.0f, 0f), 3);
	}

	void moveCrowd(){
		this.transform.DOMove (new Vector3 (-0.02f, 0.68f, 0f), 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
