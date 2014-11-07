using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject[] obj;
	public float timeMin = 5f;
	public float timeMax = 5f;

	private bool dead = false;
	private bool firstTime = true;

	void Start(){
		NotificationCenter.DefaultCenter().AddObserver(this, "startRunning");
		NotificationCenter.DefaultCenter().AddObserver(this, "playerIsDead");
	}

	void startRunning(Notification notification){
		generate ();
	}

	void playerIsDead(Notification notification){
		dead = true;
	}

	void generate(){

		if (!firstTime && !dead) Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
		else firstTime = false;

		if(!dead) Invoke ("generate", Random.Range (timeMin, timeMax));
	}

}
