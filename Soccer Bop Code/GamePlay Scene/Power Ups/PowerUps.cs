using UnityEngine;

// Neil Byrne - 2015

// Generates collectible power ups in one of 9 positions on the pitch. Will not place power up in position where there is a player.

public class PowerUps : MonoBehaviour {

	public GameObject power1; // keeper
	public GameObject power2 = null; // fire shot
	public GameObject power3 = null; // multitouch
	public GameObject power4 = null; // fire shot
	public GameObject power5 = null; // multitouch

	public GameObject sfx;

	public Transform[] spawns = new Transform[9];


	// Use this for initialization
	void Start () {
		if (UserData.gameMode != "2player") {
			Invoke ("power", 7);
		}
	}

	void power(){
		power1.SetActive (false);
		power2.SetActive (false);
		power3.SetActive (false);
		power4.SetActive (false);
		power5.SetActive (false);
		if ((powerUpHolder.place1 == 0) || (powerUpHolder.place2 == 0) || (powerUpHolder.place3 == 0)) {
			if ((GameControl.gameStart)&&(Countdown.startTime)) {
				int rR = Random.Range(0,15);
				while ((rR == GameControl.play1_1_BLOCK)||(rR == GameControl.play1_2_BLOCK)||(rR == GameControl.play1_3_BLOCK)||(rR == GameControl.play2_1_BLOCK)||(rR == GameControl.play2_2_BLOCK)||(rR == GameControl.play2_3_BLOCK)){
					rR = Random.Range(0,15);
				}
				if (Random.Range (0.0f, 1.0f) < 0.17) {
					power1.SetActive(true);
					power1.transform.position = spawns [rR].transform.position;
				} else if (Random.Range (0.0f, 1.0f) < 0.34) {				
					power2.SetActive(true);
					power2.transform.position = spawns [rR].transform.position;
				} else if (Random.Range (0.0f, 1.0f) < 0.53) {
					power3.SetActive(true);
					power3.transform.position = spawns [rR].transform.position;
				} else if (Random.Range (0.0f, 1.0f) < 0.7) {
				}else if (Random.Range (0.0f, 1.0f) < 0.87) {
					power5.SetActive(true);
					power5.transform.position = spawns [rR].transform.position;
				}
				else {
					
				}
                
			}	
		}
		Invoke ("power", 7);

	}
    	
}
