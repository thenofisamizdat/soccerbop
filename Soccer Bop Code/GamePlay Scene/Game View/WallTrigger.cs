using UnityEngine;

// Neil Byrne - 2015

// WallTrigger waits for collisions with the edges of the pitch and reverses the velocity of the colliding object
// This is used in conjunction with Unity's own physics to ensure objects don't get stuck against the edges.

public class wallTrigger : MonoBehaviour {
  	
	float y;
	float x;
	bool bounced = false;

	void changeBack(){
		bounced = false;
	}
	void OnCollisionEnter2D(Collision2D other) {
		
		if (!bounced) {
			bounced = true;
			Invoke ("changeBack", 0.3f);
			if (this.gameObject.name == "top"){
				y = other.transform.GetComponent<Rigidbody2D>().velocity.y * -1;
				x = other.transform.GetComponent<Rigidbody2D>().velocity.x;
				other.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);	
			}
			else if (this.gameObject.name == "right"){
				y = other.transform.GetComponent<Rigidbody2D>().velocity.y;
				x = other.transform.GetComponent<Rigidbody2D>().velocity.x * -1;
				other.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);	
			}
			else if(this.gameObject.name == "left"){
				y = other.transform.GetComponent<Rigidbody2D>().velocity.y;
				x = other.transform.GetComponent<Rigidbody2D>().velocity.x * -1;
				other.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);	
			}
			else if(this.gameObject.name == "bottom"){
				y = other.transform.GetComponent<Rigidbody2D>().velocity.y * -1;
				x = other.transform.GetComponent<Rigidbody2D>().velocity.x;
				other.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);	
			}	
		}
	}
}
