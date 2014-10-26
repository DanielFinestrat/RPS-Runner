using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float fuerzaSalto = 200f;

	public LayerMask ground;
	public Transform OPA, OPB;

	private bool grounded = true;
	private bool slideing = false;

	private Animator animator;

	void Awake(){
		animator = GetComponent<Animator> ();
		NotificationCenter.DefaultCenter().AddObserver(this, "swipeDown");
		NotificationCenter.DefaultCenter().AddObserver(this, "screenTouched");
	}

	void FixedUpdate (){
		grounded = Physics2D.OverlapArea (OPA.position, OPB.position, ground);
	}

	void Update () {

		//################ PC DEBUGGING CONTROLS ################

		if(Input.GetKeyDown("up") && grounded && !slideing){
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,fuerzaSalto);
		}
		if(Input.GetKeyDown("down") && grounded){
			slideing = true;
			animator.SetBool("slideing", slideing);
		}

		//################ PC DEBUGGING CONTROLS ################

	}

	void swipeDown(Notification notification){
		if(grounded)
			slideing = true;
			animator.SetBool("slideing", slideing);
	}

	void screenTouched(Notification notification){
		if(grounded && !slideing)
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,fuerzaSalto);
	}
	
	void stopSlideing(){
		slideing = false;
		animator.SetBool ("slideing", slideing);
	}

}