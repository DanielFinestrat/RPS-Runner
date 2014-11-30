using UnityEngine;
using System.Collections;

public class scoreKeeper : MonoBehaviour {

	public int score = 0;
	public int valorMoneda = 100;
	public TextMesh scoreBoard;

	void Awake() {
		NotificationCenter.DefaultCenter().AddObserver(this, "getCoin");
		NotificationCenter.DefaultCenter().AddObserver(this, "playerIsDead");
		updateScore ();
	}

	void updateScore(){
		scoreBoard.text = score.ToString () + "$";
	}

	void getCoin(Notification notification){
		score += valorMoneda;
		updateScore ();
	}

	void playerIsDead(Notification notification){
		if (score > DataShare.dataShare.highScore) {
			NotificationCenter.DefaultCenter().PostNotification(this, "newHighScore");
			DataShare.dataShare.highScore = score;
		}
	}
}
