using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// The hud displays the up to date score and time remaining in the game

public class HUD : MonoBehaviour {

	int score1 = 0;
	int score2 = 0;
	int time = 0;
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "MainScene") {
			score1 = GameControl.score1;
			score2 = GameControl.score2;
			time = (int)Countdown.timeLeft;
		}
		else if (Application.loadedLevelName == "HockeyBop"){
			score1 = HockeyBopGameControl.hockeyScore1;
			score2 = HockeyBopGameControl.hockeyScore2;
			time = HockeyBopGameControl.hockeyTimer;
		}
		if (this.name == "Score1") {
			this.GetComponent<Text>().text = "0" + score1;
		}
		else if (this.name == "Score2") {
			this.GetComponent<Text>().text = "0" + score2;
		}
		else if (this.name == "Timer") {
			this.GetComponent<Text>().text = "TIME: " + time;
		}
	}
}
