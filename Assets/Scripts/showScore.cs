using UnityEngine;
using System.Collections;

public class showScore : MonoBehaviour {
	
	public TextMesh HighScore;
	public TextMesh MaxDistance;
	
	void Update(){
		HighScore.text = DataShare.dataShare.highScore.ToString()+"$";
		MaxDistance.text = DataShare.dataShare.maxDistance.ToString()+"m";
	}
	
}
