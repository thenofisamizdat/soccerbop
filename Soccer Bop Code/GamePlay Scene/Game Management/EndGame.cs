using UnityEngine;

// Neil Byrne - 2015

// Endgame resets the game's StateMachine and preps the game to be playable again

public class EndGame : MonoBehaviour {

	public static void endGame(){
		preGameSceneButtons.scenery = 1;
		GameControl.gameStart = false;
		Countdown.startTime = false;
		GameControl.turn = 1;
		GameControl.stopper = false;
		GameControl.starter = false;
		
		GameControl.changeShot = true;
		
		GameControl.score1 = 0;
		GameControl.score2 = 0;

		GameControl.team1Scorers.Clear ();
		GameControl.team2Scorers.Clear ();

		AI.canShoot = true;
	}
}
