using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Net : MonoBehaviour {

	List<GameObject> inNet = new List<GameObject>();

	private float catchDelay = 0.3f;

	void Start () {
		Invoke ("Catch", catchDelay);
	}

	void Update () {

	}

	void OnTriggerEnter2D (Collider2D col){
		Debug.Log("Collision");
		inNet.Add (col.gameObject);
		foreach (GameObject obj in inNet) {
			Debug.Log(obj.tag);
			print (obj.tag);
		}
	}
	
	void OnTriggerExit2D(Collider2D col){
		Debug.Log ("Exit");
		inNet.Remove (col.gameObject);
		foreach (GameObject obj in inNet) {
			Debug.Log(obj.tag);
			print (obj.tag);
		}
	}

	void Catch() {
		foreach (GameObject obj in inNet) {
			if(obj.tag == "Fish"){
				obj.SendMessage("Death");
			}
		}
		Death();
	}

	void Death() {
		Destroy(gameObject);
	}
}
