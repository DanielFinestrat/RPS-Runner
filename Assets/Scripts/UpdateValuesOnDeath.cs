using UnityEngine;
using System.Collections;

public class UpdateValuesOnDeath : MonoBehaviour {

	public TextMesh Score;
	public TextMesh HighScore;

	public scoreKeeper scoreKeeper;

	void OnEnable(){
		Score.text = scoreKeeper.score.ToString();
		HighScore.text = DataShare.dataShare.highScore.ToString();
	}

}
