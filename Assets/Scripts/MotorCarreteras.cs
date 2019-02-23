using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour {

	public GameObject contenedorCallesGO;
	public GameObject calleAnterior;
	public GameObject calleNueva;
	public GameObject mCamGO;
	public GameObject[] contenedorCallesArray;
	public GameObject musicaFondoGO;
	public GameObject cocheGO;
	public GameObject audioFXGO;
	public GameObject bgFinalGO;

	public AudioFX audioFXScript;
	public AudioSource musicaFondoAS;
	public Camera mCamComp;
	public Vector3 medidaLimitePantalla;

	public float fVelocidad;
	public float tamañoCalle;
	public bool bInicioJuego;
	public bool bJuegoTerminado;
	public bool salioDePantalla;
	public bool bReducirVelocidad;

	int iCont = 0;
	int iRandom;
	float fTiempo = 0;
	bool bTurbo = false;

	void Start () {
		InicioJuego ();
	}

	void InicioJuego(){
		contenedorCallesGO = GameObject.Find ("ContenedorCalles");
		mCamGO = GameObject.Find ("Main Camera");
		mCamComp = mCamGO.GetComponent<Camera> ();
	
		bgFinalGO = GameObject.Find ("PanelGameOver");
		bgFinalGO.SetActive (false);

		audioFXGO = GameObject.Find ("AudioFX");
		audioFXScript = audioFXGO.GetComponent<AudioFX> ();

		cocheGO = GameObject.FindObjectOfType<Coche> ().gameObject;

		musicaFondoGO = GameObject.Find ("MusicaFondo");
		musicaFondoAS = musicaFondoGO.GetComponent<AudioSource> ();

		//this.SetVelocidad (12);
		MedirPantalla ();
		BuscaCalles ();
	}

	public void JuegoTerminadoEstados(){
		cocheGO.GetComponent<AudioSource>().Stop();
		musicaFondoAS.Stop ();
		audioFXScript.FXMusic ();
		bgFinalGO.SetActive (true);
	}
		
	public void SetVelocidad(float fVelocidad){
		this.fVelocidad = fVelocidad;
	}

	public float GetVelocidad(){
		return fVelocidad;
	}
		
	public void ActivaTurbo(){
		this.bTurbo = true;
	}

	public void ReducirVelocidad(bool bReducirVelocidad){
		this.bReducirVelocidad = bReducirVelocidad;
	}

	void BuscaCalles(){
		contenedorCallesArray = GameObject.FindGameObjectsWithTag ("Calle");
		for (int i = 0; i < contenedorCallesArray.Length; i++) {
			contenedorCallesArray [i].gameObject.transform.parent = contenedorCallesGO.transform;
			contenedorCallesArray [i].gameObject.gameObject.SetActive (false);
			contenedorCallesArray [i].gameObject.name = "CalleOFF_" + i;
		}
		CrearCalles ();
	}

	void CrearCalles(){
		iCont++;
		iRandom = Random.Range (0, contenedorCallesArray.Length);
		GameObject Calle = Instantiate (contenedorCallesArray [iRandom]);
		Calle.SetActive (true);
		Calle.name = "Calle" + iCont;
		Calle.transform.parent = gameObject.transform;
		PosicionaCalles ();
	}

	void PosicionaCalles(){
		calleAnterior = GameObject.Find ("Calle" + (iCont - 1));
		calleNueva = GameObject.Find ("Calle" + iCont);
		MidoCalle ();
		calleNueva.transform.position = new Vector3 (
			calleAnterior.transform.position.x, 
			calleAnterior.transform.position.y + tamañoCalle, 
			0
		);
		salioDePantalla = false;
	}

	void MidoCalle(){
		for (int i = 0; i < calleAnterior.transform.childCount; i++) {
			if (calleAnterior.transform.GetChild (i).gameObject.GetComponent<Pieza> () != null) {
				float tamañoPieza = calleAnterior.transform.GetChild (i).gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
				tamañoCalle = tamañoCalle + tamañoPieza;
			}
		}
	}

	void MedirPantalla(){
		medidaLimitePantalla = new Vector3 (0, mCamComp.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
	}

	void DestroyoCalles(){
		Destroy (calleAnterior);
		tamañoCalle = 0;
		calleAnterior = null;
		CrearCalles ();
	}

	float GetVelocidadFinal(){
		if (bReducirVelocidad) {
			return fVelocidad * 0.7f;
		} else if (bTurbo) {
			return fVelocidad * 1.3f;
		}else{
			return fVelocidad;
		}
	}

	void Update () {
		//Debug.Log (GetVelocidadFinal());
		if (bTurbo) {
			fTiempo += Time.deltaTime;

			if (((int)fTiempo) >= 3) {
				this.bTurbo = false;
				fTiempo = 0;
			}
		}

		if (bInicioJuego && !bJuegoTerminado) {
			transform.Translate (Vector3.down * GetVelocidadFinal() * Time.deltaTime);

			if ((calleAnterior.transform.position.y + tamañoCalle < medidaLimitePantalla.y) && (salioDePantalla == false)) {
				salioDePantalla = true;
				DestroyoCalles();
			}
		}
	}
}