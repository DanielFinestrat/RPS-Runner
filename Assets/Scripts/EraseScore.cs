using UnityEngine;
using System.Collections;

public class EraseScore : MonoBehaviour {

	void OnMouseDown(){
		if(audio) audio.Play();
		DataShare.dataShare.highScore = 0;
		DataShare.dataShare.maxDistance = 0;
		DataShare.dataShare.Save ();
	}
}
