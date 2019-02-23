using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasto : MonoBehaviour {
	public GameObject motorCarreteraGO;
	public MotorCarreteras motorCarreteraScript;

	void Start(){
		motorCarreteraGO = GameObject.Find ("MotorCarreteras");
		motorCarreteraScript = motorCarreteraGO.GetComponent<MotorCarreteras> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<Coche> () != null) {
			motorCarreteraScript.ReducirVelocidad (true);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.GetComponent<Coche> () != null) {
			motorCarreteraScript.ReducirVelocidad (false);
		}
	}
}