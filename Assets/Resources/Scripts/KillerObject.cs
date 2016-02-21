using UnityEngine;
using System.Collections;

public class KillerObject : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Player") {
			if(audio) audio.Play ();
			NotificationCenter.DefaultCenter ().PostNotification (this, "playerIsDead");
		}
		else if(other.tag == "Points") Destroy(other.gameObject);
		
	}
}
