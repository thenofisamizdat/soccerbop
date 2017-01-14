using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// Here we listen for user to select "Play Game" and load up the main game scene

public class GameSelect : MonoBehaviour {

	public GameObject GameSelect;
	public GameObject pool;
	public GameObject hockey;
	public GameObject soccer;
	
	void Start () {
        if (this.name != "soccerPlayButton")
        {
            Debug.Log("hhh");
            this.gameObject.GetComponent<Image>().material = GameObject.Find("BlackAndWhite").GetComponent<Image>().material;
        }
        else {
            this.GetComponent<Button>().onClick.AddListener(this.startGame);
        }
    }

	void startGame(){
		hockey.SetActive (false);
		pool.SetActive (false);
		soccer.SetActive (false);
        //GameSelect.SetActive (true);
        if (this.name == "hockeyPlayButton")
        {
            //Application.LoadLevel ("HockeyBop");	
            hockey.SetActive(true);
        }
        else if (this.name == "poolPlayButton")
        {
            //Application.LoadLevel ("PoolBop");	
            pool.SetActive(true);
        }

        else if (this.name == "soccerPlayButton")
        {
            Application.LoadLevel("MainScene");
            //soccer.SetActive (true);
        }
	}

}
