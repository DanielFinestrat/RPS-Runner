using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D toDestroy){

		if(toDestroy.tag == "Player") Debug.Break();

		else Destroy (toDestroy.gameObject);

	}

}
