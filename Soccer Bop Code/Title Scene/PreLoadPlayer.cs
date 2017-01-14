using UnityEngine;

// Neil Byrne

// This is a useful operation that attempts to load data stored on the device.
// If there is stored information then the user has played before and we can skip the login / title screen
// Otherwise the login is presented as normal.

public class PreLoadPlayer : MonoBehaviour {

	void Awake () {
		if (PlayerObject.player.Count == 0) {
			SerializeGame.Load ();
		}
	}
}
