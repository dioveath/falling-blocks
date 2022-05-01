using UnityEngine;

public static class Difficulty {

	static float secondsToMaxDifficulty = 60;

	public static float getDifficultyPercent(){
		return Mathf.Clamp01 (Time.timeSinceLevelLoad / secondsToMaxDifficulty);
	}
}