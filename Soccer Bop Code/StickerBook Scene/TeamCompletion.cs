using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// Displays a progress bar proportional to the % of the selected team has been collected.
// Also calculates how many fans are generated from selected teams collected players. 
// Some players generate more fans than others so slightly more consideration was required

public class TeamCompletion : MonoBehaviour {

	void Start () {
		if (this.transform.parent.parent.name == "pageLeft") {
			Invoke ("calculate1", 1);
		}

	}
	public static int team1Complete = 0;
	public static int team2Complete = 0;

	public static int team1Fans = 0;
	public static int team2Fans = 0;

	public static bool calc1 = false;
	public static bool calc2 = false;

	void calculate1(){
		string player = "";
		teamCompletion.team1Complete = 0;
		teamCompletion.team1Fans = 0;
		int playerAmt = 0;
		for (int i = 0; i < StickerPlace.teamLineUps[GameControl.team1].teamPlayers.Length; i++){
			player = StickerPlace.teamLineUps[GameControl.team1].teamPlayers[i];

			if (PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.ContainsKey(player)){
				teamCompletion.team1Complete ++;
				playerAmt = PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars[player];
				Debug.Log (player + playerAmt + "ff");
				if (i < 3){teamCompletion.team1Fans += (1000 * playerAmt);}
				else if (i == 3){teamCompletion.team1Fans += (3000 * playerAmt);}
				else if (i == 4){teamCompletion.team1Fans += (8000 * playerAmt);}
				else if (i == 5){teamCompletion.team1Fans += (20000 * playerAmt);}
			}
			player = "alt_" + StickerPlace.teamLineUps [GameControl.team1].teamPlayers [i].Substring(5);
			if (PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.ContainsKey(player)){
				teamCompletion.team1Complete ++;
				playerAmt = PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars[player];
				Debug.Log (player + playerAmt + "fg");
				if (i < 3){teamCompletion.team1Fans += (1000 * playerAmt);}
				else if (i == 3){teamCompletion.team1Fans += (3000 * playerAmt);}
				else if (i == 4){teamCompletion.team1Fans += (8000 * playerAmt);}
				else if (i == 5){teamCompletion.team1Fans += (20000 * playerAmt);}
			}
			float percent = ((float)teamCompletion.team1Complete / 12) * 100;
			this.GetComponent<Text> ().text = "TEAM COMPLETION: " + (int)percent + "%";
			float w = percent * 4;
			float h = this.transform.parent.FindChild("TopBar").GetComponent<RectTransform>().rect.height;
			this.transform.parent.FindChild("TopBar").GetComponent<RectTransform>().sizeDelta = new Vector2(w,h);
		}
	}

	void calculate2(){
		string player = "";
		teamCompletion.team2Complete = 0;
		teamCompletion.team2Fans = 0;
		int playerAmt = 0;
		for (int i = 0; i < StickerPlace.teamLineUps[pageFlip.newTeam].teamPlayers.Length; i++){
			player = StickerPlace.teamLineUps[pageFlip.newTeam].teamPlayers[i];

			if (PlayerObject.player[Login.fbuid].teams[pageFlip.newTeam].stars.ContainsKey(player)){
				Debug.Log (player + playerAmt + "dd");
				teamCompletion.team2Complete ++;
				playerAmt = PlayerObject.player[Login.fbuid].teams[pageFlip.newTeam].stars[player];
				if (i < 3){teamCompletion.team2Fans += (1000 * playerAmt);}
				else if (i == 3){teamCompletion.team2Fans += (3000 * playerAmt);}
				else if (i == 4){teamCompletion.team2Fans += (8000 * playerAmt);}
				else if (i == 5){teamCompletion.team2Fans += (20000 * playerAmt);}
			}
			player = "alt_" + StickerPlace.teamLineUps [pageFlip.newTeam].teamPlayers [i].Substring(5);
			if (PlayerObject.player[Login.fbuid].teams[pageFlip.newTeam].stars.ContainsKey(player)){
				teamCompletion.team2Complete ++;
				playerAmt = PlayerObject.player[Login.fbuid].teams[pageFlip.newTeam].stars[player];
				Debug.Log (player + playerAmt + "d2");
				if (i < 3){teamCompletion.team2Fans += (1000 * playerAmt);}
				else if (i == 3){teamCompletion.team2Fans += (3000 * playerAmt);}
				else if (i == 4){teamCompletion.team2Fans += (8000 * playerAmt);}
				else if (i == 5){teamCompletion.team2Fans += (20000 * playerAmt);}
			}
		}
		this.GetComponent<Text> ().text = "TEAM COMPLETION: " + ((float)(teamCompletion.team2Complete / 12) * 100);
		float percent = ((float)teamCompletion.team2Complete / 12) * 100;
		this.GetComponent<Text> ().text = "TEAM COMPLETION: " + (int)percent + "%";
		float w = percent * 4;
		float h = this.transform.parent.FindChild("TopBar").GetComponent<RectTransform>().rect.height;
		this.transform.parent.FindChild("TopBar").GetComponent<RectTransform>().sizeDelta = new Vector2(w,h);
	}
	// Update is called once per frame
	void Update () {
		if (this.transform.parent.parent.name == "pageLeft") {
			if (teamCompletion.calc1){
				calculate1 ();
				teamCompletion.calc1 = false;
			}
		}
		else if (this.transform.parent.parent.name == "pageLeftB"){
			if (teamCompletion.calc2){
				calculate2();
				teamCompletion.calc2 = false;
			}
		}
		else if (this.transform.parent.name == "BookCompletion"){
			float percent = ((float)PlayerObject.player[Login.fbuid].playersAmount / 384) * 100;
			this.GetComponent<Text> ().text = "STICKERBOOK COMPLETION: " + (int)percent + "%";
			float w = percent * 4;
			float h = this.transform.parent.FindChild("TopBar").GetComponent<RectTransform>().rect.height;
			this.transform.parent.FindChild("TopBar").GetComponent<RectTransform>().sizeDelta = new Vector2(w,h);
		}
	}
}
