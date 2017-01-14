using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// Neil Byrne - 2015

// UserData keeps record of all user specific information as a user connects to and plays the game

public class UserData : MonoBehaviour {

	public static string menuScreen = "home";

	public static string groupDisplay = "groupA";

	public static string gameMode = "1player"; // Live or Regular or Practice

	public static IDictionary<string,object> userInfo = new Dictionary<string, object>();
	static IDictionary<string,object> userData = new Dictionary<string, object>();

	static IDictionary<string,object> messenger = new Dictionary<string, object>();

	public static IDictionary<string,object> achievementHold = new Dictionary<string, object>();
	public static IDictionary<string,object> starPlayerHold = new Dictionary<string, object>();
	public static IDictionary<string,object> statsHold = new Dictionary<string, object>();

	public static ArrayList achievementNameIndex = new ArrayList();
	public static ArrayList starPlayerNameIndex = new ArrayList();
	public static ArrayList statsNameIndex = new ArrayList();

	public static ArrayList achievementAmountIndex = new ArrayList();
	public static ArrayList starPlayerAmountIndex = new ArrayList();
	public static ArrayList statsAmountIndex = new ArrayList();

	public static JSONObject achievements = new JSONObject ();

	public static string displayName = "";

	public static bool lifeTimerRunning = false;

	public static int lifeTimerSeconds = 600;

	public static void fillHolders(){
		//stats
		UserData.statsHold [UserData.statsWinsName] = UserData.statsWinsName;
		UserData.statsHold [UserData.statsWinsAmount] = UserData.statsWinsAmount;
		statsNameIndex.Add (UserData.statsWinsName);
		statsAmountIndex.Add (UserData.statsWinsAmount);

		UserData.statsHold [UserData.statsLossesName] = UserData.statsLossesName;
		UserData.statsHold [UserData.statsLossesAmount] = UserData.statsLossesAmount;
		statsNameIndex.Add (UserData.statsLossesName);
		statsAmountIndex.Add (UserData.statsLossesAmount);

		UserData.statsHold [UserData.statsDrawsName] = UserData.statsDrawsName;
		UserData.statsHold [UserData.statsDrawsAmount] = UserData.statsDrawsAmount;
		statsNameIndex.Add (UserData.statsDrawsName);
		statsAmountIndex.Add (UserData.statsDrawsAmount);

		UserData.statsHold [UserData.statsGoalsName] = UserData.statsGoalsName;
		UserData.statsHold [UserData.statsGoalsAmount] = UserData.statsGoalsAmount;
		statsNameIndex.Add (UserData.statsGoalsName);
		statsAmountIndex.Add (UserData.statsGoalsAmount);

		UserData.statsHold [UserData.statsConcededName] = UserData.statsConcededName;
		UserData.statsHold [UserData.statsConcededAmount] = UserData.statsConcededAmount;
		statsNameIndex.Add (UserData.statsConcededName);
		statsAmountIndex.Add (UserData.statsConcededAmount);

		UserData.statsHold [UserData.statsFansName] = UserData.statsFansName;
		UserData.statsHold [UserData.statsFansAmount] = UserData.statsFansAmount;
		statsNameIndex.Add (UserData.statsFansName);
		statsAmountIndex.Add (UserData.statsFansAmount);

		UserData.statsHold [UserData.statsWinstreakName] = UserData.statsWinstreakName;
		UserData.statsHold [UserData.statsWinstreakAmount] = UserData.statsWinstreakAmount;
		statsNameIndex.Add (UserData.statsWinstreakName);
		statsAmountIndex.Add (UserData.statsWinstreakAmount);

		UserData.statsHold [UserData.statsLivesName] = UserData.statsLivesName;
		UserData.statsHold [UserData.statsLivesAmount] = UserData.statsLivesAmount;
		statsNameIndex.Add (UserData.statsLivesName);
		statsAmountIndex.Add (UserData.statsLivesAmount);

		UserData.statsHold [UserData.statsLoginName] = UserData.statsLoginName;
		UserData.statsHold [UserData.statsLoginAmount] = UserData.statsLoginAmount;
		statsNameIndex.Add (UserData.statsLoginName);
		statsAmountIndex.Add (UserData.statsLoginAmount);

		UserData.statsHold [UserData.statsTeamName] = UserData.statsTeamName;
		UserData.statsHold [UserData.statsWinstreakAmount] = UserData.statsWinstreakAmount;
		statsNameIndex.Add (UserData.statsTeamName);
		statsAmountIndex.Add (UserData.statsWinstreakAmount);

		UserData.isLoaded = true;

		Application.LoadLevel ("02_A_TeamSelect");
	}
	public static bool isLoaded = false;

	//ACHIEVEMENTS
	//achievement1
	public static string achievement1Name = "Hat Trick";
	public static string achievement1Amount = "0";

	//achievement2
	public static string achievement2Name = "Wins x10";
	public static string achievement2Amount = "0";

	//achievement3
	public static string achievement3Name = "Wins x50";
	public static string achievement3Amount = "0";

	//achievement4
	public static string achievement4Name = "Wins x100";
	public static string achievement4Amount = "0";

	//achievement5
	public static string achievement5Name = "Wins x1000";
	public static string achievement5Amount = "0";


	//STATS
	//WINS
	public static string statsWinsName = "Wins";
	public static string statsWinsAmount = "0";
	
	//losses
	public static string statsLossesName = "Losses";
	public static string statsLossesAmount = "0";
	
	//draws
	public static string statsDrawsName = "Draws";
	public static string statsDrawsAmount = "0";
	
	//goals
	public static string statsGoalsName = "Goals Scored";
	public static string statsGoalsAmount = "0";
	
	//conceded
	public static string statsConcededName = "Goals Conceded";
	public static string statsConcededAmount = "0";

	//FANS
	public static string statsFansName = "Fans";
	public static string statsFansAmount = "0";
	
	//winstreak
	public static string statsWinstreakName = "Win Streak";
	public static string statsWinstreakAmount = "0";

	//top winstreak
	public static string statsTopWinstreakName = "Biggest Win Streak";
	public static string statsTopWinstreakAmount = "0";
	
	//lives
	public static string statsLivesName = "Lives";
	public static string statsLivesAmount = "5";
	
	//login
	int unixTimestamp = 0;

	public static string statsLoginName = "Last Login";
	public static string statsLoginAmount = "";
	
	//team supported
	public static string statsTeamName = "Team Supported";
	public static string statsTeamAmount = "";

	//STAR PLAYERS
	//star player 1

	public static string starTokens1 = "0";
	public static string starTokens2 = "0";
	public static string starTokens3 = "0";

	public static string PowerUp1Amount = "0";
	public static string PowerUp2Amount = "0";
	public static string PowerUp3Amount = "0";

	public static int coins = 10;

	// Use this for initialization
	void Start () {
		unixTimestamp = (int)(DateTime.UtcNow.Subtract (new DateTime (1970, 1, 1))).TotalSeconds;
		UserData.statsLoginAmount = unixTimestamp.ToString();
	}

	public static void updateUser (string updatePath, string updateValue){
		// updates specific fields in the DB
		UserData.messenger = new Dictionary<string, object>();
		UserData.messenger.Add ("@class", ".LogEventRequest");
		UserData.messenger.Add ("eventKey", "PROG_UPDATE");
		UserData.messenger.Add ("PATH", updatePath);
		UserData.messenger.Add ("VAL", updateValue);
		
	}
    
}
