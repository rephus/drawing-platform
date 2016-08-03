using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Coin : MonoBehaviour {

	public static int count = 0;

	private Text text ;
	
	void Start() {
		text = (Text) GameObject.Find("CoinsCounterUI").GetComponent<Text>();
		count = 0; //Force static variable to 0 when game restarts, remove this line if want to keep it
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.name == "Player" ) {
			count++;
			
			text.text = count.ToString();
			Destroy (this.gameObject);
		}
	}

}
