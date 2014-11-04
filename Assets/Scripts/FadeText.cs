using UnityEngine;
using System.Collections;

public class FadeText : MonoBehaviour {
	
	public Color TextColor = Color.black;
	private bool running = false;

	void Start(){ 
		gameObject.renderer.material.color = TextColor;
		NotificationCenter.DefaultCenter().AddObserver(this, "startRunning");
	}


	void Update (){ 
		if (running && TextColor.a < 0.7f) {
			TextColor.a = TextColor.a + 0.01f; 
			gameObject.renderer.material.color = TextColor;
		}
	}

	void startRunning(Notification notification){
		running = true;
	}

}