using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Sprite basicPlayer;

	private PlayerPhysics playerphysics;
	private SpriteRenderer SR;

	private float speed = 5; //10;
	private float acceleration = 20;
	private float rotateSpeed = 50;
	private float rotateAcceleration = 500;
	private float currentSpeed;
	private float targetSpeed;
	private float rotateCurrentSpeed;
	private float rotateTargetSpeed;
	private Vector2 amountToMove;

	private float mouseX;
	private float mouseY;
	
	void Awake(){
		playerphysics = GetComponent<PlayerPhysics> ();
		//endGame = GetComponent<EndGame>();
	}
	
	void Start () {
		SR = (SpriteRenderer)renderer;
	}
	
	void Update () {
		Move();
		//MoveType2();
	}

	void MoveType2() {
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
		//transform.Translate(new Vector2(0, deltaY));
	}
	void Move (){
		targetSpeed = Input.GetAxisRaw("Vertical") * speed;
		rotateTargetSpeed = Input.GetAxisRaw("Horizontal") * rotateSpeed;
		
		currentSpeed = IncrementTowards (currentSpeed, acceleration, targetSpeed);
		rotateCurrentSpeed = IncrementTowards (rotateCurrentSpeed, rotateAcceleration, rotateTargetSpeed);
		
		amountToMove.y = currentSpeed;
		amountToMove.x = rotateCurrentSpeed;
		
		playerphysics.Move (amountToMove * Time.deltaTime);
	}
	
	//increment s towards t by factor a
	private float IncrementTowards(float s, float a, float t){
		if (s == t){
			return s;
		}else{
			float dir = Mathf.Sign(t-s);
			s += a * Time.deltaTime * dir;
			if (dir == Mathf.Sign (t-s)){
				return s;
			}else{
				return t;
			}
		}
	}
	
	void OnTriggerEnter2D (Collider2D col){
		Debug.Log (col.tag);
		if(col.tag == "Fish"){
			Death();
		}
	}

	void Death(){
		GameObject.Find("LevelController").SendMessage("EndGame");
		Destroy (gameObject);
	}
}
