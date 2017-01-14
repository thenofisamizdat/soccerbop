using UnityEngine;

// Neil Byrne - 2015

// unity automatically adjusts the height of each scene to the screen height
// but applies the same scale to width, which is inconsistent
// This class correctly scales the width in accordance with the device ratio

public class SceneResize : MonoBehaviour {


	int screenHeight;
	int screenWidth;

	public GameObject scene;
	public GameObject placer;

	// Use this for initialization
	void Start () {
		resize ();
	}

	void resize(){
		float preX = placer.GetComponent<Renderer>().bounds.size.x;
		float preY = placer.GetComponent<Renderer>().bounds.size.y;
		float bX = Screen.width;
		float bY = Screen.height;
		float ratioObject = preX / preY;
		float ratioN = bX / bY;
		float newWide = ratioN / ratioObject;
		
		scene.transform.localScale = new Vector3 (newWide, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
