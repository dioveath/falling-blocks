using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameOverScreen;
	public Text secondsSurvivedUI;

	bool isGameOver;

	void Start(){
		FindObjectOfType<PlayerController>().onDestroyed += OnGameOver;
	}

	void Update(){
		if (isGameOver) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene (0);
			}
		}
	}

	void OnGameOver(){
		isGameOver = true;
		gameOverScreen.SetActive (true);
		secondsSurvivedUI.text = Mathf.RoundToInt (Time.timeSinceLevelLoad).ToString ();
	}
}
