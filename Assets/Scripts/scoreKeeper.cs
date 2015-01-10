using UnityEngine;
using System.Collections;

public class scoreKeeper : MonoBehaviour {

	private int key = 0;
	private int _score = 0;
	public int valorMoneda = 100;
	public TextMesh scoreBoard;


	public int score{
		get{ return _score ^ key;}
		set{
			key = Random.Range (0,int.MaxValue);
			_score = value ^ key;
		}
	}



	void Awake() {
		NotificationCenter.DefaultCenter().AddObserver(this, "getCoin");
		NotificationCenter.DefaultCenter().AddObserver(this, "playerIsDead");
		updateScore ();
	}

	void updateScore(){
		scoreBoard.text = score.ToString ();
	}

	void getCoin(Notification notification){
		score += valorMoneda;
		updateScore ();
	}

	void playerIsDead(Notification notification){
		Social.ReportScore(score, "CgkIgerN_qwBEAIQCA", (bool success) => {});
		if (score > DataShare.dataShare.highScore) {
			NotificationCenter.DefaultCenter().PostNotification(this, "newHighScore");
			DataShare.dataShare.highScore = score;
		}
	}
}
