using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour {

	//TODO Change to range (0 -5)
	public int w, h;
	
	// Use this for initialization
	void Start () {
	  Button button = gameObject.GetComponent<Button>();
	  button.onClick.AddListener(delegate() { OnClick(); });
	}
	
	// Update is called once per frame
	void OnClick () {
	    Debug.Log ("Selected new resolution " + w +"x"+ h);
	    Screen.SetResolution(w,h,true);
	    Resolution r = Screen.GetResolution[0];
	    Debug.Log ("Resolution " + r.width +"x"+r.height);
	}
}
