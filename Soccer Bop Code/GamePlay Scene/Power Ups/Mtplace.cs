using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// When this class is invoked, it sets tells game state controller that power up 3 - the multi touch - is in use.
// Players will now get two touches before the end of their turn.
// This lasts for 6 seconds or until the user takes both shots and the game state is then returned to normal.

public class Mtplace : MonoBehaviour {


	int countDown;
	// Use this for initialization
	void Start () {
		countDown = 6;
		this.GetComponent<Button> ().onClick.AddListener (this.twoTouch);
	}
	
	int uses = 0;

	void twoTouch(){
		if ((uses < 1)&&(GameControl.gameStart)) {
			if (GameControl.powerUpinUse == 0){
				uses ++;
				GameControl.powerUpinUse = 3;
				this.GetComponent<Image>().material = GameObject.Find ("BlackAndWhite").GetComponent<Image>().material;
				
				cDown ();
			}
		}
	}

	void cDown(){
		
		countDown--;
		if (countDown <= 0) {
			countDown = 6;
			GameControl.powerUpinUse = 0;
		} else {
			Invoke ("cDown", 1);
		}
	}
}
