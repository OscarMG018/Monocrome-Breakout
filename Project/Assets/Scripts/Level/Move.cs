using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public Vector2[] Positions = 
	{new Vector2(0,0),new Vector2(0,0)};
	int index = 0;
	float interpolations = 0;
	public float speed = 0.5f;
	public bool Active;
	
	void Start() {
		if (Active) {
			interpolations = 0;
			transform.position = Positions[0];
			index = 0;
		}
	}
	
	
	 void Update() {
		if (Active) {
			if (interpolations >= 1) {
				transform.position = Positions[index+1];
				index +=1;
				interpolations = 0;
				
				if (index > Positions.Length-2) {
					index = 0;
				}
			}
			transform.position = transform.position + new Vector3 ((Positions[index+1].x-
			Positions[index].x)*speed,(Positions[index+1].y-Positions[index].y)*speed,0);
			interpolations += speed;
		}
	}
}
