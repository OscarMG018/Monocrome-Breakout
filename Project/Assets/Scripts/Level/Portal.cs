using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
	
	public Transform Conecxió;
	public Color32 color = new Color32 (255,255,255,255);
	
	void Start() {
		GetComponent<SpriteRenderer>().color = color;
	}
}
