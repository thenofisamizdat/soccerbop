using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// Neil Byrne - 2015

// Here we attempt to load player details and if no data exists, we create a new user profile
// We create new teams, achievements, stats and leagues classes that are associated with the player.
// We also check to see when a player last logged in, and we increment the amount of lives they have based on time passed.

public class PlayerObject : MonoBehaviour {

	public static IDictionary<string, playerData> player = new Dictionary<string, playerData>();

	void Awake () {
		if (PlayerObject.player.Count == 0) { // load player
			SerializeGame.Load ();
		}
		if (PlayerObject.player.Count == 0) { // new player
			player.Add (Login.fbuid, new playerData{ playerID = Login.fbuid, coins = 1000, fans = 0, lives = 5, playersAmount = 0, playerName = UserData.displayName, 
			createdLeagues = new ArrayList(), coinBonus = 0, lastCoinBonus = 0,
			playerLeagues = new Dictionary<string, leagues>(), teams = new Dictionary<string, teams>()});
			addTeamInfo ();
		}
		if ((PlayerObject.player.ContainsKey ("Guest"))&&(Login.fbuid == FB.UserId)) {
			PlayerObject.player[Login.fbuid] = PlayerObject.player["Guest"];
			PlayerObject.player[Login.fbuid].playerID = Login.fbuid;
			PlayerObject.player[Login.fbuid].playerName = GameControl.Username;
			PlayerObject.player.Remove("Guest");
		}
		int timeNow = (int)(DateTime.UtcNow.Subtract (new DateTime (1970, 1, 1))).TotalSeconds;
		if (timeNow - PlayerObject.player [Login.fbuid].lastCoinBonus > 86400) { // notify player of coin bonus
			PlayerObject.player[Login.fbuid].lastCoinBonus = (int)(DateTime.UtcNow.Subtract (new DateTime (1970, 1, 1))).TotalSeconds;
			PlayerObject.player[Login.fbuid].coinBonus = 1;
			PlayerObject.player[Login.fbuid].coins += 200;
		}
	}


	void addTeamInfo(){
		player [Login.fbuid].teams.Add ("aPOELNikosia",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("aBilbao",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("aFCAjax",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("anderlecht",  new teams { stars = new Dictionary<string, int> ()});

		player [Login.fbuid].teams.Add ("cataloniaFC",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("malmo",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("maribor",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("manCityFC",  new teams { stars = new Dictionary<string, int> ()});

		player [Login.fbuid].teams.Add ("aSMonaco",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("aSRoma",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("bateBorisov",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("bLeverkusen",  new teams { stars = new Dictionary<string, int> ()});
		
		player [Login.fbuid].teams.Add ("chelsea",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("aMadrid",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("benfica",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("bDortmund",  new teams { stars = new Dictionary<string, int> ()});

		player [Login.fbuid].teams.Add ("cSKAMoskva",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("ludogoretsRazgrad",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("fCBasel",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("olympiakos",  new teams { stars = new Dictionary<string, int> ()});
		
		player [Login.fbuid].teams.Add ("parisSG",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("porto",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("shakhtarDonetsk",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("juventus",  new teams { stars = new Dictionary<string, int> ()});

		player [Login.fbuid].teams.Add ("schalkeFC",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("madridCity",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("hollowayRoad",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("istanbulFC",  new teams { stars = new Dictionary<string, int> ()});
		
		player [Login.fbuid].teams.Add ("MerseysideRed",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("munichFC",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("sportingLisbon",  new teams { stars = new Dictionary<string, int> ()});
		player [Login.fbuid].teams.Add ("zenit",  new teams { stars = new Dictionary<string, int> ()});
	}

}

[Serializable]
public class playerData{
	public string playerID { get; set; }
	public string playerName { get; set; }
	public IDictionary<string, stats> playerStats { get; set; }
	public int coins { get; set; }
	public int lives { get; set; }
	public IDictionary<string, achievements> playerAchievements { get; set; }
	public int fans { get; set; }
	public IDictionary<string, leagues> playerLeagues { get; set; }
	public ArrayList createdLeagues { get; set; }
	public int level { get; set; }
	public int playersAmount { get; set; }
	public IDictionary<string, teams> teams { get; set; }
	public int lastPlayed { get; set; }
	public int coinBonus { get; set; }
	public int lastCoinBonus { get; set; }
}
[Serializable]
public class teams{
	public IDictionary<string, int> stars { get; set; }
}
[Serializable]
public class stats{
	public int wins { get; set; }
	public int losses { get; set; }
	public int draws { get; set; }
	public int goalsFor { get; set; }
	public int goalsAgainst { get; set; }

}
[Serializable]
public class achievements{
	public string achievementID { get; set; }
	public string achievementName { get; set; }
	public int fansGenerated { get; set; }
}

public class leagues{
		public string leagueID { get; set; }
		public int startTime { get; set; }
		public int endTime { get; set; }
		public string name { get; set; }
}
