using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour {
	public GameObject MotorCarreterasGO;
	public MotorCarreteras MotorCarreterasScript;

	public float tiempo;
	public float distancia;
	public int iArrestos;
	public Text txtTiempo;
	public Text txtDistancia;
	public Text txtDistanciaFinal;
	public Text txtArrestos;

	void Start () {
		MotorCarreterasGO = GameObject.Find ("MotorCarreteras");
		MotorCarreterasScript = MotorCarreterasGO.GetComponent<MotorCarreteras> ();

		txtTiempo.text = "2:30";
		txtDistancia.text = "0";

		tiempo = 150;
	}

	void CalculoTiempoDistancia(){
		distancia += Time.deltaTime * MotorCarreterasScript.fVelocidad;
		txtDistancia.text = ((int)distancia).ToString ();

		tiempo -= Time.deltaTime;
		int minutos = (int)tiempo / 60;
		int segundos = (int)tiempo % 60;
		txtTiempo.text = minutos.ToString () + ":" + segundos.ToString ().PadLeft (2, '0');
	}

	void CambioDeColor(){
		if (this.tiempo > 5 && this.tiempo < 20) {
			txtTiempo.color = new Color32(255, 255, 0, 255);		
		} else if (this.tiempo < 5) {
			txtTiempo.color = new Color32(255, 0, 0, 255);
		} else {
			txtTiempo.color = new Color32(255, 255, 255, 255);
		}
	}

	public void setArresto(){
		this.iArrestos += 1;
		txtArrestos.text = iArrestos.ToString ();

		switch(this.iArrestos) {
			case 1:
				txtArrestos.color = new Color32 (255, 255, 0, 255);		
				break;
			case 2:
				txtArrestos.color = new Color32 (255, 0, 0, 255);
				break;
			case 3:
				txtArrestos.color = new Color32 (255, 0, 0, 255);
				break;
			default:
				txtArrestos.color = new Color32 (255, 255, 255, 255);
				break;
		}
	}

	void Update () {
		if (MotorCarreterasScript.bInicioJuego && !MotorCarreterasScript.bJuegoTerminado) {
			CalculoTiempoDistancia ();
			CambioDeColor ();

			//if (tiempo <= 0 && !MotorCarreterasScript.bJuegoTerminado) {
			if (tiempo <= 0 || iArrestos >= 3) {
				MotorCarreterasScript.bJuegoTerminado = true;

				txtTiempo.gameObject.SetActive (false);
				txtDistancia.gameObject.SetActive(false);

				MotorCarreterasScript.JuegoTerminadoEstados ();
				txtDistanciaFinal.text = ((int)distancia).ToString() + " mts";
			}
		}
	}
}
