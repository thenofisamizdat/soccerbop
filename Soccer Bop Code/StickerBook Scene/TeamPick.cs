using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Neil Byrne - 2015

// This clss listens for user team select and turns page of sticker book to display selected team
// It also contains a function for taking a screen shot of your team that can be shared on facebook.

public class TeamPick : MonoBehaviour {

	void Start () {
		teamRotate = this.transform.parent.parent.gameObject;
		this.GetComponent<Button> ().onClick.AddListener (this.pickTeam);
	}

	GameObject teamRotate;

	void pickTeam(){
		if (this.GetComponent<Image> ().sprite.name != GameControl.team1) {
			StartCoroutine(TakePict());

			foreach(GameObject go in GameObject.FindGameObjectsWithTag("crest"))
			{
				if (go.transform.parent.name == "crests"){
					go.GetComponent<Image> ().material = GameObject.Find ("Colour").GetComponent<Image> ().material;
				}
			}
		
			pageFlip.newTeam = this.GetComponent<Image> ().sprite.name;
			GameObject.Find ("TeamSelect").transform.FindChild("crests").FindChild(pageFlip.newTeam+"C").gameObject.GetComponent<Image> ().material = GameObject.Find ("BlackAndWhite").GetComponent<Image> ().material;
			GameObject.Find ("TeamSelectB").transform.FindChild("crests").FindChild(pageFlip.newTeam+"C").gameObject.GetComponent<Image> ().material = GameObject.Find ("BlackAndWhite").GetComponent<Image> ().material;
			
			pageCrest.crestChangerBottom = true;
			teamCompletion.calc2 = true;
			pageFlip.flip = true;
		}
	}

	private IEnumerator TakePict()
	{
		yield return new WaitForEndOfFrame();
		
		Vector3 octPos = Camera.main.WorldToScreenPoint (GameObject.Find ("TeamRotate").GetComponent<RectTransform> ().position);
		float xp = octPos.x - 100;
		float yp = octPos.y - 50;
		int width = 200;
		int height = 100;
		
		var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		// Read screen contents into the texture
		tex.ReadPixels(new Rect (xp, yp, width, height), 0,0);
		tex.Apply();
		GameObject flatImage = new GameObject ();
		flatImage.name = "flatImage";
		flatImage.AddComponent<RawImage> ();
		flatImage.GetComponent<RawImage> ().texture = tex;
		flatImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 (width, height);
		flatImage.transform.parent = GameObject.Find ("TeamRotate").transform.parent;
		flatImage.GetComponent<RectTransform> ().position = GameObject.Find ("TeamRotate").GetComponent<RectTransform> ().position;
		flatImage.GetComponent<RectTransform> ().localScale = new Vector3 (1.3f, 1.3f, 1);
		teamRotate.SetActive (false);
	}
    
}
