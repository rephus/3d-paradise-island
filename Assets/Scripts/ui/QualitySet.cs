using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QualitySet : MonoBehaviour {

	//TODO Change to range (0 -5)
	public int quality; 
	
	// Use this for initialization
	void Start () {
	  Button button = gameObject.GetComponent<Button>();
	  button.onClick.AddListener(delegate() { OnClick(); });
	}
	
	// Update is called once per frame
	void OnClick () {
	    Debug.Log ("Selected new quality " + quality);
	    QualitySettings.SetQualityLevel(quality);
	    Debug.Log ("Quality " + QualitySettings.currentLevel );
	}
}
