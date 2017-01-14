using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

// Neil Byrne - 2015

// This timer regenerates player lives after they run out.

public class LifeRegenerate : MonoBehaviour {

	int timer = 300;
	int timeGone;
	// Use this for initialization
	void OnEnable () {
		Invoke ("countdown", 1);
	}

	void countdown(){
		timeGone = (int)(DateTime.UtcNow.Subtract (new DateTime (1970, 1, 1))).TotalSeconds - PlayerObject.player[Login.fbuid].lastPlayed;
		Debug.Log ("time gone " + timeGone);
		if (timeGone <= timer) {

			int min = (timer - timeGone) / 60;
			int sec = (timer - timeGone) - (min * 60);
			if (sec < 10){
				this.transform.FindChild ("timeLeft").GetComponent<Text>().text = "0" + min + ":0" + sec;
			}
			else {
				this.transform.FindChild ("timeLeft").GetComponent<Text>().text = "0" + min + ":" + sec;
			}

			Invoke ("countdown", 1);
		}
		else {
			PlayerObject.player[Login.fbuid].lives ++;
		}
	}
    
}
