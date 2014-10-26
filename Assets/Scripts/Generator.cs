using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject[] obj;
	public float timeMin = 5f;
	public float timeMax = 5f;

	void Start(){
		NotificationCenter.DefaultCenter().AddObserver(this, "StartRunning");
	}

	void StartRunning(Notification notification){
		generate ();
	}

	void generate(){
		Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
		Invoke ("generate", Random.Range (timeMin, timeMax));
	}

}
