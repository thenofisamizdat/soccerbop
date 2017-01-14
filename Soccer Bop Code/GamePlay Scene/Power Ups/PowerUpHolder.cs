using UnityEngine;

// Neil Byrne - 2015

// Controls the power up tool bar. If a power up is collected it will show in the bottom bar and be selectable,
// If it is used it will no longer be selectable.

public class PowerUpHolder : MonoBehaviour {

	public static int place1 = 0;
	public static int place2 = 0;
	public static int place3 = 0;

	public GameObject holder1;
	public GameObject holder2;
	public GameObject holder3;

	public GameObject fireshotHolder;
	public GameObject fireshotHolder2;
	public GameObject fireshotHolder3;

	public GameObject keeperHolder1;
	public GameObject keeperHolder2;
	public GameObject keeperHolder3;

	public GameObject badKeeperHolder1;
	public GameObject badKeeperHolder2;
	public GameObject badKeeperHolder3;

	public GameObject multiTouch1;
	public GameObject multiTouch2;
	public GameObject multiTouch3;

	public static bool placing = false;

	public GameObject hold1;
	public GameObject hold2;
	public GameObject holdOff;

	Vector3 holdLeftPos;
	Vector3 holdRightPos;
	// Use this for initialization
	void Start () {
		holdLeftPos = hold1.transform.position;
		holdRightPos = hold2.transform.position;
	}

	public GameObject countdown;
	bool activateCountdown = false;
	// Update is called once per frame
	void Update () {
		if ((GameControl.powerUpinUse != 0) && (!activateCountdown)){
			activateCountdown = true;
			hold1.transform.position = holdOff.transform.position;
			hold2.transform.position = holdOff.transform.position;
			countdown.SetActive(true);
			powerUpHolder.placing = true;
		}
		else if ((GameControl.powerUpinUse == 0) && (activateCountdown)){
			activateCountdown = false;
			hold1.transform.position = holdLeftPos;
			hold2.transform.position = holdRightPos;
			countdown.SetActive(false);
			powerUpHolder.placing = true;
		}

		if (powerUpHolder.placing) {
			powerUpHolder.placing = false;
			if (powerUpHolder.place1 == 1){
				keeperHolder1.transform.position = new Vector2(holder1.transform.position.x, holder1.transform.position.y);
			}
			else if (powerUpHolder.place1 == 2){
				fireshotHolder.transform.position = new Vector2(holder1.transform.position.x, holder1.transform.position.y);
			}
			else if (powerUpHolder.place1 == 3){
				multiTouch1.transform.position = new Vector2(holder1.transform.position.x, holder1.transform.position.y);
			}
			else if (powerUpHolder.place1 == 4){
				badKeeperHolder1.transform.position = new Vector2(holder1.transform.position.x, holder1.transform.position.y);
			}
			if (powerUpHolder.place2 == 1){
				keeperHolder2.transform.position = new Vector2(holder2.transform.position.x, holder2.transform.position.y);
			}
			else if (powerUpHolder.place2 == 2){
				fireshotHolder2.transform.position = new Vector2(holder2.transform.position.x, holder2.transform.position.y);
			}
			else if (powerUpHolder.place2 == 3){
				multiTouch2.transform.position = new Vector2(holder2.transform.position.x, holder2.transform.position.y);
			}
			else if (powerUpHolder.place2 == 4){
				badKeeperHolder2.transform.position = new Vector2(holder2.transform.position.x, holder2.transform.position.y);
			}
			if (powerUpHolder.place3 == 1){
				keeperHolder2.transform.position = new Vector2(holder3.transform.position.x, holder3.transform.position.y);
			}
			else if (powerUpHolder.place3 == 2){
				fireshotHolder3.transform.position = new Vector2(holder3.transform.position.x, holder3.transform.position.y);
			}
			else if (powerUpHolder.place3 == 3){
				multiTouch3.transform.position = new Vector2(holder3.transform.position.x, holder3.transform.position.y);
			}
			else if (powerUpHolder.place3 == 4){
				badKeeperHolder3.transform.position = new Vector2(holder3.transform.position.x, holder3.transform.position.y);
			}
		}
	
	}
}
