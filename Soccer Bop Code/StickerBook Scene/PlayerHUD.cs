using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// Controls the Heads Up Display in the sticker book scene, updating fans, plays, and coins.

public class PlayerHUD : MonoBehaviour {

	void Update () {
		try{
			if (this.name == "totalFans") {
				this.GetComponent<Text> ().text = PlayerObject.player[Login.fbuid].fans.ToString ();
			}
			else if (this.name == "totalPlays") {
				this.GetComponent<Text> ().text = "x"+PlayerObject.player[Login.fbuid].lives.ToString ();
			}
			else if (this.name == "totalCoins") {
				this.GetComponent<Text> ().text = PlayerObject.player[Login.fbuid].coins.ToString ();
			}
		}
		catch{}
	}
}
