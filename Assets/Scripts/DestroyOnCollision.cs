using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	void OnCollisionEnter (Collision other) {
		Vector3 myCollisionNormal = other.contacts[0].normal;
		//Destroy on collision from below
		if (other.gameObject.name == "Player" && myCollisionNormal == Vector3.up) {
			Destroy (this.gameObject);
		}
	}
}


