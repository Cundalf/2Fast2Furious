using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour {

	public GameObject cronometroGO;
	public Cronometro cronometroScript;
	public GameObject audioFXGO;
	public AudioFX audioFXScript;
	public int iTiempo;

	void Start(){
		cronometroGO = GameObject.FindObjectOfType<Cronometro> ().gameObject;
		cronometroScript = cronometroGO.GetComponent<Cronometro> ();

		audioFXGO = GameObject.FindObjectOfType<AudioFX> ().gameObject;
		audioFXScript = audioFXGO.GetComponent<AudioFX> ();

		switch (gameObject.tag) {
			case "Ambulancia":
				iTiempo = 20;
				break;
			case "Bus":
				iTiempo = 15;
				break;
			case "Taxi":
				iTiempo = 10;
				break;
			case "Deportivo":
				iTiempo = 5;
				break;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<Coche> () != null) {
			audioFXScript.FXSonidoChoque ();
			cronometroScript.tiempo = cronometroScript.tiempo - iTiempo;
			Destroy (this.gameObject);
		}
	}
}
