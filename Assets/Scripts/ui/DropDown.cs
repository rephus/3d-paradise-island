using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropDown : MonoBehaviour {

	public GameObject panel;
	public bool active;
	
	// Use this for initialization
	void Start () {

		Button button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(delegate() { Toggle(); });

		if(active) Enable();
		else Disable();
	}

	void Toggle(){
		Debug.Log ("Toggle "+active);
		if (active) Enable ();
		else Disable ();
	}

	void Enable(){
		active = false;
		panel.SetActive(true);//enabled = true;
	}
	void Disable(){	
		active = true;
		panel.SetActive(false);
	}

}
