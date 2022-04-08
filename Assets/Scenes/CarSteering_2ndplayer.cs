using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering_2ndplayer : MonoBehaviour {

	[SerializeField] Rigidbody2D rb;	
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

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		steeringAmount = - Input.GetAxis ("Horizontal");
		if (Input.GetKey(your_key)){
			if (speed < VelocidadMaxima){
				speed = speed +  fuerzaDeAceleracion;
				Debug.Log(speed);
			}
		} else{
			if (speed > 0){
				speed = speed - 150f;
			}
		} 
		if (Input.GetKey(your_key2)) {
			Debug.Log("Hacia detras");
			if (speed > -5000){
				speed = speed - fuerzaDeDesaceleracion;
				Debug.Log(speed);
			}
		}
		direction = Mathf.Sign(Vector2.Dot (rb.velocity, rb.GetRelativeVector(Vector2.up)));
		rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

		rb.AddRelativeForce (Vector2.up * speed);

		rb.AddRelativeForce ( - Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
			
	}


}
