using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// When this class is invoked, it sets tells game state controller that power up 2 - the fire shot - is in use.
// It moves the opponent's players onto a separate rendering layer where they will no longer collide with other players or the ball.
// This lasts for 6 seconds or until the user takes a shot and the game state is then returned to normal.

public class FireshotPlace : MonoBehaviour {
	int countDown;

	void Start () {
		countDown = 6;
		this.GetComponent<Button> ().onClick.AddListener (this.fireShot);
	}
	
	int uses = 0;

	void fireShot(){
		if ((uses < 1)&&(GameControl.gameStart)) {
			if (GameControl.powerUpinUse == 0){
				uses ++;
				GameControl.powerUpinUse = 2;
				this.GetComponent<Image>().material = GameObject.Find ("BlackAndWhite").GetComponent<Image>().material;
				GameObject.Find(GameControl.play2_1).gameObject.layer = LayerMask.NameToLayer( "fireShot" );
				GameObject.Find(GameControl.play2_2).gameObject.layer = LayerMask.NameToLayer( "fireShot" );
				GameObject.Find(GameControl.play2_3).gameObject.layer = LayerMask.NameToLayer( "fireShot" );
				cDown ();
			}
		}
	}

	void cDown(){
		countDown--;
		if ((countDown <= 0)||(GameControl.powerUpinUse == 0)) {
			GameObject.Find(GameControl.play2_1).gameObject.layer = LayerMask.NameToLayer( "players" );
			GameObject.Find(GameControl.play2_2).gameObject.layer = LayerMask.NameToLayer( "players" );
			GameObject.Find(GameControl.play2_3).gameObject.layer = LayerMask.NameToLayer( "players" );
			GameObject.Find(GameControl.play1_1).gameObject.layer = LayerMask.NameToLayer( "players" );
			GameObject.Find(GameControl.play1_2).gameObject.layer = LayerMask.NameToLayer( "players" );
			GameObject.Find(GameControl.play1_3).gameObject.layer = LayerMask.NameToLayer( "players" );
			countDown = 6;
			GameControl.powerUpinUse = 0;
		} else {
			Invoke ("cDown", 1);
		}
	}
}
