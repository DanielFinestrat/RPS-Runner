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

	private Animator animator;

	void Awake(){
		animator = GetComponent<Animator> ();
		NotificationCenter.DefaultCenter().AddObserver(this, "swipeDown");
		NotificationCenter.DefaultCenter().AddObserver(this, "screenTouched");
		NotificationCenter.DefaultCenter().AddObserver(this, "StartRunning");
	}

	void StartRunning(Notification notification){
		running = true;
	}

	void FixedUpdate (){
		grounded = Physics2D.OverlapArea (OPA.position, OPB.position, ground);
		animator.SetBool ("grounded", grounded);
	}

	void Update () {

		if(running)
			rigidbody2D.velocity = new Vector2 (velocidadMovimiento, rigidbody2D.velocity.y);

		//################ PC DEBUGGING CONTROLS ################

		if(Input.GetKeyDown("up")){
			jump ();
		}
		if(Input.GetKeyDown("down")){
			slide ();
		}

		//################ PC DEBUGGING CONTROLS ################

	}

	void swipeDown(Notification notification){
		slide ();
	}

	void screenTouched(Notification notification){
		jump ();
	}

	void slide(){
		if (running && grounded) {
			slideing = true;
			animator.SetBool ("slideing", slideing);
		}
	}

	void jump(){
		if(running && !slideing){

			if (grounded)
				rigidbody2D.velocity =  new Vector2 (rigidbody2D.velocity.y, fuerzaSalto);
			else if (!grounded && allowDoubleJump)
				rigidbody2D.velocity =  new Vector2 (rigidbody2D.velocity.y, fuerzaSalto);

			if (grounded) allowDoubleJump = true;
			else allowDoubleJump = false;

		}
	}

	void stopSlideing(){
		slideing = false;
		animator.SetBool ("slideing", slideing);
	}

}