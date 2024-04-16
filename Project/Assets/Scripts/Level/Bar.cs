using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour {

	public float speed = 5;
	public bool blanc = true;
	public static int DoublePoints = 1;

	void Update() {
		
		if (Input.GetKey(KeyCode.RightArrow)){GetComponent<Transform>().Translate(new Vector3 (speed,0,0)*Time.deltaTime);}
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)){
			if (blanc) {blanc = false;} 
			else {blanc = true;}
			}
		if (Input.GetKey(KeyCode.LeftArrow)){GetComponent<Transform>().Translate(new Vector3 (speed*-1,0,0)*Time.deltaTime);}
		if (GetComponent<Transform>().position.x >= 5.65) {GetComponent<Transform>().position = new Vector3 (5.65f,-4,0);}
		if (GetComponent<Transform>().position.x <= -5.65) {GetComponent<Transform>().position = new Vector3 (-5.65f,-4,0);}
		
 	     	if (blanc) {
			GetComponent<SpriteRenderer>().color = new Color32 (255,255,255,255);
		}
		else {
			GetComponent<SpriteRenderer>().color = new Color32 (0,0,0,255);
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "PowerUp"){
			StartCoroutine(PowerUps(other.gameObject.GetComponent<PowerUps>().PowId));
			Destroy(other.gameObject);
		}
	}
	
	IEnumerator PowerUps(int ID) {
		if (ID == 2){
			transform.localScale = new Vector3 (3,0.2f,0);
			yield return new WaitForSeconds (10f);
			transform.localScale = new Vector3 (2,0.2f,0);
		}
		
		if (ID == 3){
			transform.localScale = new Vector3 (1.5f,0.2f,0);
			yield return new WaitForSeconds (10f);
			transform.localScale = new Vector3 (2,0.2f,0);
		}
		
		if (ID == 4){
			DoublePoints = 2;
			GameObject.Find ("Points").GetComponent<Text>().color = new Color32 (255,220,0,255);
			yield return new WaitForSeconds (10f);
			DoublePoints = 1;
			GameObject.Find ("Points").GetComponent<Text>().color = new Color32 (255,255,255,255);
		}
		
		if (ID == 5){
			if(LevelManager.vides != 5){LevelManager.vides += 1;}
			yield return null;
		}
		
	}


}
