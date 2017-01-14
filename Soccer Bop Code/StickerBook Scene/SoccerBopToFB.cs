using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Neil Byrne - 2015

// Takes a screenshot and posts to facebook with a message, saving in user pics

public class SoccerBopToFB : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Button> ().onClick.AddListener (this.persist);
	}

	private IEnumerator TakeScreenshot()
	{
		yield return new WaitForEndOfFrame();
		
		var width = Screen.width;
		var height = Screen.height;
		var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		// Read screen contents into the texture
		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		tex.Apply();
		byte[] screenshot = tex.EncodeToPNG();
		
		var wwwForm = new WWWForm();
		wwwForm.AddBinaryData("image", screenshot, "bop.png");
		wwwForm.AddField("message", "Come Play Soccer Bop!");
		
		FB.API("me/photos", Facebook.HttpMethod.POST, null, wwwForm);
	}

	
	void persist(){
		StartCoroutine (TakeScreenshot ());
	}
}
