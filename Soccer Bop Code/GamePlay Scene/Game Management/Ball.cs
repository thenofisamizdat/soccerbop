using UnityEngine;

// Neil Byrne - 2015

// Ball class will kill ball movement when game play is stopped
// Also keeps track of each player object that touches the ball. This is used to track scorers etc.

public class Ball : MonoBehaviour {            
	
	void Update () {
		if (GameControl.stopper) {
			StopMovement();
		}
	}
	
	void StopMovement(){
		GetComponent<Rigidbody2D>().Sleep();
	}

	void OnCollisionEnter2D(Collision2D other){
		if ((other.collider.name == GameControl.play1_1) || (other.collider.name == GameControl.play1_2) || (other.collider.name == GameControl.play1_3)) {
			GameControl.lastTouch = other.collider.name;
		}
		else if ((other.collider.name == GameControl.play2_1) || (other.collider.name == GameControl.play2_2) || (other.collider.name == GameControl.play2_3)) {
			GameControl.lastTouch = other.collider.name;
		}
	}
}