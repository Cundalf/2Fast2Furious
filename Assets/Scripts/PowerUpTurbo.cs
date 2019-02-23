using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTurbo : MonoBehaviour {

	public GameObject motorCarreteraGO;
	public MotorCarreteras motorCarreteraScript;
	public GameObject audioFXGO;
	public AudioFX audioFXScript;

	void Start(){
		motorCarreteraGO = GameObject.Find("MotorCarreteras");
		motorCarreteraScript = motorCarreteraGO.GetComponent<MotorCarreteras> ();

		audioFXGO = GameObject.FindObjectOfType<AudioFX> ().gameObject;
		audioFXScript = audioFXGO.GetComponent<AudioFX> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<Coche> () != null) {
			audioFXScript.FXSonidoTurbo ();
			motorCarreteraScript.ActivaTurbo();
			Destroy (this.gameObject);
		}
	}
}
