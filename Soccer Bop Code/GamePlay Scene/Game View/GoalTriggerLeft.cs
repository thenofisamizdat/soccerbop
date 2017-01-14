using UnityEngine;

// Neil Byrne - 2015

// The Goal Triggers listen for objects to enter a trigger zone in the goal.
// On enterthey shake the screen, play a cheer audio, increase the speed of camera flashes,
// Add the name of the player to last touch the ball to the scorers record,
// increment the scores, reset the shotclock, and set the game state to be ready to resume play from tip-off.

public class GoalTriggerLeft : MonoBehaviour {

	public GameObject showScore;
	GameObject goal;
	GameObject ball;

	public AudioClip cheer;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find("Ball");
		goal = GameObject.Find("GoalLeft");
	}
	
	void clearScreen(){
		//showScore.transform.position = new Vector3 (0f, 8f, 0f);
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag (ball.tag)) {
			GameControl.cameraFlashSpeed = 5;
			PerlinShake.test = true;
			//AudioSource.PlayClipAtPoint(cheer, transform.position ); 
//			showScore.transform.position = new Vector3 (0f, 0.0f, 0f);
			Invoke ("clearScreen", 2.5f);
			// add scorer to list
			GameControl.team2Scorers.Add(GameControl.lastTouch);
			
				GameControl.score2++;
				GameControl.turn = 1;
				Countdown.shotClock = 5;
				GameControl.starter = true;
				GameControl.stopper = true;
				AI.canShoot = false;
				GameControl.changeShot = true;
				
			Countdown.startTime = false;
			GameObject.Find ("Ball").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

	}
}
