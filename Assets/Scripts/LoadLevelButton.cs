using UnityEngine;
using System.Collections;

public class LoadLevelButton : MonoBehaviour {

	public bool quitButton = false;
	public string levelName;


	void OnMouseDown(){
		if(quitButton){
			Application.Quit();

			#if UNITY_EDITOR
				Debug.Break();
			#endif

		}
		else Application.LoadLevel (levelName);
	}
}