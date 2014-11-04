using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D toDestroy){

		if (this.gameObject.tag == "KillerEraser") {

			if (toDestroy.tag == "Killer") Destroy (toDestroy.gameObject);

		} else if (toDestroy.tag == "Player") {

			NotificationCenter.DefaultCenter ().PostNotification (this, "playerIsDead");

		} else
			Destroy (toDestroy.gameObject);

	}
}
