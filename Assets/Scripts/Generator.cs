using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject[] obj;
	public float timeMin = 5f;
	public float timeMax = 5f;

	private bool firstTime = true;

	void Start(){
		NotificationCenter.DefaultCenter().AddObserver(this, "startRunning");
	}

	void startRunning(Notification notification){
		generate ();
	}

	void generate(){

		if (!firstTime) Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
		else firstTime = false;

		Invoke ("generate", Random.Range (timeMin, timeMax));
	}

}
