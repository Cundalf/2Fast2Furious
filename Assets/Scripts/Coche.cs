using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour {
	public GameObject PreGameDataGO;
	public PreGameData PreGameDataScript;

	public GameObject MotorCarreteraGO;
	public MotorCarreteras MotorCarreterasScript;

	public Sprite[] SpritesAutos;

	public void Start(){
		PreGameDataGO = GameObject.Find ("PreGameData");
		PreGameDataScript = PreGameDataGO.GetComponent<PreGameData> ();

		MotorCarreteraGO = GameObject.Find ("MotorCarreteras");
		MotorCarreterasScript = MotorCarreteraGO.GetComponent<MotorCarreteras> ();

		gameObject.GetComponent<SpriteRenderer>().sprite = SpritesAutos[PreGameDataScript.iAuto];
		switch (PreGameDataScript.iAuto) {
			case 0:
				MotorCarreterasScript.SetVelocidad (10);
				break;
			case 1:
				MotorCarreterasScript.SetVelocidad (14);
				break;
			case 2:
				MotorCarreterasScript.SetVelocidad (18);
				break;
		}

		Destroy (PreGameDataGO);
	}
}
