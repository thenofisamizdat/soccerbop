using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// This class is for selecting game play mode, setting the cost of play in lives and coins, setting the availability of power ups and keepers,
// setting the time of the game, setting the reward for victory, adjusting the player stats before a match, 
// then saving updated stats using the SerializeGame class

public class SoccerBopGameSelect : MonoBehaviour {

	public static string SoccerBopMode = "Challenge2";
	public static int SoccerBopPrize = 0;
	public static bool powerUps = false;
	public static bool keeper = false;

	void Start () {
		this.transform.GetComponent<Button> ().onClick.AddListener (this.setGameMode);
	}

	void setGameMode(){
		if (this.name == "ArcadePlay") {
			// free play
			Countdown.timeLeft = 60;
			UserData.gameMode = "Regular";
			SoccerBopGameSelect.SoccerBopMode = "Arcade";
			SoccerBopGameSelect.powerUps = false;
			SoccerBopGameSelect.keeper = false;
			startSoccerBop();
		}
		else if (this.name == "2Player") {
			Countdown.timeLeft = 90;
			UserData.gameMode = "2player";
			SoccerBopGameSelect.SoccerBopMode = "2player";
			SoccerBopGameSelect.powerUps = false;
			SoccerBopGameSelect.keeper = false;
			startSoccerBop();
		}
		else if (this.name == "Challenge1") {
			// cost 1 life, 25 coins
			// win by 3 with power ups
			Countdown.timeLeft = 60;
			UserData.gameMode = "Regular";
			SoccerBopGameSelect.SoccerBopMode = "Challenge1";
			SoccerBopGameSelect.powerUps = true;
			SoccerBopGameSelect.keeper = false;
			SoccerBopGameSelect.SoccerBopPrize = 0;

			if ((PlayerObject.player[Login.fbuid].coins > 25) && (PlayerObject.player[Login.fbuid].lives > 0)){
				PlayerObject.player[Login.fbuid].coins -= 25;
				PlayerObject.player[Login.fbuid].lives -= 1;
				startSoccerBop();
			}
			else{
				// popup not enough lives / coins
				// show how to get some
			}
		}
		else if (this.name == "Challenge2") {
			// cost 1 life, 25 coins, win 50 coins 
			// win by 3, no power ups, vs keeper
			Countdown.timeLeft = 60;
			UserData.gameMode = "Regular";
			SoccerBopGameSelect.SoccerBopMode = "Challenge2";
			SoccerBopGameSelect.powerUps = false;
			SoccerBopGameSelect.keeper = true;
			SoccerBopGameSelect.SoccerBopPrize = 50;

			if ((PlayerObject.player[Login.fbuid].coins > 25) && (PlayerObject.player[Login.fbuid].lives > 0)){
				PlayerObject.player[Login.fbuid].coins -= 25;
				PlayerObject.player[Login.fbuid].lives -= 1;
				startSoccerBop();
			}
			else{
				// popup not enough lives / coins
				// show how to get some
			}
		}
		else if (this.name == "Challenge7") {
			// cost 1 life, 25 coins, win 50 coins 
			// Score with 6 players in under 60 seconds - Machine Gun style
			Countdown.timeLeft = 60;
			UserData.gameMode = "Regular";
			SoccerBopGameSelect.SoccerBopMode = "Challenge3";
			SoccerBopGameSelect.powerUps = false;
			SoccerBopGameSelect.keeper = true;
			SoccerBopGameSelect.SoccerBopPrize = 50;

			if ((PlayerObject.player[Login.fbuid].coins > 25) && (PlayerObject.player[Login.fbuid].lives > 0)){
				PlayerObject.player[Login.fbuid].coins -= 25;
				PlayerObject.player[Login.fbuid].lives -= 1;
				startSoccerBop();
			}
			else{
				// popup not enough lives / coins
				// show how to get some
			}
		}
		else if (this.name == "Challenge3") { 
			// cost 1 life, 100 coins, win 250 coins 
			//win by 5, with powerUps ups
			Countdown.timeLeft = 60;
			UserData.gameMode = "Regular";
			SoccerBopGameSelect.SoccerBopMode = "Challenge3";
			SoccerBopGameSelect.powerUps = true;
			SoccerBopGameSelect.keeper = false;
			SoccerBopGameSelect.SoccerBopPrize = 250;

			if ((PlayerObject.player[Login.fbuid].coins > 100) && (PlayerObject.player[Login.fbuid].lives > 0)){
				PlayerObject.player[Login.fbuid].coins -= 100;
				PlayerObject.player[Login.fbuid].lives -= 1;
				startSoccerBop();
			}
			else{
				// popup not enough lives / coins
				// show how to get some
			}
		}
		else if (this.name == "Challenge4") {
			// cost 1 life, 100 coins, win 750 coins 
			// win by 5, no power ups, keeper
			Countdown.timeLeft = 60;
			UserData.gameMode = "Regular";
			SoccerBopGameSelect.SoccerBopMode = "Challenge5";
			SoccerBopGameSelect.powerUps = false;
			SoccerBopGameSelect.keeper = true;
			SoccerBopGameSelect.SoccerBopPrize = 1000;

			if ((PlayerObject.player[Login.fbuid].coins > 100) && (PlayerObject.player[Login.fbuid].lives > 0)){
				PlayerObject.player[Login.fbuid].coins -= 100;
				PlayerObject.player[Login.fbuid].lives -= 1;
				startSoccerBop();
			}
			else{
				// popup not enough lives / coins
				// show how to get some
			}
		}
		else if (this.name == "Challenge7") {
			// cost 1 life, 100 coins, win 1000 coins 
			// score with 12 players in 60 seconds, free kick machine gun style
			Countdown.timeLeft = 60;
			UserData.gameMode = "Regular";
			SoccerBopGameSelect.SoccerBopMode = "Challenge6";
			SoccerBopGameSelect.powerUps = false;
			SoccerBopGameSelect.keeper = true;
			SoccerBopGameSelect.SoccerBopPrize = 1000;

			if ((PlayerObject.player[Login.fbuid].coins > 100) && (PlayerObject.player[Login.fbuid].lives > 0)){
				PlayerObject.player[Login.fbuid].coins -= 100;
				PlayerObject.player[Login.fbuid].lives -= 1;
				startSoccerBop();
			}
			else{
				// popup not enough lives / coins
				// show how to get some
			}
		}
	}

	void startSoccerBop(){
		SerializeGame.Save("pregame");
		Application.LoadLevel ("MainScene");
	}
	
}
