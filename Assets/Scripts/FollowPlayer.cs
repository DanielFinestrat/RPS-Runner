using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform Player;
	public float distance = 5f;

	void Update () {
		transform.position = new Vector3 (Player.transform.position.x + distance, transform.position.y, transform.position.z); 
	}
}
