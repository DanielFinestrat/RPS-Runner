using UnityEngine;
using System.Collections;

public class scoreKeeper : MonoBehaviour {

	public int score = 0;
	public int valorMoneda = 100;
	public TextMesh scoreBoard;

	void Awake() {
		NotificationCenter.DefaultCenter().AddObserver(this, "getCoin");
		updateScore ();
	}

	void updateScore(){
		scoreBoard.text = score.ToString ();
	}

	void getCoin(Notification notification){
		score += valorMoneda;
		updateScore ();
	}

}
