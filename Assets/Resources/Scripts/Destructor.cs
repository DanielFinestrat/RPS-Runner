using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D toDestroy){

		if(toDestroy.gameObject.tag != "Button"){

			if(this.gameObject.tag == "EndDestructor" && toDestroy.gameObject.tag == "Points"){
				Destroy (toDestroy.gameObject);
			}

			if (this.gameObject.tag == "KillerEraser") {
				if (toDestroy.tag == "Killer" || toDestroy.tag == "pointsarray") Destroy (toDestroy.gameObject);
			}

			else{ 
				Destroy (toDestroy.gameObject);
			}
		}
	}
}
