using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour {
	
	private bool alreadyRunning = false;
	
	void Start(){
		NotificationCenter.DefaultCenter().AddObserver(this, "swipeRight");
	}
	
	void swipeRight(Notification notification){
		if(!alreadyRunning){
			NotificationCenter.DefaultCenter ().PostNotification (this, "startRunning");
			alreadyRunning = true;
		}
	}
	
	#if UNITY_EDITOR || UNITY_STANDALONE_WIN
	void OnMouseDown(){
		if(!alreadyRunning){
			NotificationCenter.DefaultCenter().PostNotification (this, "startRunning");
			alreadyRunning = true;
		}
	}
	#endif
}