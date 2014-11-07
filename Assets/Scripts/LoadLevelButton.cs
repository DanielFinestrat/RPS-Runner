using UnityEngine;
using System.Collections;

public class LoadLevelButton : MonoBehaviour {

	public string levelName;

	void OnMouseDown(){
		Application.LoadLevel (levelName);
	}
}