using UnityEngine;

// Neil Byrne - 2015

// The SectionManager class is a very important element in the AI process
// It divides the playing pitch into 16 grid squares and monitors which grid section the ball is in at all times.
// Based on this grid position, the AI class will be able to determine the best action.

public class SectionManager : MonoBehaviour {

	public GameObject ball;

	int ballSectorx = 0;
	int ballSectory = 0;

	int block = 0;

	int xDivider1;
	int xDivider2;
	int xDivider3;

	int yDivider1;
	int yDivider2;
	int yDivider3;

	float xPos = 1;
	float yPos = 1;

	// Use this for initialization
	void Start () {

		xDivider1 = Screen.width / 4;
		xDivider2 = (Screen.width / 4)*2;
		xDivider3 = (Screen.width / 4)*3;

		yDivider1 = Screen.height / 4;
		yDivider2 = (Screen.height / 4)*2;
		yDivider3 = (Screen.height / 4)*3;

		Debug.Log ("script attached to " + ball.gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		xPos = Camera.main.WorldToScreenPoint (ball.gameObject.transform.position).x;
		yPos = Camera.main.WorldToScreenPoint (ball.gameObject.transform.position).y;
		//XSECTOR
		if (xPos < xDivider1) {
			ballSectorx = 1;
				}
		else if (xPos < xDivider2) {
			ballSectorx = 2;
		}
		else if (xPos < xDivider3) {
			ballSectorx = 3;
		}
		else{
			ballSectorx = 4;
		}
		// YSECTOR
		if (yPos < yDivider1) {
			ballSectory = 1;
		}
		else if (yPos < yDivider2) {
			ballSectory = 2;
		}
		else if (yPos < yDivider3) {
			ballSectory = 3;
		}
		else{
			ballSectory = 4;
		}
		// NOW GET BLOCK BASED ON X, Y

		if ((ballSectorx == 1) && (ballSectory == 4)) {
						block = 1;
				}
		else if ((ballSectorx == 1) && (ballSectory == 3)) {
			block = 2;
		}
		else if ((ballSectorx == 1) && (ballSectory == 2)) {
			block = 3;
		}
		else if ((ballSectorx == 1) && (ballSectory == 1)) {
			block = 4;
		}
		else if ((ballSectorx == 2) && (ballSectory == 4)) {
			block = 5;
		}
		else if ((ballSectorx == 2) && (ballSectory == 3)) {
			block = 6;
		}
		else if ((ballSectorx == 2) && (ballSectory == 2)) {
			block = 7;
		}
		else if ((ballSectorx == 2) && (ballSectory == 1)) {
			block = 8;
		}
		else if ((ballSectorx == 3) && (ballSectory == 4)) {
			block = 9;
		}
		else if ((ballSectorx == 3) && (ballSectory == 3)) {
			block = 10;
		}
		else if ((ballSectorx == 3) && (ballSectory == 2)) {
			block = 11;
		}
		else if ((ballSectorx == 3) && (ballSectory == 1)) {
			block = 12;
		}
		else if ((ballSectorx == 4) && (ballSectory == 4)) {
			block = 13;
		}
		else if ((ballSectorx == 4) && (ballSectory == 3)) {
			block = 14;
		}
		else if ((ballSectorx == 4) && (ballSectory == 2)) {
			block = 15;
		}
		else if ((ballSectorx == 4) && (ballSectory == 1)) {
			block = 16;
		}

		GameControl.ball_BLOCK = block;
	}
}
