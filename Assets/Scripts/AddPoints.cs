using UnityEngine;
using System.Collections;

public class AddPoints : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "getCoin");
			Destroy(this.gameObject);
		}
	}
}
