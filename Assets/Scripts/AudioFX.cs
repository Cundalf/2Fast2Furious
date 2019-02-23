using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour {
	public AudioClip[] fxs;
	AudioSource audioS;

	void Start(){
		audioS = GetComponent<AudioSource> ();
	}

	// 0 choque
	public void FXSonidoChoque(){
		audioS.clip = fxs [0];
		audioS.Play ();
	}

	// 1 music game
	public void FXMusic(){
		audioS.clip = fxs [1];
		audioS.Play ();
	}

	// 2 PowerUp Tiempo
	public void FXSonidoPowerUpTiempo(){
		audioS.clip = fxs [2];
		audioS.Play ();
	}

	// 3 Policia
	public void FXSonidoPatrulla(){
		audioS.clip = fxs [3];
		audioS.Play ();
	}

	// 4 PowerUp Turbo
	public void FXSonidoTurbo(){
		audioS.clip = fxs [4];
		audioS.Play ();
	}
}
