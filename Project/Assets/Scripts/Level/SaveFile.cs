using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveFile {
	public static void Save () {
		BinaryFormatter formatter = new BinaryFormatter();
		string location = Application.persistentDataPath + "/Save.dat";
		FileStream stream = new FileStream(location, FileMode.OpenOrCreate);
		
		DataToSave data = new DataToSave();
		
		formatter.Serialize(stream, data);
		stream.Close();
	}
	
	public static DataToSave Load () {
		string location = Application.persistentDataPath +  "/Save.dat";
		if (File.Exists(location)){
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(location, FileMode.Open);
			DataToSave data = formatter.Deserialize(stream) as DataToSave;
			stream.Close();
			
			return data;
		}
		
		else {
			return null;
		}
	}
}
