using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// ShotClock shows a decresing graphical representation of the time left for each player to take their shot.

public class ShotClock : MonoBehaviour {

	float h = 7;
	float w = 325;
	// Update is called once per frame
	void Update () {
		if (this.name == "shotClockLeft") {
			if (GameControl.turn == 1) {
				w = 325 * (Countdown.shotClock / 5);
				GameObject.Find ("shotClockLeft").GetComponent<Image>().color = new Vector4 (255,255,255,255);
				GameObject.Find ("shotClockRight").GetComponent<Image>().color = new Vector4 (255,255,255,0);
				GameObject.Find ("shotClockLeft").GetComponent<RectTransform>().sizeDelta = new Vector2(w,h);
			}	
		}
		else if (this.name == "shotClockRight") {
			if (GameControl.turn == 2) {
				w = 325 * (Countdown.shotClock / 5);
				GameObject.Find ("shotClockRight").GetComponent<Image>().color = new Vector4 (255,255,255,255);
				GameObject.Find ("shotClockLeft").GetComponent<Image>().color = new Vector4 (255,255,255,0);
				GameObject.Find ("shotClockRight").GetComponent<RectTransform>().sizeDelta = new Vector2(w,h);
			}	
		}
	}
}
