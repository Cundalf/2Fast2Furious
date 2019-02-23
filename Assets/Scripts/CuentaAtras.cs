using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour {
	public GameObject motorCarreteraGO;
	public GameObject controladorCocheGO;
	public GameObject cocheGO;
	public GameObject contadorNumerosGO;
	public GameObject musicaFondoGO;
	public SpriteRenderer contadorNumerosComp;
	public MotorCarreteras motorCarreteraScript;
	public Sprite[] numeros;
	public AudioSource musicaFondoAS;

	void Start () {
		InicioComponentes ();
	}

	void InicioComponentes(){
		motorCarreteraGO = GameObject.Find ("MotorCarreteras");
		motorCarreteraScript = motorCarreteraGO.GetComponent<MotorCarreteras> ();

		contadorNumerosGO = GameObject.Find ("ContadorNumeros");
		contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer> ();

		cocheGO = GameObject.Find ("Coche");
		controladorCocheGO = GameObject.Find ("ControladorCoche"); 

		musicaFondoGO = GameObject.Find ("MusicaFondo");
		musicaFondoAS = musicaFondoGO.GetComponent<AudioSource> ();

		InicioCuentaAtras ();
	}

	void InicioCuentaAtras(){
		StartCoroutine (Contando());
	}

	IEnumerator Contando(){
		controladorCocheGO.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (2);

		contadorNumerosComp.sprite = numeros [1];
		this.gameObject.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (1);

		contadorNumerosComp.sprite = numeros [2];
		this.gameObject.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (1);

		contadorNumerosComp.sprite = numeros [3];
		motorCarreteraScript.bInicioJuego = true;
		contadorNumerosGO.GetComponent<AudioSource> ().Play ();
		cocheGO.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (2);

		musicaFondoAS.Play ();

		contadorNumerosGO.SetActive (false);
	}
}
