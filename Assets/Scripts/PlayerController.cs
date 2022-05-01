using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	float screenHalfWidthInWorldUnits;
	float halfPlayerWidth;
	public event System.Action onDestroyed;

	void Start(){
		halfPlayerWidth = transform.localScale.x / 2;

		//ascpect ration * halfScreenHalfWidth 
		//ratio proportion
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize ;
	}

	void Update(){
		float inputX = Input.GetAxisRaw ("Horizontal");
		//direciton is only horizontal so velocity = inputx * speed
		float velocity = inputX * speed;
		transform.Translate (Vector2.right * velocity * Time.deltaTime);
		if (transform.position.x > screenHalfWidthInWorldUnits + halfPlayerWidth) {
			transform.position = new Vector2 (-(screenHalfWidthInWorldUnits + halfPlayerWidth), transform.position.y);
		}
		if (transform.position.x < -(screenHalfWidthInWorldUnits + halfPlayerWidth)) {
			transform.position = new Vector2 ((screenHalfWidthInWorldUnits + halfPlayerWidth), transform.position.y);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Falling Block") {
			if (onDestroyed != null) {
				onDestroyed ();
			}
			Destroy (gameObject);
		}
	}
}
