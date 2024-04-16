using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
	
	public int PowId = 0;
	public int FallSpeed = 3;
	
    void Update() {
        transform.position += Vector3.down*FallSpeed*Time.deltaTime;
		if (transform.position.y < -8) {Destroy(this.gameObject);}
    }
}
