using UnityEngine;

// Neil Byrne

// This is an important class that controls facebook Login. 
// It uses a singleton design pattern as it contains a static instance of itself, 
// making all of its elements accessible throughout the application.
// It makes requests to the facebook api to get user details, and then populates the GameControl class
// so as this data persists throughout use. Once this is complete, the next Game Scene is loaded.

public class FacebookLogin : MonoBehaviour {

	public bool clicked = false;
	public bool offline = false;

	public static FacebookLogin SFB = new FacebookLogin();

	void Start () {
		DontDestroyOnLoad(this.transform.gameObject);
		FB.Init(SetInit, OnHideUnity);
	}
	
	public void login(){
			if (!FacebookLogin.SFB.clicked) {
                FacebookLogin.SFB.clicked = true;
				FB.Login("email,publish_actions", AuthCallback);
			}
	}

	private void SetInit() {
		enabled = true; 
		// "enabled" is a magic global; this lets us wait for FB before we start rendering
	}
	
	private void OnHideUnity(bool isGameShown) {
		if (!isGameShown) {
			// pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// start the game back up - we're getting focus again
			Time.timeScale = 1;
		}
	}
	
	
	void AuthCallback(FBResult result) {
		if(FB.IsLoggedIn) {
			OnLoggedIn();
		} else {
			// do something if not logged in
			
		}
	}

	void OnLoggedIn(){
		// Reqest player info and profile picture                                                                           
		FB.API("/me?fields=id,first_name,email,friends.limit(10).fields(first_name,id)", Facebook.HttpMethod.GET, APICallback);  
	}
	
	void APICallback(FBResult result)                                                                                              
	{                                                                                                                                                                                                                      
		if (result.Error != null) {                                                                                           
			FB.API ("/me?fields=id,first_name,email,friends.limit(10).fields(first_name,id)", Facebook.HttpMethod.GET, APICallback);     
			return;                                                                                                                
		} 
		
		GameControl.profile = Util.DeserializeJSONProfile(result.Text);                                                                        
		GameControl.Username = GameControl.profile["first_name"]; 

		GameControl.friends = Util.DeserializeJSONFriends(result.Text);    

		Login.fbuid = FB.UserId;
		Application.LoadLevel("StickerBook");

	}  

}
