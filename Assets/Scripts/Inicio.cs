using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour {
	void Awake () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
}
