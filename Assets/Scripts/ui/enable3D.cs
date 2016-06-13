using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enable3D : MonoBehaviour {

	public Image imageEnabled;
	public Image imageDisabled;

	GameObject view2D, view3D;
	public bool active;
	
	// Use this for initialization
	void Start () {

		view2D = GameObject.Find("2D");
		view3D = GameObject.Find("3D");

		Button button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(delegate() { Toggle(); });

		if(active) Enable3D();
		else Enable2D();
	}

	void Toggle(){
		Debug.Log ("Toggle "+active);
		if (active) Enable2D ();
		else Enable3D ();
	}

	void Enable2D(){
		active = false;
		view3D.SetActive(false);
		view2D.SetActive(true);
		
		SetAlpha(imageDisabled, 1);
		SetAlpha(imageEnabled, 0);
	}
	void Enable3D(){	
		active = true;
		view3D.SetActive(true);
		view2D.SetActive(false);

		SetAlpha(imageDisabled, 0);
		SetAlpha(imageEnabled, 1);
	}

	void SetAlpha(Image i, float alpha){	

		Color color = i.color;
		color.a = alpha;
		i.color = color;
	}



}
