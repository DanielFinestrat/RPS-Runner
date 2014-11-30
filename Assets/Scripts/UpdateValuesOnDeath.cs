using UnityEngine;
using System.Collections;

public class UpdateValuesOnDeath : MonoBehaviour {

	public TextMesh Score;
	public TextMesh HighScore;

	public TextMesh Distance;
	public TextMesh MaxDistance;

	public scoreKeeper scoreKeeper;
	public DistanceCounter distanceCounter;

	void OnEnable(){
		DataShare.dataShare.Save();
		Score.text = scoreKeeper.score.ToString()+"$";
		Distance.text = distanceCounter.distance.ToString()+"m";
		HighScore.text = DataShare.dataShare.highScore.ToString()+"$";
		MaxDistance.text = DataShare.dataShare.maxDistance.ToString()+"m";
	}

}
