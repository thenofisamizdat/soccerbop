using UnityEngine;
using UnityEngine.Advertisements;

// Neil Byrne - 2015

// CrestsMain places the team crests in position in the HUD

public class crestsMain : MonoBehaviour {
		
	// Update is called once per frame
	void Update () {
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("crest"))
		{
			if ((go.name != GameControl.team1)&&(go.name!= GameControl.team2)){
				go.transform.position = GameObject.Find ("position5").transform.position;
			}

		}
		if (!Advertisement.isShowing){
			this.transform.parent.FindChild(GameControl.team1+"C").GetComponent<RectTransform>().position = GameObject.Find ("Crest1").GetComponent<RectTransform>().position;
			this.transform.parent.FindChild(GameControl.team2+"C").GetComponent<RectTransform>().position = GameObject.Find ("Crest2").GetComponent<RectTransform>().position;
		}
	

	}
}
