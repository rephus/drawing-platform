using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public Vector3 direction = Vector3.left;
	public bool changeDirection = true;
	// Update is called once per frame
	void Update () {

		if (changeDirection)DetectChangeDirection();
		
		Vector3 position = this.transform.position ;
		position += direction * Time.deltaTime;
		this.transform.position = position;
	}

	void DetectChangeDirection() {
		Vector3 start = this.transform.position;
		
		//Debug.DrawRay(start, dir);
		if(!Physics.Raycast(start,  new Vector3(direction.x, -1f, 0),1)) ChangeDirection();
		else if (Physics.Raycast(start,  new Vector3(direction.x, 0, 0),0.6f)) ChangeDirection(); 
		         
	}

	void ChangeDirection(){
		if (direction == Vector3.left) direction = Vector3.right;
		else direction = Vector3.left;
	}
}
