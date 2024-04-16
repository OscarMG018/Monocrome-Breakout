using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mernu : MonoBehaviour {
	
	public GameObject Sortir;
	public GameObject Nivell;
	public GameObject OptionsB;
	public GameObject Options;
	public GameObject NivellSel;
	public GameObject tornarL;
	public GameObject tornarO;
	public GameObject Audio;
	public GameObject Sure;

	
	void Start() {
		if (LevelManager.played){
			LevelManager.played = false;
			Nivells();
		}
	}
	
	
	public void Exit() {
		Application.Quit();
		Audio.GetComponent<AudioSource>().Play(0);
	}
	
	public void Nivells() {
		Audio.GetComponent<AudioSource>().Play(0);
		Sortir.SetActive(false);
		Nivell.SetActive(false);
		OptionsB.SetActive(false);
		NivellSel.SetActive(true);
		tornarL.SetActive(true);
	}

		public void TornarL() {
		Audio.GetComponent<AudioSource>().Play(0);
		Sortir.SetActive(true);
		Nivell.SetActive(true);
		OptionsB.SetActive(true);
		NivellSel.SetActive(false);
		tornarL.SetActive(false);
	}
	
	public void Opcions() {
		Audio.GetComponent<AudioSource>().Play(0);
		Sortir.SetActive(false);
		Nivell.SetActive(false);
		OptionsB.SetActive(false);
		Options.SetActive(true);
		tornarO.SetActive(true);
	}

		public void TornarO() {
		Audio.GetComponent<AudioSource>().Play(0);
		Sortir.SetActive(true);
		Nivell.SetActive(true);
		OptionsB.SetActive(true);
		Options.SetActive(false);
		tornarO.SetActive(false);
	}
	
	public void Delete() {
		Audio.GetComponent<AudioSource>().Play(0);
		Sure.SetActive(true);
	}
	public void Yes() {
		Audio.GetComponent<AudioSource>().Play(0);
		Sure.SetActive(false);
		for (int i=0;i<15;i++){
			Level.MaxScores[i] = 0;
		}
		Level.unlockN = 1;
		SaveFile.Save();
		for (int m=1;m<4;m++){
			for (int n=1;n<6;n++){
				NivellSel.transform.Find("H Level "+ m).transform.Find("Level " +(n+5*(m-1))).GetComponent<Level>().SetUp();	
			}
		}
		
	}
	public void No() {
		Audio.GetComponent<AudioSource>().Play(0);
		Sure.SetActive(false);
	}
	
}