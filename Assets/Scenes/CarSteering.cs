using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering : MonoBehaviour {

	Rigidbody2D rb;

	[SerializeField]
	float fuerzaDeAceleracion = 150f;
	[SerializeField]
	float VelocidadMaxima = 11000f;
	[SerializeField]
	float fuerzaDeDesaceleracion = 800f;
	[SerializeField]
	float steeringPower = 5f;
	float steeringAmount, speed, direction;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		steeringAmount = - Input.GetAxis ("Horizontal");
		if (Input.GetAxis("Vertical") > 0.001){
			if (speed < VelocidadMaxima){
				speed = speed +  fuerzaDeAceleracion;
				Debug.Log(speed);
			}
		} else{
			if (speed > 0){
				speed = speed - 150f;
			}
		} 
		if (Input.GetAxis("Vertical") < -0.0001) {
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
