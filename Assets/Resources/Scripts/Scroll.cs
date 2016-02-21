using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float speed = 0.01f;
	public bool isConditionated = false;
	private bool isRunning = false;
	private float StartTime = 0f;

	void Start(){
		NotificationCenter.DefaultCenter().AddObserver(this, "startRunning");
		NotificationCenter.DefaultCenter().AddObserver(this, "playerIsDead");
	}

	void Update () {
		if (!isConditionated || (isConditionated && isRunning))
			renderer.material.mainTextureOffset = new Vector2 (((Time.time-StartTime) * speed)%1, 0);
	}

	void startRunning(Notification notification){
		StartTime = Time.time;
		isRunning = true;
	}
	void playerIsDead(Notification notification){
		isRunning = false;
	}
}
