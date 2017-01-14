using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// Neil Byrne - 2015

// The octagon classes perform some complex trickery to maintain the illusion of a rotating octagon containing all 32 teams.
// As there are only 8 sides, yet with 3 facing the user at any time, the algorithm must know what crests to show, and when to read from each 
// quarter of the teamStorage data struct. There are also complications when rotating and indexing toward 0, 
// as the index will have to allow for a roll back to the last index of the data struct while still showing elements from the start.
// Further to these complications, z-indexing not just of the octagon sides, but also the displayed club crests required great care as the octagon 
// is rotating through 3 dimensions, while the crests 2d and their z-index is dependant on the order of their declaration in the object heirarchy.

public class Octagon : MonoBehaviour {

	public GameObject oct1;
	public GameObject oct2;
	public GameObject oct3;
	public GameObject oct4;
	public GameObject oct5;
	public GameObject oct6;
	public GameObject oct7;
	public GameObject oct8;

	public GameObject oct;

	public static bool bgRotateLeft = false;
	public static bool bgRotateRight = false;
	// Use this for initialization
	void Start () {
		
		this.GetComponent<Button> ().onClick.AddListener (this.rotatoChoose);
		oct.GetComponent<RectTransform> ().rotation = Quaternion.Euler (Vector3.zero);
		oct6.SetActive (false);

		oct1.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[0]+"C").GetComponent<Image>().sprite;
		oct2.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[1]+"C").GetComponent<Image>().sprite;
		oct3.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[2]+"C").GetComponent<Image>().sprite;
		oct4.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[3]+"C").GetComponent<Image>().sprite;
		oct5.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[4]+"C").GetComponent<Image>().sprite;
		oct6.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[5]+"C").GetComponent<Image>().sprite;
		oct7.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[30]+"C").GetComponent<Image>().sprite;
		oct8.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[31]+"C").GetComponent<Image>().sprite;
	}

	void rotatoChoose(){

		if (this.name == "arrowLeft"){
			rotatoLeft();
			OctagonB.bgRotateLeft = true;
		}
		else {
			rotato ();
			OctagonB.bgRotateRight = true;
		}
	}
	public static int pos = 1;
	public static int realPos = 1;

	void displayer(){
		if ((Octagon.realPos >= 1)&& (Octagon.realPos <= 8)) {
			oct1.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[0]+"C").GetComponent<Image>().sprite;
			oct2.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[1]+"C").GetComponent<Image>().sprite;
			oct3.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[2]+"C").GetComponent<Image>().sprite;
			oct4.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[3]+"C").GetComponent<Image>().sprite;
			oct5.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[4]+"C").GetComponent<Image>().sprite;
			oct6.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[5]+"C").GetComponent<Image>().sprite;
			oct7.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[6]+"C").GetComponent<Image>().sprite;
			oct8.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[7]+"C").GetComponent<Image>().sprite;
		}
		else if ((Octagon.realPos >= 9)&& (Octagon.realPos <= 16)) {
			oct1.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[8]+"C").GetComponent<Image>().sprite;
			oct2.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[9]+"C").GetComponent<Image>().sprite;
			oct3.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[10]+"C").GetComponent<Image>().sprite;
			oct4.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[11]+"C").GetComponent<Image>().sprite;
			oct5.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[12]+"C").GetComponent<Image>().sprite;
			oct6.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[13]+"C").GetComponent<Image>().sprite;
			oct7.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[14]+"C").GetComponent<Image>().sprite;
			oct8.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[15]+"C").GetComponent<Image>().sprite;
		}
		else if ((Octagon.realPos >= 17)&& (Octagon.realPos <= 24)) {
			oct1.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[16]+"C").GetComponent<Image>().sprite;
			oct2.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[17]+"C").GetComponent<Image>().sprite;
			oct3.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[18]+"C").GetComponent<Image>().sprite;
			oct4.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[19]+"C").GetComponent<Image>().sprite;
			oct5.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[20]+"C").GetComponent<Image>().sprite;
			oct6.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[21]+"C").GetComponent<Image>().sprite;
			oct7.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[22]+"C").GetComponent<Image>().sprite;
			oct8.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[23]+"C").GetComponent<Image>().sprite;
		}
		else if ((Octagon.realPos >= 25)&& (Octagon.realPos <= 32)) {
			oct1.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[24]+"C").GetComponent<Image>().sprite;
			oct2.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[25]+"C").GetComponent<Image>().sprite;
			oct3.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[26]+"C").GetComponent<Image>().sprite;
			oct4.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[27]+"C").GetComponent<Image>().sprite;
			oct5.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[28]+"C").GetComponent<Image>().sprite;
			oct6.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[29]+"C").GetComponent<Image>().sprite;
			oct7.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[30]+"C").GetComponent<Image>().sprite;
			oct8.transform.FindChild ("tsCrest").GetComponent<Image>().sprite = GameObject.Find (StickerPlace.teamOrder[31]+"C").GetComponent<Image>().sprite;
		}
	}
	void rotato(){
		if (Octagon.pos <= 8) {
			if (Octagon.pos == 1){
				oct.GetComponent<RectTransform> ().rotation = Quaternion.Euler (Vector3.zero);
				oct1.SetActive (true);
				oct2.SetActive (true);
				oct3.SetActive (true);
				oct4.SetActive (true);
				oct5.SetActive (true);
				oct6.SetActive (false);
				oct7.SetActive (false);
				oct8.SetActive (true);
			
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,45,0), 1);
			}
			else if (Octagon.pos == 2){
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,90,0), 1);
				oct1.SetActive (true);
				oct2.SetActive (true);
				oct3.SetActive (true);
				oct4.SetActive (true);
				oct5.SetActive (true);
				oct6.SetActive (false);
				oct7.SetActive (false);
				oct8.SetActive (true);
			}
			else if (Octagon.pos == 3){
				oct1.SetActive (false);
				oct2.SetActive (true);
				oct3.SetActive (true);
				oct4.SetActive (true);
				oct5.SetActive (true);
				oct6.SetActive (false);
				oct7.SetActive (false);
				oct8.SetActive (true);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,135,0), 1);
			}
			else if (Octagon.pos == 4){
				oct1.SetActive (false);
				oct2.SetActive (false);
				oct3.SetActive (true);
				oct4.SetActive (true);
				oct5.SetActive (true);
				oct6.SetActive (true);
				oct7.SetActive (false);
				oct8.SetActive (true);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,180,0), 1);
			}
			else if (Octagon.pos == 5){
				oct1.SetActive (false);
				oct2.SetActive (false);
				oct3.SetActive (false);
				oct4.SetActive (true);
				oct5.SetActive (true);
				oct6.SetActive (true);
				oct7.SetActive (true);
				oct8.SetActive (true);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,225,0), 1);
			}
			else if (Octagon.pos == 6){
				oct1.SetActive (false);
				oct2.SetActive (false);
				oct3.SetActive (false);
				oct4.SetActive (false);
				oct5.SetActive (true);
				oct6.SetActive (true);
				oct7.SetActive (true);
				oct8.SetActive (true);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,270,0), 1);
			}
			else if (Octagon.pos == 7){
				oct1.SetActive (true);
				oct2.SetActive (false);
				oct3.SetActive (false);
				oct4.SetActive (false);
				oct5.SetActive (false);
				oct6.SetActive (true);
				oct7.SetActive (true);
				oct8.SetActive (true);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,315,0), 1);
			}
			else if (Octagon.pos == 8){
				oct1.SetActive (true);
				oct2.SetActive (true);
				oct3.SetActive (false);
				oct4.SetActive (false);
				oct5.SetActive (false);
				oct6.SetActive (false);
				oct7.SetActive (true);
				oct8.SetActive (true);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,360,0), 1, RotateMode.FastBeyond360);
			}
            Octagon.pos++;
            Octagon.realPos ++;

			if (Octagon.realPos > 32) {
                Octagon.pos = 1;
                Octagon.realPos = 1;
			}
			else if (Octagon.realPos > 24) {
                Octagon.pos = Octagon.realPos - 24;	
			}
			else if (Octagon.realPos > 16) {
                Octagon.pos = Octagon.realPos - 16;	
			}
			else if (Octagon.realPos > 8) {
				Octagon.pos = Octagon.realPos - 8;	
			}
			displayer ();
		}
	}

	void rotatoLeft(){
		if (Octagon.pos <= 8) {
			if (Octagon.pos == 1){
				oct1.SetActive (true);
				oct2.SetActive (true);
				oct3.SetActive (true);
				oct4.SetActive (false);
				oct5.SetActive (false);
				oct6.SetActive (false);
				oct7.SetActive (true);
				oct8.SetActive (true);
				oct.GetComponent<RectTransform> ().rotation = Quaternion.Euler (Vector3.zero);

				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,315,0), 1, RotateMode.Fast);
			}
			else if (Octagon.pos == 2){
				oct1.SetActive (true);
				oct2.SetActive (true);
				oct3.SetActive (true);
				oct4.SetActive (false);
				oct5.SetActive (false);
				oct6.SetActive (false);
				oct7.SetActive (false);
				oct8.SetActive (true);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,0,0), 1, RotateMode.Fast);
			}
			else if (Octagon.pos == 3){
				oct1.SetActive (true);
				oct2.SetActive (true);
				oct3.SetActive (true);
				oct4.SetActive (true);
				oct5.SetActive (false);
				oct6.SetActive (false);
				oct7.SetActive (false);
				oct8.SetActive (false);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,45,0), 1, RotateMode.Fast);
			}
			else if (Octagon.pos == 4){
				oct1.SetActive (false);
				oct2.SetActive (true);
				oct3.SetActive (true);
				oct4.SetActive (true);
				oct5.SetActive (true);
				oct6.SetActive (false);
				oct7.SetActive (false);
				oct8.SetActive (false);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,90,0), 1, RotateMode.Fast);
			}
			else if (Octagon.pos == 5){
				oct1.SetActive (false);
				oct2.SetActive (false);
				oct3.SetActive (true);
				oct4.SetActive (true);
				oct5.SetActive (true);
				oct6.SetActive (true);
				oct7.SetActive (false);
				oct8.SetActive (true);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,135,0), 1, RotateMode.Fast);
			}
			else if (Octagon.pos == 6){
				oct1.SetActive (false);
				oct2.SetActive (false);
				oct3.SetActive (false);
				oct4.SetActive (true);
				oct5.SetActive (true);
				oct6.SetActive (true);
				oct7.SetActive (true);
				oct8.SetActive (true);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,180,0), 1, RotateMode.Fast);
			}
			else if (Octagon.pos == 7){
				oct1.SetActive (false);
				oct2.SetActive (false);
				oct3.SetActive (false);
				oct4.SetActive (false);
				oct5.SetActive (true);
				oct6.SetActive (true);
				oct7.SetActive (true);
				oct8.SetActive (true);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,225,0), 1, RotateMode.Fast);
			}
			else if (Octagon.pos == 8){
				oct1.SetActive (true);
				oct2.SetActive (false);
				oct3.SetActive (false);
				oct4.SetActive (false);
				oct5.SetActive (false);
				oct6.SetActive (true);
				oct7.SetActive (true);
				oct8.SetActive (true);
				oct.GetComponent<RectTransform> ().DORotate (new Vector3(0,270,0), 1, RotateMode.Fast);
			}
			Octagon.pos--;
			Octagon.realPos --;
			if (Octagon.pos < 1) {
				Octagon.pos = 8;
			}
			if (Octagon.realPos < 1) {
				Octagon.pos = 8;
				Octagon.realPos = 32;
			}
			else if (Octagon.realPos > 24) {
				Octagon.pos = Octagon.realPos - 24;	
			}
			else if (Octagon.realPos > 16) {
				Octagon.pos = Octagon.realPos - 16;	
			}
			else if (Octagon.realPos > 8) {
				Octagon.pos = Octagon.realPos - 8;	
			}
			displayer ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (Octagon.bgRotateLeft) {
			rotatoLeft();
			Octagon.bgRotateLeft = false;
		}
		else if (Octagon.bgRotateRight){
			rotato ();
			Octagon.bgRotateRight = false;
		}
	}
}
