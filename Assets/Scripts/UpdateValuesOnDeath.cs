using UnityEngine;
using System.Collections;

public class UpdateValuesOnDeath : MonoBehaviour {

	public TextMesh Score;
	public TextMesh HighScore;

	public scoreKeeper scoreKeeper;

	void OnEnable(){
		DataShare.dataShare.Save();
		Score.text = scoreKeeper.score.ToString();
		HighScore.text = DataShare.dataShare.highScore.ToString();
	}

}
