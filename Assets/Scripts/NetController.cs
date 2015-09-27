using UnityEngine;
using System.Collections;

public class NetController : MonoBehaviour {

	public GameObject net;

	float netDelay = 1;
	bool canShoot = true;
	float nextNet;

	// Use this for initialization
	void Start () {
		nextNet = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")){
			if (canShoot == true) {
				SpawnNet();
			}
		}
		if (nextNet <= Time.time) {
			canShoot = true;
		}
	}

	void OnGUI () {
		if (canShoot == true){
			GUI.Box(new Rect(Screen.width/2 - 50, 50, 100, 20), "Ready!");
		}
	}

	void SpawnNet() {
		GameObject obj = Instantiate (net, GetSpawnLocation(), Quaternion.identity) as GameObject;
		canShoot = false;
		nextNet = Time.time + netDelay;
	}

	Vector2 GetSpawnLocation() {
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return mousePos;
	}
}
