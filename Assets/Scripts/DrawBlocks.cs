using UnityEngine;
using System.Collections;

public class DrawBlocks : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {

			//Plane p = new Plane (Camera.main.transform.forward, transform.position);
			//Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit ;
			if (Physics.Raycast (ray, out hit) && (hit.transform.name == "DrawingPanel" /*|| hit.transform.name == "Cube"*/)) {
				Vector3 v = hit.point;
				v.z = 0;

				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.position = v;
				cube.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
			}
			/*if (p.Raycast (r, out d)) {
			//	Debug.Log ("Raycast out " + d);

			}
			else {
				Debug.Log ("Raycast returns false");
			}*/
		} else if (Input.GetMouseButton (1)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit ;
			if (Physics.Raycast (ray, out hit) && hit.transform.name == "Cube") {
				Destroy (hit.transform.gameObject);
			}
		}

	}
}
