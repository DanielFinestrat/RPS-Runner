using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	void OnMouseDown(){
		NotificationCenter.DefaultCenter ().PostNotification (this, "StartRunning");
	}

}
