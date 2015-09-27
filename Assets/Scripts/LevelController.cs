using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	int score = 0;

	float scoreWidth = 200;
	float scoreHeight = 20;

	float nextIncScore = 0;
	float incScoreRate = 1;

	void Start () {
		score = 0;
	}
	
	void Update () {
		if (nextIncScore < Time.time){
			score += 1;
			nextIncScore = Time.time + incScoreRate;
		}
	}

	void OnGUI () {
		GUI.Box(new Rect(Screen.width/2 - scoreWidth/2, 20, scoreWidth, scoreHeight), "Score: "+score.ToString());
	}

	void EndGame() {
		if (score > PlayerPrefs.GetInt("highScore")){
			PlayerPrefs.SetInt("highScore", score);
		}
		PlayerPrefs.SetInt("score", score);

		Application.LoadLevel("Menu");
	}

	void incScore (int val){
		score += val;
	}

}
