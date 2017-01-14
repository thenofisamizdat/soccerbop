using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// When this class is invoked, it sets tells game state controller that power up 1 - the keeper - is in use.
// This places a moving keeper in front of the player's goal.
// This lasts for 6 seconds and the game state is then returned to normal.

public class KeeperPlace : MonoBehaviour {

	int countDown;
	public GameObject keeper1;
	// Use this for initialization
	void Start () {
		countDown = 6;
		this.GetComponent<Button> ().onClick.AddListener (this.keeper);
	}
	
	int uses = 0;
	void keeper(){
	if ((uses < 1) && (GameControl.gameStart)) {
			if (GameControl.powerUpinUse == 0) {
				uses ++;
				keeper1.SetActive (true);
				this.GetComponent<Image>().material = GameObject.Find ("BlackAndWhite").GetComponent<Image>().material;
				GameControl.powerUpinUse = 1;
				cDown ();
			}
		}
	}
	
	void cDown(){
		countDown--;
		if (countDown <= 0) {
			keeper1.SetActive (false);
			countDown = 6;
			GameControl.powerUpinUse = 0;
		} else {
			Invoke ("cDown", 1);
		}
	}
}
