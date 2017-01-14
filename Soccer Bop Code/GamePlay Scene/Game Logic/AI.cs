using UnityEngine;
using System.Collections.Generic;

// Neil Byrne - 2015

// AI is invoked when it it the computer's turn to shoot. 
// Based on the grid position of the ball, the computer works through a list of best grid positions to shoot from
// until it finds a player occupying that position. It shoots in the direction of the ball with a very slight margin of error for a more natural feel

public class AI : MonoBehaviour {
	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject ball;

	public float travelSpeed = 100;

	public GameObject shotClock;
	public static bool canShoot = true;

	Dictionary<int, int[]> gridPositions = new Dictionary<int, int[]>();
	int[] grid1 = new int[16]{1,5,6,9,10,2,7,11,13,3,4,8,14,12,15,16};
	int[] grid2 = new int[16]{2,5,1,6,9,10,13,14,15,11,7,16,12,8,3,4};
	int[] grid3 = new int[16]{3,4,8,12,7,11,15,16,14,10,13,9,6,2,5,1};
	int[] grid4 = new int[16]{4,8,12,16,15,11,7,3,14,10,13,9,6,2,5,1};
	int[] grid5 = new int[16]{5,2,6,10,14,9,1,13,3,7,4,8,11,12,15,16};
	int[] grid6 = new int[16]{6,7,2,11,4,8,15,10,14,2,12,1,5,9,13,16};
	int[] grid7 = new int[16]{7,2,11,4,8,12,15,16,2,6,10,14,14,1,9,13};
	int[] grid8 = new int[16]{8,4,12,16,3,7,11,2,6,10,15,1,5,9,13,14};
	int[] grid9 = new int[16]{9,10,13,14,5,6,11,15,7,6,2,16,8,3,4,1};
	int[] grid10 = new int[16]{10,11,14,15,16,12,7,6,8,4,3,2,1,5,9,13};
	int[] grid11 = new int[16]{11,12,15,16,8,7,4,3,14,10,6,2,1,3,5,9};
	int[] grid12 = new int[16]{12,16,8,11,15,7,4,3,13,14,10,9,6,5,2,1};
	int[] grid13 = new int[16]{13,10,9,14,11,15,6,5,7,2,3,16,4,8,12,1};
	int[] grid14 = new int[16]{14,15,11,10,7,12,16,6,8,4,2,1,3,5,9,1};
	int[] grid15 = new int[16]{15,16,12,11,8,4,7,3,2,6,10,15,9,13,14,1};
	int[] grid16 = new int[16]{16,12,8,11,15,7,4,3,10,6,2,5,1,9,13,14};

	float distance1;
	float distance2;
	float distance3;

	public GameObject sfx;

	void Start () {
        
		p1 = GameObject.Find (GameControl.play2_1);
		p2 = GameObject.Find (GameControl.play2_2);
		p3 = GameObject.Find (GameControl.play2_3);

		gridPositions [1] = grid1;
		gridPositions [2] = grid2;
		gridPositions [3] = grid3;
		gridPositions [4] = grid4;
		gridPositions [5] = grid5;
		gridPositions [6] = grid6;
		gridPositions [7] = grid7;
		gridPositions [8] = grid8;
		gridPositions [9] = grid9;
		gridPositions [10] = grid10;
		gridPositions [11] = grid11;
		gridPositions [12] = grid12;
		gridPositions [13] = grid13;
		gridPositions [14] = grid14;
		gridPositions [15] = grid15;
		gridPositions [16] = grid16;

	}
	
	// Update is called once per frame
	void Update () {
		if (UserData.gameMode != "2player"){
			if (GameControl.gameStart) {
				if ((GameControl.turn == 2) && (AI.canShoot))  {
					AI.canShoot = false;
					
					if (GameControl.powerUpinUse == 2){
						Invoke ("shoot", 2);
					}
					else{
						shoot ();
					}
									
				}
			}
		}
	}

	void shoot(){
		Invoke  ("takeShot", Random.Range(1.5f, 3.0f));
	}

	void takeShot(){

		if (GameControl.powerUpinUse == 2) {
			GameControl.powerUpinUse = 0;
			GameObject.Find(GameControl.play2_1).gameObject.layer = LayerMask.NameToLayer( "players" );
			GameObject.Find(GameControl.play2_2).gameObject.layer = LayerMask.NameToLayer( "players" );
			GameObject.Find(GameControl.play2_3).gameObject.layer = LayerMask.NameToLayer( "players" );
			GameObject.Find(GameControl.play1_1).gameObject.layer = LayerMask.NameToLayer( "players" );
			GameObject.Find(GameControl.play1_2).gameObject.layer = LayerMask.NameToLayer( "players" );
			GameObject.Find(GameControl.play1_3).gameObject.layer = LayerMask.NameToLayer( "players" );
		}

		for (int i = 0; i< 15; i++) {
			if (ball.transform.position == GameObject.Find ("centreSpot").transform.position){
				int r = Random.Range (1,4);
				Debug.Log (r);
				if (r == 1){
					p1 = GameObject.Find (GameControl.play2_1);
				}
				else if (r == 2){
					p1 = GameObject.Find (GameControl.play2_2);
				}
				else if (r == 3){
					p1 = GameObject.Find (GameControl.play2_3);
				}
			}
			else{
				if (GameControl.play2_1_BLOCK == gridPositions[GameControl.ball_BLOCK][i]){
					p1 = GameObject.Find (GameControl.play2_1);
					break;
				}
				else if (GameControl.play2_2_BLOCK == gridPositions[GameControl.ball_BLOCK][i]){
					p1 = GameObject.Find (GameControl.play2_2);
					break;
				}
				else if (GameControl.play2_3_BLOCK == gridPositions[GameControl.ball_BLOCK][i]){
					p1 = GameObject.Find (GameControl.play2_3);
					break;
				}
			}
		}

		if ((!GameControl.stopper)&&(GameControl.turn == 2)) {
			Vector2 direction = (ball.transform.position - p1.transform.position).normalized;
			float rx = Random.Range (0.0f, 0.1f);
			float ry = Random.Range (0.04f, 0.2f);
			float rf = Random.Range (.85f, 1.2f);
			direction += new Vector2 (rx, ry);
			p1.GetComponent<Rigidbody2D>().AddForce (direction * travelSpeed * rf);

			GameControl.turn = 1;
			Countdown.shotClock = 5;
			GameControl.changeShot = true;
			AI.canShoot = true;
		}
	}
}
