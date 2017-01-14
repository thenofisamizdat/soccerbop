using UnityEngine;
using System.Collections.Generic;

// Neil Byrne - 2015

// GameControl is a StateMachine that keeps track of all game states throughout the game.

public class GameControl : MonoBehaviour {
	
	public static bool gameStart = false;

	public static int turn = 1;
	public static bool stopper = false;
	public static bool starter = false;

	public static string lastTouch = "";

	public static int teamSelectScreen = 1;

	public static List<string> team1Scorers = new List<string>();
	public static List<string> team2Scorers = new List<string>();

	public static int touches = 0;
	
	public static bool changeShot = true;
	
	public static int score1 = 0;
	public static int score2 = 0;

	public static int cameraFlashSpeed = 30;

	public static string team1 = "aBilbao";
	public static string team2 = "madridCity";

	public static bool star1InUse = false;
	public static bool star2InUse = false;
	public static bool star3InUse = false;

	public static bool PU1InUse = false;
	public static bool PU2InUse = false;
	public static bool PU3InUse = false;

	public static string[] teamLineup = new string[10];
	public static string[] compTeamLineup = new string[10];
	public static int team1Length = 0;
	public static int team2Length = 0;

	public static string team1Jersey = "home";
	public static string team2Jersey = "away";
	
	public static int powerUpinUse = 0;

	public static string play1_1 = "";
	public static string play1_2 = "";
	public static string play1_3 = "";
	
	public static string play2_1 = "";
	public static string play2_2 = "";
	public static string play2_3 = "__";

	public static int play1_1_BLOCK = 0;
	public static int play1_2_BLOCK = 0;
	public static int play1_3_BLOCK = 0;
	public static int play2_1_BLOCK = 0;
	public static int play2_2_BLOCK = 0;
	public static int play2_3_BLOCK = 0;

	public static int ball_BLOCK = 0;

	public static string Username = "Guest";
	public static string Password = "";

	public static string fbHash = "";

	public static List<object>                 friends         = null;
	public static Dictionary<string, string>   profile         = null;
	public static List<object>                 scores          = null;
	public static Dictionary<string, Texture>  friendImages    = new Dictionary<string, Texture>();

	
	public static Texture UserTexture;
	public static Texture FriendTexture = null;
	
	GameObject p1;
	GameObject p2;
	GameObject p3;
	GameObject p4;
	GameObject p5;
	GameObject p6;
	public GameObject ball;
	
	Vector2 p1pos;
	Vector2 p2pos;
	Vector2 p3pos;
	Vector2 p4pos;
	Vector2 p5pos;
	Vector2 p6pos;
	Vector2 ballpos;
	
	// Use this for initialization
	void Start () {
			ballpos = ball.transform.position;
	}

	
	// Update is called once per frame
	void Update () {
	
		if (GameControl.gameStart) {
			if ((p1 == null) &&(GameControl.play2_3!="__")){
				p1 = GameObject.Find (GameControl.play1_1);
				p2 = GameObject.Find (GameControl.play1_2);
				p3 = GameObject.Find (GameControl.play1_3);
				p4 = GameObject.Find (GameControl.play2_1);
				p5 = GameObject.Find (GameControl.play2_2);
				p6 = GameObject.Find (GameControl.play2_3);
			
				p1pos = p1.transform.position;
				p2pos = p2.transform.position;
				p3pos = p3.transform.position;
				p4pos = p4.transform.position;
				p5pos = p5.transform.position;
				p6pos = p6.transform.position;

				p1.SetActive(true);
				p2.SetActive(true);
				p3.SetActive(true);
				p4.SetActive(true);
				p5.SetActive(true);
				p6.SetActive(true);
			}
			if (GameControl.changeShot) {
				if (GameControl.turn == 1) {

					p1.GetComponent<Renderer>().material.color = new Color (1f, 1f, 1f, 1f);
					p2.GetComponent<Renderer>().material.color = new Color (1f, 1f, 1f, 1f);
					p3.GetComponent<Renderer>().material.color = new Color (1f, 1f, 1f, 1f);
					p4.GetComponent<Renderer>().material.color = new Color (1f, 1f, 1f, .5f);
					p5.GetComponent<Renderer>().material.color = new Color (1f, 1f, 1f, .5f);
					p6.GetComponent<Renderer>().material.color = new Color (1f, 1f, 1f, .5f);

				} else {

					p1.GetComponent<Renderer>().material.color = new Color (1f, 1f, 1f, .5f);
					p2.GetComponent<Renderer>().material.color = new Color (1f, 1f, 1f, .5f);
					p3.GetComponent<Renderer>().material.color = new Color (1f, 1f, 1f, .5f);
					p4.GetComponent<Renderer>().material.color = new Color (1f, 1f, 1f, 1f);
					p5.GetComponent<Renderer>().material.color = new Color (1f, 1f, 1f, 1f);
					p6.GetComponent<Renderer>().material.color = new Color (1f, 1f, 1f, 1f);

				}
				GameControl.changeShot = false;
			}
			
			if (GameControl.starter) {
				
				GameControl.starter = false;
				Invoke ("resetPosition", 2);
			}
		}
	}
	
	void resetPosition(){
		GameControl.cameraFlashSpeed = 30;
		GameControl.starter = false;
		GameControl.stopper = false;
		p1.transform.position = Vector2.Lerp(p1.transform.position, p1pos, 100);
		p2.transform.position = Vector2.Lerp(p2.transform.position, p2pos, 100);
		p3.transform.position = Vector2.Lerp(p3.transform.position, p3pos, 100);
		p4.transform.position = Vector2.Lerp(p4.transform.position, p4pos, 100);
		p5.transform.position = Vector2.Lerp(p5.transform.position, p5pos, 100);
		p6.transform.position = Vector2.Lerp(p6.transform.position, p6pos, 100);
		ball.transform.position = Vector2.Lerp(ball.transform.position, ballpos, 100);
		
		AI.canShoot = true;
	}
}