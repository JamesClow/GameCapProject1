using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	float menuWidth = 200;
	float menuHeight = 150;
	float buttonWidth = 180;
	float buttonHeight = 70;

	void OnGUI () {

		GUI.Box(new Rect(Screen.width/2 - menuWidth/2, Screen.height/2 - menuHeight/2, menuWidth, menuHeight), 
		        "HighScore: "+PlayerPrefs.GetInt("highScore").ToString()+"\n"+"Score: "+PlayerPrefs.GetInt("score").ToString());
		
		if(GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, Screen.height/2 - buttonHeight/2 + 10, buttonWidth, buttonHeight), "Play")) {
			Application.LoadLevel("Play");
		}
	}
}
