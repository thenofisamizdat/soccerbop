using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Neil Byrne - 2015

// This is a very important class as it handles data persistence. There are 2 functions - Load and Save.
    // Load
    // Load attempts to load data from the file playerInfo.dat on the device. If the file is not found, the function does nothing.
    // If the file is found the data is read in and mapped to the playerDaya class. 
    // The username is tested to see if user has logged in via facebook in the past. 
    // If so, and there is an internet connection present, it automatically logs in to facebook again and loads next scene.
    // If no internet connection is present then it will use stored facebook details like name and user progress and load next scene.

    //Save
    // Saves player data to playerInfo.dat
    // If the file doesn't exist it will be created. It attaches a time stamp to the saved data

public class SerializeGame : MonoBehaviour {
	

	public static BinaryFormatter binaryFormatter = new BinaryFormatter();

	public static void Save (string saveType){
		FileStream file;
		if (!File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
			file.Close();
		}

		BinaryFormatter binaryFormatter = new BinaryFormatter();
		file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

		if (saveType == "pregame") {
			PlayerObject.player[Login.fbuid].lastPlayed = (int)(DateTime.UtcNow.Subtract (new DateTime (1970, 1, 1))).TotalSeconds;
		}
		playerData savePlayer = PlayerObject.player [Login.fbuid];
		
		binaryFormatter.Serialize (file, savePlayer);
	}

	public static void Load(){
	
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			playerData loadPlayer = (playerData) binaryFormatter.Deserialize (file);
			file.Close();

			if (loadPlayer.playerID != "Guest"){ 	// if user has logged in via facebook before then auto login
				Login.fbuid = loadPlayer.playerID;
				GameControl.Username = loadPlayer.playerName;
				PlayerObject.player[Login.fbuid] = loadPlayer;
				if (!FacebookLogin.SFB.offline){
                    FacebookLogin.SFB.login();
				}
				else{
					Application.LoadLevel("StickerBook");
				}
			}
			if (Login.fbuid != "Guest"){
				loadPlayer.playerID = Login.fbuid;
			}
			if (GameControl.Username != "Guest"){
				loadPlayer.playerName = GameControl.Username;
			}

			PlayerObject.player[Login.fbuid] = loadPlayer;
		}
	}

}
