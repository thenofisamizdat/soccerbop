using UnityEngine;

// Neil Byrne - 2015

// This class generates random flashes to mimic camera flashes from the crowd.
// At random intervals, it randomly selects from 9 different camera positions to flash from giving a natural feel.

public class RandomFlash : MonoBehaviour {

	public GameObject[] flashes = new GameObject[9];

	float r;
	int flash;

	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName == "MainScene"){
			r = (float)Random.Range (1, GameControl.cameraFlashSpeed) / 10;
			flash = Random.Range (0, 8);
			flashes [flash].SetActive (true);
			Invoke ("killFlash", 0.5f);
			Invoke ("playFlash", r);
		}
		else{
			r = (float)Random.Range (1, 5) / 10;
			flash = Random.Range (0, 8);
			flashes [flash].SetActive (true);
			Invoke ("playFlash", r);
			Invoke ("kill", 6);
		}
	}

	void kill(){
		Destroy (this);
	}

	void killFlash(){
		flashes [flash].SetActive (false);
	}

	void playFlash(){
		flashes [flash].SetActive (false);
			if (Application.loadedLevelName == "MainScene"){

				r = (float)Random.Range (1, GameControl.cameraFlashSpeed) / 10;
				flash = Random.Range (0, 8);
				flashes [flash].SetActive (true);
			    Invoke ("killFlash", 0.5f);
				Invoke ("playFlash", r);
			}
			else{
				r = (float)Random.Range (1, 5) / 10;
				flash = Random.Range (0, 8);
				flashes [flash].SetActive (true);
				Invoke ("playFlash", r);
			}
	}

	void goalFlash(){
		for (int j = 0; j < flashes.Length; j++){
			flashes[j].SetActive(false);
		}
		flash = Random.Range (0, 8);
		flashes [flash].SetActive (true);
	}
	int i = 0;
	bool switcharoo = false;
	void Update () {
		if (GameControl.cameraFlashSpeed == 5) {
			if (i < 200){
				i++;
				Invoke("goalFlash", 0.05f);
			}
			else{
				switcharoo = true;
			}
		}
		else{
			if (switcharoo){
				switcharoo = false;
				for (int j = 0; j < flashes.Length; j++){
					flashes[j].SetActive(false);
				}
				i = 0;
			}
		}
	}
}
