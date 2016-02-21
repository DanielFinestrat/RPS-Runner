using UnityEngine;
using System.Collections;

public class Wallet : MonoBehaviour {

	public TextMesh walletText;
	private GameObject DataShare;
	private DataShare datashare;

	void Awake(){
		DataShare = GameObject.Find("DataShare");
		datashare = DataShare.GetComponent<DataShare>();
	}

	void Start () {
		updateScore ();
	}
	
	void updateScore(){
		walletText.text = datashare.money.ToString ();
	}
}
