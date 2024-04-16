using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
	public static float vides = 5;
	public static bool played = false;
	public static float Points = 0; 
	public static float Chain = 0; 
	public static int Combo = 1;
	public static float time = 0;
	public GameObject restart;
	
	public void Restart() {
		if (GameObject.Find("Bola").GetComponent<Bola>().moving == false){
			SceneManager.LoadScene("Menu");
		}
		else {GameObject.Find("Bola").GetComponent<Bola>().moving = false;}
	}
	
	
	void Start()  {
		
		transform.Find("Nivell" + Level.LevelPlayed).gameObject.SetActive(true);
		vides = 5;
		Points = 0;
		Chain = 0;
		Combo = 1;
		time = 0;
	}
	
	void Update() {
		restart.SetActive(false);
		if (GameObject.Find("Bola").GetComponent<Bola>().moving == false){restart.SetActive(true);}
		if (Vector3.Angle(Vector3.right,GameObject.Find("Bola").GetComponent<Rigidbody2D>().velocity) < 2 && Vector3.Angle(Vector3.right,GameObject.Find("Bola").GetComponent<Rigidbody2D>().velocity) > -2){restart.SetActive(true);}
		if (Vector3.Angle(Vector3.right,GameObject.Find("Bola").GetComponent<Rigidbody2D>().velocity) < 182 && Vector3.Angle(Vector3.right,GameObject.Find("Bola").GetComponent<Rigidbody2D>().velocity) > 178){restart.SetActive(true);}
		if (time < -25){restart.SetActive(true);}

		time -= Time.deltaTime;
		
		if (time <= 0) {
			Chain = 0;
		}
		
		if (Chain >= 5) {
			Combo += 1;
			Chain = 0;
		}
		
		
		
		GameObject.Find("VidesFill").GetComponent<Image>().fillAmount = vides/5;
		GameObject.Find("Points").GetComponent<Text>().text = Points + " Points";
		GameObject.Find("Chain").GetComponent<Text>().text = Chain +"   Chain";
		GameObject.Find("Combo").GetComponent<Text>().text = Combo +"   Combo";
		GameObject.Find("ComboBar").GetComponent<Image>().fillAmount = Chain/5;
		GameObject.Find("ChainBar").GetComponent<Image>().fillAmount = time/5;
		
		
		//Perdre
		
		if (vides == 0) {
			SceneManager.LoadScene("Menu");
			played = true;
		}
	}
	
	void LateUpdate() {
		
		//Guanyar
		
		if (GameObject.Find("Bola").GetComponent<Bola>().blocks == 0){
			if (Level.LevelPlayed == Level.unlockN) {Level.unlockN += 1;}
			if (Points > Level.MaxScores[Level.LevelPlayed-1]) {Level.MaxScores[Level.LevelPlayed-1] = Points;}
			SaveFile.Save();
			SceneManager.LoadScene("Menu");
			played = true;
		}

	}
	
	public static void BlockDestroyed () {
		Points += 100 * (Chain+1) * Combo * Bar.DoublePoints;
		Chain += 1;
		time = 5;
	}
	
	public static void Morir() {
		vides -= 1;
		Chain = 0;
		Combo = 1;
		time = 0;
	}
	
}
