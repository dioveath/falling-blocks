using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject fallingBlockPrefab;
	public Vector2 secondsBetweenSpawnsMinMax;
	float nextSpawnTime;

	public Vector2 sizeMinMax;
	public float rotationMax;

	Vector2 screenHalfSizeWorldUnits;


	void Start(){
		screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}

	void Update(){ 
		if (Time.time > nextSpawnTime) {
			float secondsBetweenSpawns = Mathf.Lerp (secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.getDifficultyPercent ());
			nextSpawnTime = Time.time + secondsBetweenSpawns;

			float spawnSize = Random.Range (sizeMinMax.x, sizeMinMax.y);
			float spawnRotation = Random.Range (-rotationMax, rotationMax);

			Vector2 spawnPosition = new Vector2 (UnityEngine.Random.Range (-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
			GameObject newBlock = (GameObject) Instantiate (fallingBlockPrefab, spawnPosition, Quaternion.Euler (Vector3.forward * spawnRotation));
			newBlock.transform.localScale = Vector3.one * spawnSize;
		}
	}
}
