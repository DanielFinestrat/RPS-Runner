using UnityEngine;
using System.Collections;

public class DistanceCounter : MonoBehaviour {

	public Transform player;
	public int distance = 0;
	public int scale = 1;
	public TextMesh distanceBoard;

	private bool counting = true;

	void Awake(){
		NotificationCenter.DefaultCenter().AddObserver(this, "playerIsDead");
	}

	void Update(){
		if(counting){
			distance = (int)(player.transform.position.x - this.transform.position.x)/scale;
			distanceBoard.text = distance.ToString () + " m";
		}
	}

	void playerIsDead(Notification notification){
		counting = false;
		if (distance > DataShare.dataShare.maxDistance) {
			NotificationCenter.DefaultCenter().PostNotification(this, "newMaxDistance");
			DataShare.dataShare.maxDistance = distance;
		}
	}

}
