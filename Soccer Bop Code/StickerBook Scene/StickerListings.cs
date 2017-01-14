using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// This class displays all the selected team's players in their sticker positions as defined in the StickerPlace class.
// It also checks to see if a user has collected each player, and if so will display that player in colour,
// along with the amount of times the player has been collected, and the fans the player generates.
// If the user does not have the player it will be displayed greyscale.
// Both home and away strips are displayed, totalling 12 players

public class StickerListings : MonoBehaviour {

	
	int pos = 0;
	string player = "";
	GameObject t;
	
	void Update () {
		try{
			if(this.transform.parent.parent.name == "pageLeft"){
				pos = int.Parse(this.transform.parent.name.Substring(7));
				if (pos > 6){
					pos = pos - 6;
					player = "alt_" + StickerPlace.teamLineUps [GameControl.team1].teamPlayers [pos-1].Substring(5);
					string oldPlayer = "alt_" + StickerPlace.teamLineUps [pageFlip.oldTeam].teamPlayers [pos-1].Substring(5);
					GameObject.Find (oldPlayer).transform.SetParent(GameObject.Find (pageFlip.oldTeam).transform.FindChild("away").transform);
					t = GameObject.Find (GameControl.team1).transform.FindChild("away").FindChild(player).gameObject;

					if (!PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.ContainsKey (player)){
						t.GetComponent<Image>().material = GameObject.Find ("BlackAndWhite").GetComponent<Image>().material;
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().text = "x 0";
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().color = Color.grey;
					}
					else {
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().text = "x " + PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars[t.name];
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().color = Color.cyan;
					}
				}
				else {
					t = GameObject.Find (GameControl.team1).transform.FindChild("home").FindChild (StickerPlace.teamLineUps [GameControl.team1].teamPlayers [pos-1]).gameObject;
					string oldPlayer = StickerPlace.teamLineUps [pageFlip.oldTeam].teamPlayers [pos-1];
					GameObject.Find (oldPlayer).transform.SetParent(GameObject.Find (pageFlip.oldTeam).transform.FindChild("home").transform);

					if (!PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.ContainsKey (t.name)){
						t.GetComponent<Image>().material = GameObject.Find ("BlackAndWhite").GetComponent<Image>().material;
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().text = "x 0";
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().color = Color.grey;
					}
					else {
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().text = "x " + PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars[t.name];
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().color = Color.cyan;
					}
				}
				
				t.GetComponent<RectTransform>().SetParent(this.transform);
				t.GetComponent<RectTransform> ().position = this.GetComponent<RectTransform> ().position;
				t.GetComponent<RectTransform> ().localScale = this.GetComponent<RectTransform> ().localScale;
			}
			else if(this.transform.parent.parent.name == "pageLeftB"){
				pos = int.Parse(this.transform.parent.name.Substring(7));
				if (pos > 6){
					pos = pos - 6;
					player = "alt_" + StickerPlace.teamLineUps [pageFlip.newTeam].teamPlayers [pos-1].Substring(5);
					string oldPlayer = "alt_" + StickerPlace.teamLineUps [pageFlip.oldTeam].teamPlayers [pos-1].Substring(5);
					GameObject.Find (oldPlayer).transform.SetParent(GameObject.Find (pageFlip.oldTeam).transform.FindChild("away").transform);
					
					t = GameObject.Find (pageFlip.newTeam).transform.FindChild("away").FindChild (player).gameObject;
					if (!PlayerObject.player[Login.fbuid].teams[pageFlip.newTeam].stars.ContainsKey (player)){
						t.GetComponent<Image>().material = GameObject.Find ("BlackAndWhite").GetComponent<Image>().material;
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().text = "x 0";
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().color = Color.grey;
					}
					else {
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().text = "x " + PlayerObject.player[Login.fbuid].teams[pageFlip.newTeam].stars[t.name];
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().color = Color.cyan;
					}
				}
				else {
					t = GameObject.Find (pageFlip.newTeam).transform.FindChild("home").FindChild (StickerPlace.teamLineUps [pageFlip.newTeam].teamPlayers [pos-1]).gameObject;
					string oldPlayer = StickerPlace.teamLineUps [pageFlip.oldTeam].teamPlayers [pos-1];
					GameObject.Find (oldPlayer).transform.SetParent(GameObject.Find (pageFlip.oldTeam).transform.FindChild("home").transform);
					if (!PlayerObject.player[Login.fbuid].teams[pageFlip.newTeam].stars.ContainsKey (t.name)){
						t.GetComponent<Image>().material = GameObject.Find ("BlackAndWhite").GetComponent<Image>().material;
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().text = "x 0";
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().color = Color.grey;
					}
					else {
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().text = "x " + PlayerObject.player[Login.fbuid].teams[pageFlip.newTeam].stars[t.name];
						this.transform.parent.FindChild("playerMultiples").GetComponent<Text>().color = Color.cyan;
					}

				}
				t.GetComponent<RectTransform>().SetParent(this.transform);
				t.GetComponent<RectTransform> ().position = this.GetComponent<RectTransform> ().position;
				t.GetComponent<RectTransform> ().localScale = this.GetComponent<RectTransform> ().localScale;
			}


		}
		catch{}
	}
}
