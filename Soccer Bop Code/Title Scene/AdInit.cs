using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections.Generic;

// Neil Byrne - 2015

// Initializes the Unity Ads campaign and declares campaign details for Revmob campaign.
// Will activate the login screen after 6 seconds (duration of animation)

public class AdInit : MonoBehaviour {

	public GameObject modeSelect;
	private static readonly Dictionary <string, string> REVMOB_APP_IDS = new Dictionary<string, string>() {
		{ "Android", "54e0b617b8ccbaf83bf484b8"}
	};
	private RevMob revmob;
	
	void Start () {
		Advertisement.Initialize ("22551");
		Invoke ("modeDisplay", 6);
	}
	
	void modeDisplay(){
		modeSelect.SetActive(true);
	}
}
