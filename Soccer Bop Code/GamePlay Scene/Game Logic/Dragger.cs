using UnityEngine;

// Neil Byrne - 2015

// Dragger is the most important game logic file. It measures where each player is within the grid, which informs the AI.
// It also handles the physics and logic behind user swipe. There are a few things to consider here: 
// A user player can become active on touch or on touch enter, but only one player at a time can be active.
// This requires a number of checks and sets with the game state machine. 
// Also the application of velocity is handled here, based on user swipe. 
// The logic for activated power ups is also all handled here.


public class Dragger : MonoBehaviour {
	float x;
	float y;
	public float travelSpeed = 3000;
	bool clicked = false;	


	// section manager 
	GameObject ball;
	
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

	public GameObject sfx;

	void Start(){
		ball = this.gameObject;
		xDivider1 = Screen.width / 4;
		xDivider2 = (Screen.width / 4) * 2;
		xDivider3 = (Screen.width / 4) * 3;
		
		yDivider1 = Screen.height / 4;
		yDivider2 = (Screen.height / 4) * 2;
		yDivider3 = (Screen.height / 4) * 3;
	}
    
	// Update is called once per frame
	void Update(){
		if ((!mouseManage.mouseClick)&&(GameControl.gameStart)) {
			if (clicked) {
				if (!Countdown.startTime){
					Countdown.startTime = true;
				}
				GameObject.Find ("swipedPlayer").transform.position = GameObject.Find("swipedOffscreenPosition").transform.position;
				GameObject.Find ("swipedPlayer2").transform.position = GameObject.Find("swipedOffscreenPosition").transform.position;
				
				Vector2 direction =  (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
				GetComponent<Rigidbody2D>().AddForce (direction*travelSpeed );
				
				if (GameControl.powerUpinUse == 3) {
					if (GameControl.touches == 1){
						
					}
					else{
						Countdown.shotClock = 5;
						if (UserData.gameMode != "2player"){
							AI.canShoot = true;
						}
						if (GameControl.turn == 1){
							GameControl.turn = 2;
						}
						else if (GameControl.turn == 2){
							GameControl.turn = 1;
						}
						GameControl.changeShot = true;

					}
				}
				else{
					Countdown.shotClock = 5;
					if (UserData.gameMode != "2player"){
						AI.canShoot = true;
					}
					if (GameControl.turn == 1){
						GameControl.turn = 2;
					}
					else if (GameControl.turn == 2){
						GameControl.turn = 1;
					}
					GameControl.changeShot = true;

				}
				clicked = false;
			}	
		}



		if (GameControl.stopper) {
			StopMovement();
		}

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

		if (ball.gameObject.name == GameControl.play1_1) {
			GameControl.play1_1_BLOCK = block;
		}
		else if (ball.gameObject.name == GameControl.play1_2) {
			GameControl.play1_2_BLOCK = block;
		}
		else if (ball.gameObject.name == GameControl.play1_3) {
			GameControl.play1_3_BLOCK = block;
		}
		else if (ball.gameObject.name == GameControl.play2_1) {
			GameControl.play2_1_BLOCK = block;
		}
		else if (ball.gameObject.name == GameControl.play2_2) {
			GameControl.play2_2_BLOCK = block;
		}
		else if (ball.gameObject.name == GameControl.play2_3) {
			GameControl.play2_3_BLOCK = block;
		}
	

	}

	void OnMouseEnter(){
		if (Input.touchCount < 2){
		if ((mouseManage.mouseClick)&&(GameControl.gameStart)) {
			if (GameControl.turn == 1){
				if ((ball.gameObject.name == GameControl.play1_1) || (ball.gameObject.name == GameControl.play1_2) || (ball.gameObject.name == GameControl.play1_3)){
						GameObject.Find ("swipedPlayer").transform.position = this.transform.position;
				if (GameControl.powerUpinUse == 3) {
					if (GameControl.touches == 1) {
						
						if (GameControl.turn == 1) {							
							clicked = true;					
							GameControl.touches = 0;
						}
					} else {
						if (GameControl.turn == 1) {
							clicked = true;
							GameControl.touches++;
						}
					}
				} else {
					if (GameControl.turn == 1) {						
						clicked = true;						
						GameControl.touches = 0;
					}
				}
				}
			}
			else if (GameControl.turn == 2){ // if 2 player mode check for player 2
				if (UserData.gameMode == "2player"){
				if ((ball.gameObject.name == GameControl.play2_1) || (ball.gameObject.name == GameControl.play2_2) || (ball.gameObject.name == GameControl.play2_3)){
							GameObject.Find ("swipedPlayer2").transform.position = this.transform.position;
					if (GameControl.powerUpinUse == 3) {
						if (GameControl.touches == 1) {
							
							if (GameControl.turn == 2) {								
								clicked = true;								
								GameControl.touches = 0;
							}
						} else {
							if (GameControl.turn == 2) {
								clicked = true;
								GameControl.touches++;
							}
						}
					} else {
						if (GameControl.turn == 2) {							
							clicked = true;
							GameControl.touches = 0;
						}
					}
				}
			}
			}
		}
	}

	}
    
	void OnMouseDown(){
		Debug.Log (this.name);
		if (Input.touchCount < 2){
		if (GameControl.gameStart) {
			if (GameControl.turn == 1){
			if ((ball.gameObject.name == GameControl.play1_1) || (ball.gameObject.name == GameControl.play1_2) || (ball.gameObject.name == GameControl.play1_3)){
						GameObject.Find ("swipedPlayer").transform.position = this.transform.position;
				if (GameControl.powerUpinUse == 3) {
					if (GameControl.touches == 1) {						
						if (GameControl.turn == 1) {							
						    mouseManage.mouseClick = true;
							clicked = true;						
							GameControl.touches = 0;
						}
					} else {
						if (GameControl.turn == 1) {
						    mouseManage.mouseClick = true;
							clicked = true;
							GameControl.touches++;
						}
					}
				} else {
					if (GameControl.turn == 1) {						
						mouseManage.mouseClick = true;
						clicked = true;					
						GameControl.touches = 0;
					}
				}
			}
			}
			else if (GameControl.turn == 2){
				if (UserData.gameMode == "2player"){
				if ((ball.gameObject.name == GameControl.play2_1) || (ball.gameObject.name == GameControl.play2_2) || (ball.gameObject.name == GameControl.play2_3)){
							GameObject.Find ("swipedPlayer2").transform.position = this.transform.position;
					if (GameControl.powerUpinUse == 3) {
						if (GameControl.touches == 1) {
							
							if (GameControl.turn == 2) {								
								mouseManage.mouseClick = true;
								clicked = true;								
								GameControl.touches = 0;
							}
						} else {
							if (GameControl.turn == 2) {
								mouseManage.mouseClick = true;
								clicked = true;
								GameControl.touches++;
							}
						}
					} else {
						if (GameControl.turn == 2) {							
							mouseManage.mouseClick = true;
							clicked = true;							
							GameControl.touches = 0;
						}
					}
				}
			}
			}
		}
		}
	}

	void StopMovement(){		
		GetComponent<Rigidbody2D>().Sleep();
		}


}