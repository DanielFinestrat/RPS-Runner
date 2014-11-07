using UnityEngine;
using System.Collections;

public class DataShare : MonoBehaviour {

	public static DataShare dataShare;

	void Awake () {
		if (dataShare == null){
			dataShare = this;
			DontDestroyOnLoad(gameObject);
		}else if(dataShare !=this){
			Destroy(gameObject);
		}
	}

}
