using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;
	public Vector3 moveMask = new Vector3(1,0,0);
	public bool goingBack = true;
	
	void Update () {
		Vector3 position = this.transform.position;

		if (moveMask.y > 0 ) {
			if (goingBack)	position.y = player.transform.position.y;
			else position.y = Mathf.Max(position.y, player.transform.position.y);
		}
		if (moveMask.x > 0 ) {
			if (goingBack)	position.x = player.transform.position.x;
			else position.x = Mathf.Max(position.x, player.transform.position.x);
		}
		this.transform.position = position;
	}

}
