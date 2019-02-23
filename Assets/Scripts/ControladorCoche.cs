using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour {
	public GameObject cocheGO;
	public GameObject MotorCarreterasGO;
	public GameObject mCamGO;
	public MotorCarreteras MotorCarreterasScript;
	public Camera mCamComp;
	public float anguloDeGiro;
	public float velocidad;

	// false = android; true = PC
	bool bEnPC = false;
	float fGiro;
	float fLimiteI;
	float fLimiteD;
	int iHabGiro;
	Vector3 LimitePantalla;

	void Start () {
		cocheGO = GameObject.FindObjectOfType<Coche> ().gameObject;
		MotorCarreterasGO = GameObject.Find ("MotorCarreteras");
		MotorCarreterasScript = MotorCarreterasGO.GetComponent<MotorCarreteras> ();
		mCamGO = GameObject.Find ("Main Camera");
		mCamComp = mCamGO.GetComponent<Camera> ();

		LimitePantalla = new Vector3 (mCamComp.ScreenToWorldPoint (new Vector3 (0, 0, 0)).x, 0, 0);
		fLimiteI = LimitePantalla.x + 1;
		fLimiteD = (-1 *LimitePantalla.x) - 1;
	}

	void Update () {
		if (MotorCarreterasScript.bInicioJuego && !MotorCarreterasScript.bJuegoTerminado) {
			if (bEnPC) {
				fGiro = Input.GetAxis ("Horizontal");
			} else {
				fGiro = Input.acceleration.x;
			}

			iHabGiro = 1;
			if (fGiro > 0) {
				if (transform.position.x >= fLimiteD) {
					iHabGiro = 0;
				}
			} else {
				if (transform.position.x <= fLimiteI) {
					iHabGiro = 0;
				}
			}
				
			float giroEnZ = 0;
			transform.Translate (Vector2.right * fGiro * velocidad * Time.deltaTime * iHabGiro);
			giroEnZ = -fGiro * anguloDeGiro * iHabGiro;
			cocheGO.transform.rotation = Quaternion.Euler (0, 0, giroEnZ);
		}
	}
}
