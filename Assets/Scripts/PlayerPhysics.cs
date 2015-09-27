using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {

	public float rotateSpeedFactor = 360;
	
	private float skin = 0.75f;
	private float edgeRight = 0;
	private float edgeLeft = 0;
	private float edgeTop = 0;
	private float edgeBottom = 0;
	
	private bool gameHasWalls = false;

	void Start () {
		
		edgeRight = GameObject.FindGameObjectWithTag("RightWall").transform.position.x - skin;
		edgeLeft = GameObject.FindGameObjectWithTag("LeftWall").transform.position.x + skin;
		edgeTop = GameObject.FindGameObjectWithTag("TopWall").transform.position.y - skin;
		edgeBottom = GameObject.FindGameObjectWithTag("BottomWall").transform.position.y + skin;
		
		if(edgeRight != 0 && edgeLeft != 0 && edgeTop != 0 && edgeBottom != 0){
			gameHasWalls = true;
		}
	}
	
	public void Move(Vector2 moveAmount){
		
		float deltaY = moveAmount.y;
		float deltaR = moveAmount.x;
		
		transform.Translate(new Vector2(0, deltaY));
		transform.Rotate(Vector3.forward * -deltaR * rotateSpeedFactor * Time.deltaTime);
		
		//check for wall collisiions
		if(gameHasWalls){
			if(transform.position.x < edgeLeft){
				transform.position = new Vector2(edgeLeft, transform.position.y);
			}else if (transform.position.x > edgeRight){
				transform.position = new Vector2(edgeRight, transform.position.y);
			}
			if(transform.position.y < edgeBottom){
				transform.position = new Vector2(transform.position.x, edgeBottom);
			}else if(transform.position.y > edgeTop){
				transform.position = new Vector2(transform.position.x, edgeTop);
			}
		}
	}
}
