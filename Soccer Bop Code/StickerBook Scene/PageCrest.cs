using UnityEngine;
using UnityEngine.UI;

// Neil Byrne - 2015

// Listens for change in selected team and displays the appropriate crest. 
// Not straightforward as the team change has to occur when it is the correct time to show the newly selected team crest (page turning is not instant)

public class PageCrest : MonoBehaviour {

	GameObject tTop;
	GameObject rTop;

	GameObject tBottom;
	GameObject rBottom;
	
	void Start () {
		pageCrest.crestChangerTop = true;
	}

	public static bool crestChangerTop = true;
	public static bool crestChangerBottom = false;
	public static bool cprBottom = true;
	public static bool cprTop = true;
	
	
	void Update () {
		try{
			if ((this.transform.parent.name == "pageLeft")||(this.transform.parent.name == "pageRight")){
				if (this.name == "crestPlacerRight"){
					if(pageCrest.cprTop){
						pageCrest.cprTop = false;
						Destroy (rTop);
						rTop = Instantiate(GameObject.Find (GameControl.team1 + "C"), this.GetComponent<RectTransform> ().position, this.transform.rotation) as GameObject;
						rTop.tag = "clone";
						rTop.GetComponent<RectTransform>().SetParent(this.transform);
						rTop.GetComponent<RectTransform> ().position = this.GetComponent<RectTransform> ().position;
						rTop.GetComponent<RectTransform> ().localScale = this.GetComponent<RectTransform> ().localScale;
						rTop.GetComponent<RectTransform> ().localScale = new Vector3(.7f, .7f, 1);
						rTop.GetComponent<Image> ().material = GameObject.Find ("Colour").GetComponent<Image> ().material;
					}
				}
				else{
					if (pageCrest.crestChangerTop){
						pageCrest.cprTop = true;
						Destroy (tTop);
						pageCrest.crestChangerTop = false;
						tTop = Instantiate(GameObject.Find (GameControl.team1 + "C"), this.GetComponent<RectTransform> ().position, this.transform.rotation) as GameObject;
						tTop.tag = "clone";
						tTop.GetComponent<RectTransform>().SetParent(this.transform);
						tTop.GetComponent<RectTransform> ().position = this.GetComponent<RectTransform> ().position;
						tTop.GetComponent<RectTransform> ().localScale = this.GetComponent<RectTransform> ().localScale;
						tTop.GetComponent<Image> ().material = GameObject.Find ("Colour").GetComponent<Image> ().material;
					}
				}
			}
			else if ((this.transform.parent.name == "pageLeftB")||(this.transform.parent.name == "pageRightB")){
				if (this.name == "crestPlacerRight"){
					if(pageCrest.cprBottom){
						pageCrest.cprBottom = false;
						Destroy (rBottom);
						rBottom = Instantiate(GameObject.Find (pageFlip.newTeam + "C"), this.GetComponent<RectTransform> ().position, this.transform.rotation) as GameObject;
						rBottom.tag = "clone";
						rBottom.GetComponent<RectTransform>().SetParent(this.transform);
						rBottom.GetComponent<RectTransform> ().position = this.GetComponent<RectTransform> ().position;
						rBottom.GetComponent<RectTransform> ().localScale = this.GetComponent<RectTransform> ().localScale;
						rBottom.GetComponent<RectTransform> ().localScale = new Vector3(.7f, .7f, 1);
						rBottom.GetComponent<Image> ().material = GameObject.Find ("Colour").GetComponent<Image> ().material;
					}
				}
				else{
					if (pageCrest.crestChangerBottom){
						pageCrest.cprBottom = true;
						Destroy (tBottom);
						pageCrest.crestChangerBottom = false;
						tBottom = Instantiate(GameObject.Find (pageFlip.newTeam + "C"), this.GetComponent<RectTransform> ().position, this.transform.rotation) as GameObject;
						tBottom.tag = "clone";
						tBottom.GetComponent<RectTransform>().SetParent(this.transform);
						tBottom.GetComponent<RectTransform> ().position = this.GetComponent<RectTransform> ().position;
						tBottom.GetComponent<RectTransform> ().localScale = this.GetComponent<RectTransform> ().localScale;
						tBottom.GetComponent<Image> ().material = GameObject.Find ("Colour").GetComponent<Image> ().material;
					}
				}
			}


		}
		catch{}
	}
}
