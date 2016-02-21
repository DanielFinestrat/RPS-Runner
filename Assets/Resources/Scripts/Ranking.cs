using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class Ranking : MonoBehaviour {

	private TextMesh button;
	public bool white;

	void Awake(){
		button = GetComponent<TextMesh> ();
	}

	void Update(){
		if(Social.localUser.authenticated && white) button.color = Color.white;
		else if (Social.localUser.authenticated) button.color = Color.black;
		else button.color = Color.gray;
	}

	void OnMouseDown(){

		if(audio){
			audio.Play ();
			Invoke ("loadRanking", audio.clip.length);
		}else{
			Invoke ("loadRanking", 0f);
		}
	}

	void loadRanking(){

		if(Social.localUser.authenticated)	((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkIgerN_qwBEAIQCA");

		else 	Social.localUser.Authenticate((bool success) => {});
	}

}
