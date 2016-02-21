using UnityEngine;
using System.Collections;

public class StartFade : MonoBehaviour {
	
	public Color TextColor = Color.black;
	private bool running = false;
	private Animator PuntuacionPiedraAnimator;
	private Animator PauseButtonAnimator;
	public GameObject PuntuacionPiedra;
	public GameObject PauseButton;

	void Awake(){
		PuntuacionPiedraAnimator = PuntuacionPiedra.GetComponent<Animator> ();
		PauseButtonAnimator = PauseButton.GetComponent<Animator> ();
	}

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
		PuntuacionPiedraAnimator.SetBool ("empezar", running);
		PauseButtonAnimator.SetBool ("empezar", running);
	}

}