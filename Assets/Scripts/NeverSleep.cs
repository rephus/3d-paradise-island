using UnityEngine;
using System.Collections;

public class NeverSleep : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
	}
	
}
