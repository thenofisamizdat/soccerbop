using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Neil byrne - 2015

// This class attempts to fetch the user's profile image from Facebook and display it in the HUD

public class HomeProfile : MonoBehaviour {

	private bool pics = false;

	void Awake () {
		
		if (FB.IsLoggedIn) {
			if (this.name == "FB"){
				LoadPicture (Util.GetPictureURL (Login.fbuid, 128, 128));  
			}
			else if (this.name == "FBplayers"){
				LoadPicture (Util.GetPictureURL (this.transform.parent.name.Substring(0, this.transform.parent.name.Length - 17), 128, 128));  
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (pics) {
			this.GetComponent<RawImage>().texture = GameControl.UserTexture;
		}
	}

	IEnumerator LoadPictureEnumerator(string url )    
	{
		WWW www = new WWW(url);
		yield return www;
		MyPictureCallback(www.texture);
	}
	void MyPictureCallback(Texture texture)                                                                                        
	{                                                                                                                              
		Util.Log("MyPictureCallback");                                                                                          
		
		if (texture == null)                                                                                                  
		{                                                                                                                          
			// Let's just try again
			if (this.name == "FB"){
				LoadPicture (Util.GetPictureURL (Login.fbuid, 128, 128));  
			}
			else if (this.transform.parent.name == "FBplayers"){
				LoadPicture (Util.GetPictureURL (this.transform.parent.name.Substring(0, this.transform.parent.name.Length - 7), 128, 128));  
			}
			                        
			return;                                                                                                                
		}                                                                                                                          
		GameControl.UserTexture = texture;    
		pics = true;
	}   
	void LoadPicture (string url)
	{
		FB.API(url,Facebook.HttpMethod.GET,result =>
		       {
			if (result.Error != null)
			{
				Util.LogError(result.Error);
				return;
			}
			
			var imageUrl = Util.DeserializePictureURLString(result.Text);
			
			StartCoroutine(LoadPictureEnumerator(imageUrl));
		});
	}
}
