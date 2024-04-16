using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloc : MonoBehaviour {

	void Start() {
		GameObject.Find("Bola").GetComponent<Bola>().blocks += 1;
	}
}
