using UnityEngine;
using System.Collections;

public class ActivateDeathCamera : MonoBehaviour {
	
	public GameObject deathCamera;
	public GameObject newDistance;
	public GameObject newScore;

	public AudioSource deathAudioSource;
	public AudioClip victory;

	void Start() {
		NotificationCenter.DefaultCenter().AddObserver(this, "playerIsDead");
		NotificationCenter.DefaultCenter().AddObserver(this, "newHighScore");
		NotificationCenter.DefaultCenter().AddObserver(this, "newMaxDistance");
	}

	void playerIsDead(Notification notification){
		deathCamera.SetActive (true);
	}

	void newMaxDistance(Notification notification){
		deathAudioSource.audio.clip = victory;
		newDistance.SetActive (true);
	}

	void newHighScore(Notification notification){
		deathAudioSource.audio.clip = victory;
		newScore.SetActive (true);
	}

}
