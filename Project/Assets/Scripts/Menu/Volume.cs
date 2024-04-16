using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {
   
   public static float Volumen = 1;
   public float initialVolumen = 1;
   
	void Awake() {
		if (GetComponent<AudioSource>() != null){
			initialVolumen = GetComponent<AudioSource>().volume;
		}
		
		if (GetComponent<Slider>() != null && SaveFile.Load() != null){
			GetComponent<Slider>().value = SaveFile.Load().volume;
		}
	}
	
    void Update() {
               if (GetComponent<Slider>() != null){
				   if(Volumen != SaveFile.Load().volume) {SaveFile.Save();}
				   Volumen = GetComponent<Slider>().value;
				   transform.Find("Text").GetComponent<Text>().text = "Volume " + Mathf.Round(Volumen * 100) + "%";
				}
               if (GetComponent<AudioSource>() != null){
				   GetComponent<AudioSource>().volume = initialVolumen*Volumen;
			   }
    }
		
}
