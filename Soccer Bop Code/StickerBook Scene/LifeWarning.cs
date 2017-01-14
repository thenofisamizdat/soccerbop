using UnityEngine;
using System.Collections;

// Neil Byrne - 2015

// Warns player when they are out of lives and displays life regeneration timer.

public class LifeWarning : MonoBehaviour {

	public GameObject redTicket;
	
	void Update () {
		if (PlayerObject.player [Login.fbuid].lives == 0) {
			if (!redTicket.activeSelf){
				redTicket.SetActive (true);
			}
		}
		else {
			if (redTicket.activeSelf){
				redTicket.SetActive (false);
			}
		}
	}
}
