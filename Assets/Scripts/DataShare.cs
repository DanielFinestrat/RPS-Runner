using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataShare : MonoBehaviour {

	public static DataShare dataShare;
	public int maxScore = 0;
	private string route;

	void Awake () {

		route = Application.persistentDataPath + "/data.dat";

		if (dataShare == null){
			dataShare = this;
			DontDestroyOnLoad(gameObject);
		}else if(dataShare !=this){
			Destroy(gameObject);
		}
	}

	void Start(){
		Load();
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(route);
		
		toSave datos = new toSave();
		datos.maxScore = maxScore;
		
		bf.Serialize(file, datos);
		
		file.Close();
	}
	
	void Load(){
		if(File.Exists(route)){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(route, FileMode.Open);
			
			toSave datos = (toSave) bf.Deserialize(file);
			
			maxScore = datos.maxScore;
			
			file.Close();
		}else{
			maxScore = 0;
		}
	}

}

[Serializable]
class toSave{
	public int maxScore;
}