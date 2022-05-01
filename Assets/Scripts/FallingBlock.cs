using UnityEngine;
using System.Collections;
using System;

public class FallingBlock : MonoBehaviour {

	float speed;
	public Vector2 speedMinMax;

	float visibleHeightThreshold;

	void Start(){

		visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;

		speed = Mathf.Lerp (speedMinMax.x, speedMinMax.y, Difficulty.getDifficultyPercent ());
	}

	void Update(){
		transform.Translate (Vector2.down * speed * Time.deltaTime);

		if (transform.position.y < visibleHeightThreshold) {
			Destroy (gameObject);
		}
	}
}
