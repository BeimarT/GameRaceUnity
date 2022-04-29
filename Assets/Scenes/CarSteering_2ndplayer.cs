using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering_2ndplayer : MonoBehaviour {

	[SerializeField]Rigidbody2D rb;
	[SerializeField]
	float fuerzaDeAceleracion = 150f;
	[SerializeField]
	float VelocidadMaxima = 11000f;
	[SerializeField]
	float fuerzaDeDesaceleracion = 800f;
	[SerializeField]
	float steeringPower = 5f;
	float steeringAmount, speed, direction;
	[SerializeField] KeyCode your_key;
	[SerializeField] KeyCode your_key2;
	[SerializeField] KeyCode your_key3;
	[SerializeField] KeyCode your_key4;
	[SerializeField] Sprite[] spriteArray;
	[SerializeField] SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();	
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = spriteArray[PlayMainMenu.flag + 1];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(your_key3) == true || Input.GetKey(your_key4) == true){
			if (Input.GetKey(your_key4) == true){
				if (steeringAmount > -10f){
					steeringAmount = steeringAmount - 0.5f;
					Debug.Log(steeringAmount);
				}
			}
			if (Input.GetKey(your_key3) == true){			
				if (steeringAmount < 1f){
					steeringAmount = steeringAmount + 0.5f;
					Debug.Log(steeringAmount);
				}
			}
			} else {
			steeringAmount = 0f;
		}
		if (Input.GetKey(your_key) == true){
			if (speed < VelocidadMaxima){
				speed = speed +  fuerzaDeAceleracion;
			}
		} else{
			if (speed > 0){
				speed = speed - 150f;
			}
		} 
		if (Input.GetKey(your_key2)) {
			if (speed > -5000){
				speed = speed - fuerzaDeDesaceleracion;
			}
		}
		Debug.Log(steeringAmount);
		direction = Mathf.Sign(Vector2.Dot (rb.velocity, rb.GetRelativeVector(Vector2.up)));
		rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;
		steeringAmount = 0f;


		rb.AddRelativeForce (Vector2.up * speed);

		rb.AddRelativeForce ( - Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
			
	}


}