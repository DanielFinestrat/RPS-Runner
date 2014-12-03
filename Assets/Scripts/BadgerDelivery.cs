using UnityEngine;
using System.Collections;

public class BadgerDelivery : MonoBehaviour {

	public DistanceCounter distanceCounter;

	void Start(){
		NotificationCenter.DefaultCenter().AddObserver(this, "playerIsDead");
	}


	void playerIsDead(Notification notification){
		if(distanceCounter.distance>=75)Social.ReportProgress("CgkIgerN_qwBEAIQAw", 100.0, (bool success) => {});
		if(distanceCounter.distance>=120)Social.ReportProgress("CgkIgerN_qwBEAIQBA", 100.0, (bool success) => {});
		if(distanceCounter.distance>=200)Social.ReportProgress("CgkIgerN_qwBEAIQBQ", 100.0, (bool success) => {});
		if(distanceCounter.distance>=350)Social.ReportProgress("CgkIgerN_qwBEAIQBg", 100.0, (bool success) => {});
		if(distanceCounter.distance>=700)Social.ReportProgress("CgkIgerN_qwBEAIQBw", 100.0, (bool success) => {});
	}
}
