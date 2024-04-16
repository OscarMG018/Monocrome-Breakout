using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
	
	public static int unlockN = 1;
	public int LevelId;
	public static int LevelPlayed = 1;
	public static float[] MaxScores = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	public float MaxScore;
	//public static bool change = false;
	
	void Start() {
		SetUp();
	}

	void Update() {
		//if (change) {
			//SetUp();
			//change = false;
		//}
	}
	
	public void TaskOnClick () {
		StartCoroutine(LoadLevel());
	}
	
	public IEnumerator LoadLevel() {
		LevelPlayed = LevelId;
		GameObject.Find("Audio").GetComponent<AudioSource>().Play(0);
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("level");
	}
	
	public void SetUp() {
		LevelId = int.Parse(gameObject.name.Replace("Level",""));
		GetComponent<Button>().onClick.AddListener(TaskOnClick);
		
		if (SaveFile.Load() != null) {
			DataToSave data = SaveFile.Load();
			MaxScores = data.MaxScores;
			unlockN = data.unlocks;	
		}

		
		if (LevelId <= unlockN) {
			GetComponent<Button>().enabled = true;
			GetComponent<Image>().color = new Color32 (255,255,255,255);
		}
		
		else {
			GetComponent<Button>().enabled = false;
			GetComponent<Image>().color = new Color32 (140,140,140,255);
		}
		
		MaxScore = MaxScores[LevelId-1]; 
		transform.Find("PText").GetComponent<Text>().text = MaxScore +" POINTS";
	

	}

}
