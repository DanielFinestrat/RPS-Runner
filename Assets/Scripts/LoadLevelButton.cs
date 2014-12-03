using UnityEngine;
using System.Collections;

public class LoadLevelButton : MonoBehaviour {

	public bool quitButton = false;
	public string levelName;


	void OnMouseDown(){

		//Camera.main.audio.Stop();
		if(audio){
			audio.Play ();
			Invoke ("loadLevel", audio.clip.length);
		}else{
			Invoke ("loadLevel", 0f);
		}

	}

	void loadLevel(){

		if(quitButton){
			Application.Quit();

			#if UNITY_EDITOR
				Debug.Break();
			#endif

		}
		else Application.LoadLevel (levelName);

	}
}