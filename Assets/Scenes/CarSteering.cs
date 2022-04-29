using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering : MonoBehaviour {


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
	[SerializeField] Rigidbody2D rb2;
	// Use this for initialization
	void Start () {
		// spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		// spriteRenderer.sprite = spriteArray[1];
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// steeringAmount = - Input.GetAxis ("Horizontal");
		if (Input.GetKey(your_key3)){
			if (steeringAmount < 1){
				steeringAmount +=  0.2f;
			}
			}
		if (Input.GetKey(your_key4)){
			if (steeringAmount > -1){
				steeringAmount -= 0.2f;
			}
		}
		if (Input.GetKey(your_key)){
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
		direction = Mathf.Sign(Vector2.Dot (rb2.velocity, rb2.GetRelativeVector(Vector2.up)));
		rb2.rotation += steeringAmount * steeringPower * rb2.velocity.magnitude * direction;

		rb2.AddRelativeForce (Vector2.up * speed);

		rb2.AddRelativeForce ( - Vector2.right * rb2.velocity.magnitude * steeringAmount / 2);
	}
}