using UnityEngine;

// Neil Byrne - 2015

// When this class is invoked, it sets tells game state controller that power up 1 - the keeper - is in use.
// This places a moving keeper in front of the opponent's goal.
// This lasts for 6 seconds and the game state is then returned to normal.

public class KeeperBadPlace : MonoBehaviour {

	public GameObject offscreen;
	int countDown;
	public GameObject keeper1;
	// Use this for initialization
	void Start () {
		countDown = 6;
	}
	
	void OnMouseDown(){
		if (GameControl.powerUpinUse == 0){
			keeper1.SetActive (true);
			this.transform.position = new Vector2 (offscreen.transform.position.x, offscreen.transform.position.y);
			GameControl.powerUpinUse = 1;
			if (this.gameObject.name == "keeperPowerUpBadHolder") {
				powerUpHolder.place1 = 0;
			}
			else if (this.gameObject.name == "keeperPowerUpBadHolder2") {
				powerUpHolder.place2 = 0;
			}
			else if (this.gameObject.name == "keeperPowerUpBadHolder3") {
				powerUpHolder.place3 = 0;
			}
			cDown ();
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
