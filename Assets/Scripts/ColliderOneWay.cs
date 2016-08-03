using UnityEngine;
using System.Collections;

public class ColliderOneWay : MonoBehaviour {

	void OnCollisionEnter(Collision other)	{
		print("Collision detected with trigger object " + other.gameObject.name);
		Physics.IgnoreCollision(this.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>());
	}
	
	void OnCollisionExit(Collision other)	{
		print(gameObject.name + " and trigger object " + other.gameObject.name + " are no longer colliding");
		Physics.IgnoreCollision(this.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), false);
		
	}
	
}
