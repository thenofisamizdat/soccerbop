using UnityEngine;
using UnityEngine.Advertisements;

// Neil Byrne - 2015

// GameStart runs an ad, then randomly selects an opponent, clears the game state so it represents a new game, then starts the game.

public class GameStart : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		if (Advertisement.isReady()) {
			Advertisement.Show();
		}
		if (!Advertisement.isShowing) {
			selectCompTeam ();
		}
		else {
			waitForAd();
		}
	}
	
	void waitForAd(){
		if (!Advertisement.isShowing) {
			selectCompTeam ();
		}
		else {
			Invoke ("waitForAd", 1);
		}
	}
	
	public GameObject players;

	int scrollCrest = 0;
	void selectCompTeam(){
		if (scrollCrest < 10) {
			int ran = Random.Range (0, 32);
			while (preGameSelect.compTeam [ran] == GameControl.team1) {
				ran = Random.Range (0, 32);
			}
			GameControl.team2 = preGameSelect.compTeam [ran];
			if (scrollCrest < 5){
				Invoke("selectCompTeam", .1f);
			}
			else if (scrollCrest < 8){
				Invoke("selectCompTeam", .3f);
			}
			else if (scrollCrest < 10){
				Invoke("selectCompTeam", .5f);
			}
			scrollCrest++;
		}
		else {
			players.SetActive (true);
			Invoke("TeamSelected", 2);
		}
	}

	void TeamSelected(){
		EndGame.endGame ();
		GameControl.gameStart = true;
		this.gameObject.SetActive (false);
	}
}
