using UnityEngine;

// Neil Byrne - 2015
// When the user touches the screen, this class attaches a graphical trail gameobject to the view and follows the user touch
// There is also a static mouseClick state which is controlled here. This is used by other classes in game control to determine
// whether or not to select a player, or apply a transformation of force to a game object

public class MouseManage : MonoBehaviour {

	public static bool mouseClick;
	public GameObject trail;
	
	void Start () {
		mouseManage.mouseClick = false;
		trail.SetActive(false);
	}
	
	void Update () {
		
		if ((PoolGame.poolPlay) || (HockeyBopGameControl.hockeyPlay) || (GameControl.gameStart)) {
			if (Input.GetMouseButtonDown (0)) {
				mouseManage.mouseClick = true;
				trail.SetActive(true);
				
			}
			else if(Input.GetMouseButtonUp(0)){
				
				mouseManage.mouseClick = false;
				trail.SetActive(false);
			}
			
			if (trail.activeSelf) {
				trail.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, trail.transform.position.z);
			}
		}
	}
}
