using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public Vector3 moveDirection = Vector3.zero;
	public bool forceJump = false;

	private CharacterController controller;
	void Start(){
		controller = GetComponent<CharacterController>();
	}
	void Update() {
		
		//Reduce jump intensity if button is released
		if (!forceJump && moveDirection.y > 0 && !(Input.GetButton("Jump") || Input.GetAxis("Vertical") > 0) ){
			moveDirection.y = 0;
		}
		if (controller.isGrounded && moveDirection.y < 0) {
			forceJump= false;
			//We can only move if we are grounded ( direction can't be controlled on air)
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0/*Input.GetAxis("Vertical")*/);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump") || Input.GetAxis("Vertical") > 0){
				moveDirection.y = jumpSpeed;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
	void OnCollisionEnter (Collision other) {
		Vector3 myCollisionNormal = other.contacts[0].normal;
		//Break jump if we hit the bottom of a wall (down)
		if (moveDirection.y > 0 && myCollisionNormal == Vector3.down) {
			Debug.Log ("Player collision with "+this.name);	
			moveDirection.y = 0;
		}

		if (other.gameObject.tag == "Enemy" ) {
			Debug.Log("Player collision normal " + myCollisionNormal);
			bool fromAbove = (myCollisionNormal.y > 0.5) ;
			if (moveDirection.y < 0 && fromAbove) {
				moveDirection.y = jumpSpeed / 2;
				forceJump = true;
				Destroy (other.gameObject);
			} else Application.LoadLevel(0);
		}
			
	}
}


