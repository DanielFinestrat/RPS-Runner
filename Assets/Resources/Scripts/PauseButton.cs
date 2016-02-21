using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	public bool paused = false;
	private bool running = false;
	public TouchControl touchControl;
	public Sprite spritePause;
	public Sprite spritePlay;

	void Awake(){
		NotificationCenter.DefaultCenter().AddObserver(this, "startRunning");
		NotificationCenter.DefaultCenter().AddObserver(this, "playerIsDead");
	}
		
	void OnMouseDown(){
		if (running) {
			if (!paused) {	
				paused = true;
				Time.timeScale = 0;
				touchControl.enabled = false;
				GetComponent<SpriteRenderer> ().sprite = spritePlay;

			} else {
				paused = false;
				Time.timeScale = 1;
				GetComponent<SpriteRenderer> ().sprite = spritePause;
			}
		}
	}

	void OnMouseUp(){
		if (running) {	
			if (!paused) {
				touchControl.enabled = true;
			}
		}
	}

	void startRunning(Notification notification){
		running = true;
	}
	void playerIsDead(Notification notification){
		running = false;
	}
}
