using UnityEngine;

// Neil Byrne - 2015

// TeamLoad finds 3 random players from the lineup of both teams playing and places them in their start position, ready to play


public class TeamLoad : MonoBehaviour {

	GameObject team1;
	GameObject team2;

	// Use this for initialization
	void Start () {
			teamSleep ();
			selectRandomPlayers (team1Lineup);
			selectRandomPlayers (team2Lineup);
			teamLineup ();
	}

	void selectCompTeam(){
		int ran = Random.Range (0, 32);
		while (preGameSelect.compTeam [ran] == GameControl.team1) {
			ran = Random.Range (0, 32);
		}
		GameControl.team2 = preGameSelect.compTeam [ran];
	}

	int[] team1Lineup = new int[3];
	int[] team2Lineup = new int[3];
	
	void teamLineup(){
		GameObject team1 = GameObject.Find (GameControl.team1);
		Transform jersey = team1.transform.FindChild (GameControl.team1Jersey);
		Transform jerseyOff = team1.transform.FindChild (GameControl.team2Jersey);
		jerseyOff.gameObject.SetActive (false);
		
		GameObject team2 = GameObject.Find (GameControl.team2);
		Transform jersey2 = team2.transform.FindChild (GameControl.team2Jersey);
		Transform jerseyOff2 = team2.transform.FindChild (GameControl.team1Jersey);
		jerseyOff2.gameObject.SetActive (false);
		
		Transform[] players1 = jersey.GetComponentsInChildren<Transform> ();
		Transform[] players2 = jersey2.GetComponentsInChildren<Transform> ();
		
		int t1index = 1;
		int t2index = 1;
		int t1lineupIndex = 0;
		int t2lineupIndex = 0;
		
		foreach (Transform child in players1) {
			if ((child.name != "home") && (child.name != "away")){
				for (int i = 0; i < 3; i++){
					if (t1index == team1Lineup[i]){
						GameControl.teamLineup[t1lineupIndex] = child.name;
						GameObject b = child.gameObject;
						b.gameObject.SetActive(true);
						b.transform.position = team1Spawns[t1lineupIndex].transform.position;
						t1lineupIndex ++;
					}
				}
				t1index ++;
			}
		}
		
		GameControl.play1_1 = GameControl.teamLineup[0];
		GameControl.play1_2 = GameControl.teamLineup[1];
		GameControl.play1_3 = GameControl.teamLineup[2];
		
		foreach (Transform child in players2) {
			if ((child.name != "home") && (child.name != "away")){
				for (int i = 0; i < 3; i++){
					if (t2index == team2Lineup[i]){
						GameControl.compTeamLineup[t2lineupIndex] = child.name;
						GameObject b = child.gameObject;
						b.gameObject.SetActive(true);
						b.transform.position = team2Spawns[t2lineupIndex].transform.position;
						t2lineupIndex ++;
					}
				}
				t2index ++;
			}
		}
		
		GameControl.play2_1 = GameControl.compTeamLineup[0];
		GameControl.play2_2 = GameControl.compTeamLineup[1];
		GameControl.play2_3 = GameControl.compTeamLineup[2];
	}
	
	void teamSleep(){
		for (int i = 0; i < preGameSelect.compTeam.Length; i++) {
			if ((preGameSelect.compTeam[i] != GameControl.team1)&&(preGameSelect.compTeam[i] != GameControl.team2)){
				try{
					GameObject.Find(preGameSelect.compTeam[i]).SetActive(false);
				}
				catch{}
			}
		}
	}
	int b;
	void selectRandomPlayers(int[] a){
		for (int i = 0; i < 3; i++) {
			b = Random.Range(1,6);
			while (a.Contains(b)){
				b = Random.Range(1,6);
			}
			a[i] = 	b;
		}
	}
	
	GameObject teamFind;
	string[] tname = new string[3];

	void teamStart(string team){
		
		if (team == "team1") {
				team1 = GameObject.Find (GameControl.team1);
				Transform jersey = team1.transform.FindChild (GameControl.team1Jersey);
				Transform jerseyOff = team1.transform.FindChild (GameControl.team2Jersey);
				jerseyOff.gameObject.SetActive (false);

				int loadPlace = 0;
				Transform[] players = jersey.GetComponentsInChildren<Transform> ();

			for (int i = 0; i<GameControl.team1Length; i++){
				foreach (Transform child in players) {
						if ((child.name == GameControl.teamLineup[i])&&(i<3)){
							GameObject b = child.gameObject;
							b.gameObject.SetActive(true);
							b.transform.position = team1Spawns[loadPlace].transform.position;
							tname[loadPlace] = child.name;
							loadPlace++;
						}
					}
				}

			GameControl.play1_1 = tname[0];
			GameControl.play1_2 = tname[1];
			GameControl.play1_3 = tname[2];

		}
		else if (team == "team2") {
			tname = new string[3];			
			team2 = GameObject.Find (GameControl.team2);
			Transform jersey = team2.transform.FindChild (GameControl.team2Jersey);
			Transform jerseyOff = team2.transform.FindChild (GameControl.team1Jersey);
			jerseyOff.gameObject.SetActive (false);

			int loadPlace = 0;
			Transform[] players = jersey.GetComponentsInChildren<Transform> ();
			
			for (int i = 0; i<GameControl.team2Length; i++){
				foreach (Transform child in players) {
					if ((child.name == GameControl.compTeamLineup[i])&&(i<3)){
						GameObject b = child.gameObject;
						b.gameObject.SetActive(true);
						b.transform.position = team2Spawns[loadPlace].transform.position;
						tname[loadPlace] = child.name;
						loadPlace++;
					}
				}
			}
			
			GameControl.play2_1 = tname[0];
			GameControl.play2_2 = tname[1];
			GameControl.play2_3 = tname[2];
		}
	}
	
	public Transform[] team1Spawns = new Transform[3];
	public Transform[] team2Spawns = new Transform[3];
	
}
