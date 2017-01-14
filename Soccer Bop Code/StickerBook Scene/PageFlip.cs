using UnityEngine;
using DG.Tweening;

// Neil Byrne - 2015

// Page turning is controlled here. It is a fairly complex process.
// There are two sticker book game objects, one in front of the other on the z axis.
// Each have a right page and left as child objects of the parent book.
// When the pageFlip is called the right page begins rotation on the z-axis, revealing the right page of the book previously obscured.
// As the rotating page passes 90 degrees we have to switch z-index positions of page left from front and back books.
// This gives the illusion of there being a full sticker book with front and back print on pages. The reverse is true of the page going the opposite direction.
// Once the transition has completed we return to our original object structure and rebuild the pages according to the teams as they should show..

public class PageFlip : MonoBehaviour {

	public static string newTeam = "aSRoma";
	
	void Start () {
		pageLeft1 = GameObject.Find ("pageLeft");
		pageLeft2 = GameObject.Find ("pageLeftB");
		pageRight1 = GameObject.Find ("pageRight");
		pageRight2 = GameObject.Find ("pageRightB");
	}

	GameObject pageLeft1;
	GameObject pageLeft2;
	GameObject pageRight1;
	GameObject pageRight2;

	void flipper(){

		pageLeft2.GetComponent<RectTransform> ().Rotate(new Vector3 (0, 180, 0));
		pageLeft2.GetComponent<RectTransform> ().DOLocalRotate (new Vector3 (0, 0, 0), .8f).OnComplete(changeParent1).SetEase (Ease.Linear);
		pageRight1.GetComponent<RectTransform> ().DOLocalRotate (new Vector3 (0, -90, 0), .8f).OnComplete (changeParent2).SetEase (Ease.Linear);
	}

	void changeParent1(){
		pageLeft2.transform.parent = GameObject.Find ("topBook").transform;
		pageLeft2.GetComponent<RectTransform> ().Rotate(new Vector3 (0, 90, 0));
		pageLeft2.GetComponent<RectTransform> ().DOLocalRotate (new Vector3 (0, 0, 0), .8f).OnComplete(changeNames).SetEase (Ease.Linear);
	}
	void changeParent2(){

		pageRight1.transform.parent = GameObject.Find ("bottomBook").transform;
		pageRight2.transform.parent = GameObject.Find ("topBook").transform;
		pageLeft1.transform.parent = GameObject.Find ("bottomBook").transform;
		pageRight1.GetComponent<RectTransform> ().Rotate(new Vector3 (0, 90, 0));
	}
	public static string oldTeam = "aSRoma";
	void changeNames(){
		pageFlip.oldTeam = GameControl.team1;
		GameControl.team1 = pageFlip.newTeam;
		pageFlip.newTeam = pageFlip.oldTeam;

		pageCrest.crestChangerTop = true;
		pageCrest.crestChangerBottom = true;

		teamCompletion.calc1 = true;
		teamCompletion.calc2 = true;

		pageLeft1.name = "pageLeftB";
		pageLeft2.name = "pageLeft";
		pageRight1.name = "pageRightB";
		pageRight2.name = "pageRight";

		pageLeft1 = GameObject.Find ("pageLeft");
		pageLeft2 = GameObject.Find ("pageLeftB");
		pageRight1 = GameObject.Find ("pageRight");
		pageRight2 = GameObject.Find ("pageRightB");

		pageRight1.GetComponent<RectTransform> ().Rotate(new Vector3 (0, 0, 0));
		pageRight2.GetComponent<RectTransform> ().Rotate(new Vector3 (0, 0, 0));
		pageLeft1.GetComponent<RectTransform> ().Rotate(new Vector3 (0, 0, 0));
		pageLeft2.GetComponent<RectTransform> ().Rotate(new Vector3 (0, 0, 0));

		teamRotate =GameObject.Find ("TeamSelect").transform.FindChild ("TeamRotate").gameObject;
		teamRotate.SetActive (true);
		teamRotate2 =GameObject.Find ("TeamSelectB").transform.FindChild ("TeamRotate").gameObject;
		teamRotate2.SetActive (true);
		Destroy (GameObject.Find ("flatImage"));
	}

	GameObject teamRotate;
	GameObject teamRotate2;

	public static bool flip = false;
	// Update is called once per frame
	void Update () {
		if (pageFlip.flip) {
			flipper ();		
			pageFlip.flip = false;
		}
	}
}
