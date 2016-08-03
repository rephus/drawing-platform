using UnityEngine;
using System.Collections;

public class RestartOnCollision : MonoBehaviour {

	void OnCollisionEnter (Collision other) {
		
		if (other.gameObject.name == "Player") {
			Debug.Log ("Destroy on Collision with "+this.name);	
			
			Application.LoadLevel(0);
		}
	}


}
