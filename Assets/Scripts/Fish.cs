using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

	private Transform player;

	private float speed = 1;

	void Start () {
		player = GameObject.Find("Player").transform;
	}

	void Update () {
		Move();
	}

	void Move() {
		transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
	}

	void Death(){
		GameObject.Find("LevelController").SendMessage("incScore", 5);
		Destroy(gameObject);
	}
}
