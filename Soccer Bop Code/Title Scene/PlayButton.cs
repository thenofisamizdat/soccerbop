using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// This listens for the user to press the play button, and stops further presses having action after a press.
// It will then check for an internet connection and if one exists, attempt to login with fb, if not it will log in as guest.

public class PlayButton : MonoBehaviour {

	void Start () {
		this.GetComponent<Button> ().onClick.AddListener (this.changeScene);
	}

	void changeScene(){
		if (!FacebookLogin.SFB.clicked) {
			if (FacebookLogin.SFB.offline) {
                FacebookLogin.SFB.clicked = true;
				Application.LoadLevel("StickerBook");
			}
			else{
                FacebookLogin.SFB.login();
			}
		}
	}

	
}
