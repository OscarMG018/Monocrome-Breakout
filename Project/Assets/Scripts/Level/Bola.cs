using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bola : MonoBehaviour {

	public Vector2 Speed = new Vector2(0,0);
	Rigidbody2D rigidbody;
	public float speed = 1;
	public float angle = 0;
	public bool moving = false;
	public Transform Barra;
	public bool blanc = true;
	public int blocks = 0;
	public float distance = 0.1f;
	public static int balls = 0;

	void Start() {
		rigidbody = GetComponent<Rigidbody2D>();
	}

		
	void Update () {
		
		//Llençar la pilota
		
		if ((Input.GetMouseButtonDown(1) || Input.GetKeyDown (KeyCode.RightControl)) && moving == false) {
			moving = true;
			angle = Random.Range(60,120);
			Speed = new Vector2 (speed*Mathf.Cos(angle*2*Mathf.PI/360),speed*Mathf.Sin(angle*2*Mathf.PI/360));
			rigidbody.velocity = Speed*speed;
		}
		if (moving) {

			//Moviment
			
			rigidbody.velocity = rigidbody.velocity.normalized*speed;
			Speed = rigidbody.velocity;
			
			//Vores de la pantalla
	
			if (GetComponent<Transform>().position.x < -6.5) {
				GameObject.Find("Sound3").GetComponent<AudioSource>().Play(0);
				rigidbody.velocity = Vector2.Reflect(Speed, new Vector2(1,0)); 
				GetComponent<Transform>().position = new Vector3 (-6.5f,GetComponent<Transform>().position.y,0);
			}
			
			if (GetComponent<Transform>().position.x > 6.5) {
				GameObject.Find("Sound3").GetComponent<AudioSource>().Play(0);
				rigidbody.velocity = Vector2.Reflect(Speed, new Vector2(-1,0)); 
				GetComponent<Transform>().position = new Vector3 (6.5f,GetComponent<Transform>().position.y,0);
			}
			
			if (GetComponent<Transform>().position.y > 4.85) {
				GameObject.Find("Sound3").GetComponent<AudioSource>().Play(0);
				rigidbody.velocity = Vector2.Reflect(Speed, new Vector2(0,-1)); 
				GetComponent<Transform>().position = new Vector3 (GetComponent<Transform>().position.x,4.85f,0);
			}
			
			if (GetComponent<Transform>().position.y < -4.85) {
				GameObject.Find("Sound4").GetComponent<AudioSource>().Play(0);
				moving = false;
				LevelManager.Morir();
			}
			
		}
		
		else {
			
			//Fer que la pilota estigui al mateix lloc que la barra
			
			GetComponent<Transform>().position = Barra.position + new Vector3 (0,0.1f,0);
			blanc = GameObject.Find("Barra").GetComponent<Bar>().blanc;
		
		}
		
		//Cambiar el color
		
		if (blanc) {
				GetComponent<SpriteRenderer>().color = new Color32 (255,255,255,255);
			}
		else {
				GetComponent<SpriteRenderer>().color = new Color32 (0,0,0,255);
			}
			
		//Ignorar la colisió amb la barra si no és del mateix color
		
		Physics2D.IgnoreCollision(GameObject.Find("Barra").GetComponent<BoxCollider2D>(),
		GetComponent<Collider2D>(),blanc != GameObject.Find("Barra").GetComponent<Bar>().blanc);
	}
	
	private void OnCollisionEnter2D(Collision2D other) {
		
		//Colisions amb físiques 
		
		rigidbody.velocity = Vector2.Reflect(Speed,other.GetContact(0).normal);
		
		if(other.gameObject.name == "Barra") {
			if (blanc != GameObject.Find("Barra").GetComponent<Bar>().blanc) {
				if (Input.GetKey(KeyCode.RightArrow)) {
					rigidbody.velocity += new Vector2((GameObject.Find("Barra").GetComponent<Bar>().speed - Speed.x)/10,0);
					}
				if (Input.GetKey(KeyCode.LeftArrow)) {
					rigidbody.velocity -=  new Vector2((GameObject.Find("Barra").GetComponent<Bar>().speed - Speed.x)/10,0);
					}
				if (moving != false)GameObject.Find("Sound3").GetComponent<AudioSource>().Play(0);
			}
		}
		if (other.gameObject.tag == "BlocBlanc") {
			if (blanc == true) {
				int r = Random.Range(0,3);
				if ( r == 1) {
					GameObject clone;
					int Id = Random.Range(2,6);
					if (Id != 5) {
						clone = Instantiate (Resources.Load<GameObject>("POW"+Id),other.transform.position,other.transform.rotation);
						clone.GetComponent<PowerUps>().PowId = Id;
					}
					
					else {
						int R = Random.Range(0,3);
						if ( R == 1) {
							clone = Instantiate (Resources.Load<GameObject>("POW"+Id),other.transform.position, new Quaternion (0,0,0,0));
							clone.GetComponent<PowerUps>().PowId = Id;
						}
					}
				}
				Destroy(other.gameObject);
				blocks -= 1;
				LevelManager.BlockDestroyed();
				GameObject.Find("Sound1").GetComponent<AudioSource>().Play(0);
			}
			else {GameObject.Find("Sound2").GetComponent<AudioSource>().Play(0);}
		}
		
		if (other.gameObject.tag == "BlocNegre") {
			if (blanc == false) {
				int r = Random.Range(0,3);
				if ( r == 1) {
					GameObject clone;
					int Id = Random.Range(2,6);
					if (Id != 5) {
						clone = Instantiate (Resources.Load<GameObject>("POW"+Id),other.transform.position,other.transform.rotation);
						clone.GetComponent<PowerUps>().PowId = Id;
					}
					
					else {
						int R = Random.Range(0,3);
						if ( R == 1) {
							clone = Instantiate (Resources.Load<GameObject>("POW"+Id),other.transform.position, new Quaternion (0,0,0,0));
							clone.GetComponent<PowerUps>().PowId = Id;
							clone.GetComponent<PowerUps>().FallSpeed = 5;
						}
					}
				}
				Destroy(other.gameObject);
				blocks -= 1;
				LevelManager.BlockDestroyed();
				GameObject.Find("Sound1").GetComponent<AudioSource>().Play(0);
			}
			else {GameObject.Find("Sound2").GetComponent<AudioSource>().Play(0);}
		}
	}
	private void OnTriggerEnter2D(Collider2D other) {
		
		//Colisions sense físiques al primer contacte
		
		if (other.gameObject.tag == "Portal") {
			if (Vector2.Distance(transform.position, other.transform.position) > distance 
			&& other.gameObject.GetComponent<Portal>().Conecxió != null ) {
				transform.position = other.gameObject.GetComponent<Portal>().Conecxió.position;
				
			}
		}
	}
	
	private void OnTriggerStay2D(Collider2D other) {
		
		//Colisions sense físiques sempre
		
		if (other.gameObject.tag == "Blanc") {	
			blanc = true;
		}
		
		if (other.gameObject.tag == "Negre") {
			blanc = false;
		}
	}
}
