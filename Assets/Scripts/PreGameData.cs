using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreGameData : MonoBehaviour {
	public static PreGameData preGameData;
	public Image fundido;
	public string escenaSiguiente;
	public int iAuto;

	public void Awake(){
		if (preGameData == null) {
			preGameData = this;
			DontDestroyOnLoad (gameObject);
		}else if (preGameData != this) {
			Destroy (gameObject);
		}
	}

	public void FadeOut(int iDificultad){
		fundido.CrossFadeAlpha (1, 0.5f, false);
		StartCoroutine (CambioEscena (escenaSiguiente));
		iAuto = iDificultad;
	}

	IEnumerator CambioEscena(string escena){
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene (escena);
	}
}
