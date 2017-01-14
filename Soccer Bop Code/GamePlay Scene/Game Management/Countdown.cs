using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// Countdown monitors time in game play. It changes turns when a player's shot clock runs out, then resets the shot clock.
// It checks for the end of game and invokes the end of game checks to see if a player was victorious
// It then updates stats and Saves data to the device

public class Countdown : MonoBehaviour
{
	
	public static float timeLeft = 60.0f;

	public static float shotClock = 5;

	bool goOnce = true;
	public AudioClip tick;
	public AudioClip tick2;
	public AudioClip whistle;

	public static bool startTime = false;

	void Shotclock(){
		
		if (GameControl.turn < 3) {
						if (Countdown.shotClock <= 0) {
								
								if (GameControl.turn == 2) {
										GameControl.turn = 1;
										Countdown.shotClock = 5;										
										AI.canShoot = false;
										GameControl.changeShot = true;
										
								} else {
										GameControl.turn = 2;
										Countdown.shotClock = 5;										
										AI.canShoot = true;
										GameControl.changeShot = true;										
								}								
						} 
			if (Countdown.startTime){
				Invoke ("Shotclock", 1);
			}
			else{
				goOnce = true;
			}
						
		}
	}

	public GameObject endScreen;
	public GameObject endMessage;

	void gameOver(){
		endScreen.SetActive (true);
		endMessage.SetActive (true);
		if (SoccerBopGameSelect.SoccerBopMode == "Arcade") {
			
		}
		else if (SoccerBopGameSelect.SoccerBopMode == "2player") {
			
		}
		else if (SoccerBopGameSelect.SoccerBopMode == "Challenge1") {
			if (GameControl.score1 - GameControl.score2 >= 3){
				// win star 1
				endMessage.GetComponent<Text>().text = "Congratulations!\n You have completed Challenge 1\n You win this star player";
				string star = "alt_" + StickerPlace.teamLineUps[GameControl.team1].teamPlayers[0].Substring(5); // unlocks away player 3
				if (PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.ContainsKey (star)){
					PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars[star] += 1;
					PlayerObject.player[Login.fbuid].fans += 1000;
				}
				else {
					PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.Add (star, 1);
					PlayerObject.player[Login.fbuid].fans += 1000;
					PlayerObject.player[Login.fbuid].playersAmount ++;
				}
			}
			else {
				endMessage.GetComponent<Text>().text = "Hard Luck!";
			}
		}
		else if (SoccerBopGameSelect.SoccerBopMode == "Challenge2") {
			if (GameControl.score1 - GameControl.score2 >= 1){
				// win star 1
				endMessage.GetComponent<Text>().text = "Congratulations!\n You have won the match! 2\n You win this star player and 25 coins";
				string star = StickerPlace.teamLineUps[GameControl.team1].teamPlayers[2];
				if (PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.ContainsKey (star)){
					PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars[star] += 1;
					PlayerObject.player[Login.fbuid].fans += 1000;
					PlayerObject.player[Login.fbuid].coins += 25;
				}
				else {
					PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.Add (star, 1);
					PlayerObject.player[Login.fbuid].fans += 1000;
					PlayerObject.player[Login.fbuid].playersAmount ++;
					PlayerObject.player[Login.fbuid].coins += 25;
				}
			}
			else {
				endMessage.GetComponent<Text>().text = "Hard Luck!";
			}
		}
		else if (SoccerBopGameSelect.SoccerBopMode == "Challenge3") {
			if (GameControl.score1 == 6){
				// win star 1
				endMessage.GetComponent<Text>().text = "Congratulations!\n You have completed Challenge 3\n You win this star player and 50 coins";
				string star = StickerPlace.teamLineUps[GameControl.team1].teamPlayers[3];
				if (PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.ContainsKey (star)){
					PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars[star] += 1;
					PlayerObject.player[Login.fbuid].fans += 3000;
					PlayerObject.player[Login.fbuid].coins += 50;
				}
				else {
					PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.Add (star, 1);
					PlayerObject.player[Login.fbuid].fans += 3000;
					PlayerObject.player[Login.fbuid].playersAmount ++;
					PlayerObject.player[Login.fbuid].coins += 50;
				}
			}
			else {
				endMessage.GetComponent<Text>().text = "Hard Luck!";
			}
		}
		else if (SoccerBopGameSelect.SoccerBopMode == "Challenge4") {
			if (GameControl.score1 - GameControl.score2 >= 5){
				// win star 1
				endMessage.GetComponent<Text>().text = "Congratulations!\n You have completed Challenge 1\n You win this star player and 250 coins";
				string star = StickerPlace.teamLineUps[GameControl.team1].teamPlayers[4];
				if (PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.ContainsKey (star)){
					PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars[star] += 1;
					PlayerObject.player[Login.fbuid].fans += 8000;
					PlayerObject.player[Login.fbuid].coins += 250;
				}
				else {
					PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.Add (star, 1);
					PlayerObject.player[Login.fbuid].fans += 8000;
					PlayerObject.player[Login.fbuid].playersAmount ++;
					PlayerObject.player[Login.fbuid].coins += 250;
				}
			}
			else {
				endMessage.GetComponent<Text>().text = "Hard Luck!";
			}
		}
		else if (SoccerBopGameSelect.SoccerBopMode == "Challenge5") {
			if (GameControl.score1 - GameControl.score2 >= 5){
				// win star 1
				endMessage.GetComponent<Text>().text = "Congratulations!\n You have completed Challenge 1\n You win this star player and 750 coins";
				string star = StickerPlace.teamLineUps[GameControl.team1].teamPlayers[4];
				if (PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.ContainsKey (star)){
					PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars[star] += 1;
					PlayerObject.player[Login.fbuid].fans += 8000;
					PlayerObject.player[Login.fbuid].coins += 750;
				}
				else {
					PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.Add (star, 1);
					PlayerObject.player[Login.fbuid].fans += 8000;
					PlayerObject.player[Login.fbuid].playersAmount ++;
					PlayerObject.player[Login.fbuid].coins += 750;
				}
			}
			else {
				endMessage.GetComponent<Text>().text = "Hard Luck!";
			}
		}
		else if (SoccerBopGameSelect.SoccerBopMode == "Challenge6") {
			if (GameControl.score1 == 12){
				// win star 1
				endMessage.GetComponent<Text>().text = "Congratulations!\n You have completed Challenge 6\n You win this star player and 1000 coins";
				string star = StickerPlace.teamLineUps[GameControl.team1].teamPlayers[5];
				if (PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.ContainsKey (star)){
					PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars[star] += 1;
					PlayerObject.player[Login.fbuid].fans += 20000;
					PlayerObject.player[Login.fbuid].coins += 1000;
				}
				else {
					PlayerObject.player[Login.fbuid].teams[GameControl.team1].stars.Add (star, 1);
					PlayerObject.player[Login.fbuid].fans += 20000;
					PlayerObject.player[Login.fbuid].coins += 1000;
					PlayerObject.player[Login.fbuid].playersAmount ++;
				}
			}
			else {
				endMessage.GetComponent<Text>().text = "Hard Luck!";
			}

		}
		SerializeGame.Save("postgame");
		Invoke ("levelChange", 3);
	}
	void levelChange(){
			Application.LoadLevel ("StickerBook");
	}
	
	public void Update()	
	{
		if ((GameControl.gameStart)&&(Countdown.startTime)) {
			if (goOnce){
				goOnce = false;
				Invoke ("Shotclock", 1);
			}
			Countdown.timeLeft -= Time.deltaTime;
			Countdown.shotClock -= Time.deltaTime;

			if (Countdown.timeLeft <= 0.0f) {	
				//game over
				Countdown.timeLeft = 0;

				if (GameControl.turn < 3) {	
					// empty power ups
					powerUpHolder.place1 = 0;
					powerUpHolder.place2 = 0;
					powerUpHolder.place3 = 0;
					PowerUpTokens.slot1 = 0;
					PowerUpTokens.slot2 = 0;
					PowerUpTokens.slot3 = 0;
					GameControl.turn = 3;
					AI.canShoot = false;
					GameControl.stopper = true;
					GameControl.gameStart = false;
					gameOver ();
				}
			} 
		}
	}
}