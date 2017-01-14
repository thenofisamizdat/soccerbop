using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// Displays the total fans a user has earned on the left page of the sticker book.

public class TeamFans : MonoBehaviour {
    
	void Update () {
		if (this.transform.parent.name == "pageLeft") {
			this.GetComponent<Text> ().text = teamCompletion.team1Fans.ToString ();
		}
		else if (this.transform.parent.name == "pageLeftB") {
			this.GetComponent<Text> ().text = teamCompletion.team2Fans.ToString ();
		}
	}
}
