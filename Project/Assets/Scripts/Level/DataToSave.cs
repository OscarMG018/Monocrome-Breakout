using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataToSave {
	 
	public int unlocks = 1;
	public float[] MaxScores = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	public float volume = 1;

	
	public DataToSave(){
		unlocks = Level.unlockN;
		MaxScores = Level.MaxScores;
		volume = Volume.Volumen;
	}
}