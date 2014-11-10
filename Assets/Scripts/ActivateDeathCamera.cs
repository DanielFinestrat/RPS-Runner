using UnityEngine;
using System.Collections;

public class ActivateDeathCamera : MonoBehaviour {
	
	public GameObject deathCamera;

	void Start() {
		NotificationCenter.DefaultCenter().AddObserver(this, "playerIsDead");
	}

	void playerIsDead(Notification notification){
		deathCamera.SetActive (true);
	}

}
