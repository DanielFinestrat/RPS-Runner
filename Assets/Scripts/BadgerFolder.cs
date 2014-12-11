using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class BadgerFolder : MonoBehaviour {

	private TextMesh button;
	
	void Awake(){
		button = GetComponent<TextMesh> ();
	}

	void Update(){
		if(Social.localUser.authenticated) button.color = Color.black;
		else button.color = Color.gray;
	}

	void OnMouseDown(){
		if(audio){
			audio.Play ();
			Invoke ("loadBadger", audio.clip.length);
		}else{
			Invoke ("loadBadger", 0f);
		}
	}

	void loadBadger(){		
		if(Social.localUser.authenticated){
			Social.Active.ShowAchievementsUI();
		}
		else{
			Social.localUser.Authenticate((bool success) => {});
		}
		
	}
	
}
