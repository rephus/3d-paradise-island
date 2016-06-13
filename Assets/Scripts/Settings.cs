using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	GameObject view2D, view3D;
	Terrain terrain;
	Vector3 origPosition;

	private ComboBox qualityCombobox;
	private ComboBox resolutionCombobox;
	
	private bool guiEnabled = false;

	void Start(){

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.SetResolution(480,320,true);
		view2D = GameObject.Find("2D");
		view3D = GameObject.Find("3D");
		origPosition = GameObject.FindWithTag("Player").transform.position;

		terrain = (Terrain) GameObject.Find ("Terrain").GetComponent<Terrain>();
		Enable2D();

		//COmbo box
		string[] combox = new string[]{"Fastest", "Fast", "Simple", "Good", "Beautiful", "Fantastic" };
		qualityCombobox = new ComboBox(new Rect(400, 0, 100, 50), QualitySettings.GetQualityLevel(), combox);

		string[] combor = new string[]{"480x320", "640x480", "800x480", "1024x600", "1280x800" };
		resolutionCombobox = new ComboBox(new Rect(300, 0, 100, 50), 0, combor);
		
	}

	void Update(){
		if (Input.GetMouseButtonDown(0)) {
			guiEnabled = true;
			InvokeRepeating ("HideGUI", 2.5f, 0);
		}
	}
	// Use this for initialization
	void OnGUI(){
		if (guiEnabled) {
			if (GUI.Button(new Rect(0,0,100,100), "2D")) Enable2D();
			if (GUI.Button(new Rect(100,0,100,100), "3D"))Enable3D();
			if (GUI.Button(new Rect(0,100,100,100), "Reset")) ResetPosition();
			if (GUI.Button(new Rect(0,200,100,100), "Disable trees")) terrain.treeDistance = 0;
			if (GUI.Button(new Rect(100,200,100,100), "Enable trees")) terrain.treeDistance = 100;
			if (GUI.Button(new Rect(0,300,100,100), "Disable details")) terrain.detailObjectDistance = 0;
			if (GUI.Button(new Rect(100,300,100,100), "Enable details")) terrain.detailObjectDistance = 30;
			
			//QualityGUI(100);
	
			int oldCombo = qualityCombobox.SelectedItemIndex;
			int newCombo = qualityCombobox.Show();
			if (oldCombo != newCombo){ //has changed
				Debug.Log ("Selected new quality " + newCombo);
				QualitySettings.SetQualityLevel(newCombo);
				Debug.Log ("Quality " + QualitySettings.currentLevel );
				
			}
	
			int oldCombor = resolutionCombobox.SelectedItemIndex;
			int newCombor = resolutionCombobox.Show();
			if (oldCombor != newCombor){ //has changed
				Debug.Log ("Selected new resolution " + newCombor);
				setResolution(newCombor);
				Resolution r = Screen.GetResolution[0];
				Debug.Log ("Resolution " + r.width +"x"+r.height);
				
			}
		}
	}

	void HideGUI() {
		guiEnabled = false;
		CancelInvoke ("HideGUI");
	
	}
	void setResolution(int comboIndex){

		switch(comboIndex){
			case 0: Screen.SetResolution(480,320,true);break;
			case 1:Screen.SetResolution(640,480,true);break;
			case 2:Screen.SetResolution(800,480,true);break;
			case 3: Screen.SetResolution(1024,600,true);break;
			default:Screen.SetResolution(1280,800,true);break;
		}
		
	}

	void ResetPosition(){
		GameObject.FindWithTag("Player").transform.position = origPosition;

	}
	void Enable2D(){
		view3D.SetActive(false);
		view2D.SetActive(true);
	}
	void Enable3D(){	
		view3D.SetActive(true);
		view2D.SetActive(false);
	}
}
