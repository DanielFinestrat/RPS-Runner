using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float fuerzaSalto = 200f;
	private bool grounded = true;
	public LayerMask ground;
	public Transform OPA, OPB;

	void Start () {
	
	}

	void Update () {
		if(Input.GetMouseButton(0) && grounded){
			rigidbody2D.AddForce(new Vector2(0,fuerzaSalto));
		}
	}

	void FixedUpdate (){
		grounded = Physics2D.OverlapArea (OPA.position, OPB.position, ground);
	}

}
