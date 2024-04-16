using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	float angle = 0;
	float Rangle = 0;
	public float AngularSpeed = 1;
	public float RotationSpeed = 1;
	public float offset = 0;
	public float Roffset = 0;
	public float distance = 1;
	public Vector3 pivot = new Vector2 (0,0);
	public bool Rotation = false;
	public bool Active = false;
	public Transform RelativeTo;
    
	void Start() {
		angle = offset;
		Rangle = Roffset;
	}
	
    void Update() {
        if (Active) {
			if (RelativeTo != null) {pivot = RelativeTo.position;}
			transform.position = new Vector2 (pivot.x,pivot.y) + new Vector2 
			(Mathf.Cos(angle*2*Mathf.PI/360),Mathf.Sin(angle*2*Mathf.PI/360))*distance;
			angle += AngularSpeed;
			if (Rotation) {
				transform.eulerAngles =  new Vector3 (0,0,Rangle);
				Rangle += RotationSpeed;
			}
		}
    }
}
