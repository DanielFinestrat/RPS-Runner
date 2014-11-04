using UnityEngine;
using System.Collections;

public class KillerObject : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "Player") NotificationCenter.DefaultCenter().PostNotification(this, "playerIsDead");
		
	}
}
