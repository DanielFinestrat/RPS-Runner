using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float fuerzaSalto = 200f;
	public float velocidadMovimiento = 200f;

	public LayerMask ground;
	public Transform OPA, OPB;

	private bool grounded = true;
	private bool slideing = false;
	private bool running = false;
	private bool allowDoubleJump = true;
	private bool dead = false;

	public AudioClip jumpSound;
	public AudioClip slideSound;
	
	
	private Animator animator;

	void Awake(){
		animator = GetComponent<Animator> ();
		NotificationCenter.DefaultCenter().AddObserver(this, "swipeDown");
		NotificationCenter.DefaultCenter().AddObserver(this, "swipeUp");
		NotificationCenter.DefaultCenter().AddObserver(this, "screenTouched");
		NotificationCenter.DefaultCenter().AddObserver(this, "startRunning");
		NotificationCenter.DefaultCenter().AddObserver(this, "playerIsDead");
	}

	//###################################### UPDATES ######################################

	void FixedUpdate (){
		grounded = Physics2D.OverlapArea (OPA.position, OPB.position, ground);
		animator.SetBool ("grounded", grounded);
	}

	void Update () {

		if(running)
			rigidbody2D.velocity = new Vector2 (velocidadMovimiento, rigidbody2D.velocity.y);

		#if UNITY_EDITOR || UNITY_STANDALONE_WIN
		if(Input.GetKeyDown("up")){
			jump ();
		}
		if(Input.GetKeyDown("down")){
			slide ();
		}
		#endif

	}

	//###################################### ACTIONS ######################################

	void slide(){
		if (running && grounded) {
			slideing = true;
			animator.SetBool ("slideing", slideing);
			audio.clip = slideSound;
			if(audio) audio.Play ();
		}
	}

	void jump(){
		if(running && !slideing){

			if (grounded){
				rigidbody2D.velocity =  new Vector2 (rigidbody2D.velocity.y, fuerzaSalto);
				audio.clip = jumpSound;
				if(audio) audio.Play ();
			}
			else if (!grounded && allowDoubleJump){
				rigidbody2D.velocity =  new Vector2 (rigidbody2D.velocity.y, fuerzaSalto);
				if(audio) audio.Play ();
			}

			if (grounded) allowDoubleJump = true;
			else allowDoubleJump = false;

		}
	}

	void stopSlideing(){
		slideing = false;
		animator.SetBool ("slideing", slideing);
	}

	void SetPlayerUnactive(){
		this.gameObject.SetActive (false);
	}

	//###################################### NOTIFICATIONS ######################################

	void swipeDown(Notification notification){
		slide ();
	}
	
	void screenTouched(Notification notification){
		jump ();
	}

	void swipeUp(Notification notification){
		jump ();
	}
	void playerIsDead(Notification notification){
		running = false;
		dead = true;
		animator.SetBool ("dead", dead);
	}
	
	void startRunning(Notification notification){
		running = true;
		GetComponent<TouchControl>().enabled = true;
		animator.SetBool ("running", running);
	}

}