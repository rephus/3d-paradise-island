using UnityEngine;
using System.Collections.Generic;
using System;

public class FollowPath : MonoBehaviour {

	private List<Vector3> path;
	public int current = 0;
	public float speed = 0.3f;
	public Boolean followPath = true;

	// Use this for initialization
	void Start () {
		LoadPath();
		transform.position = path[current];
	
	}
	void LoadPath(){
		GameObject pathContainer = GameObject.Find ("Path");
		path = new List<Vector3>();
		foreach(Transform t in pathContainer.transform){
			Debug.Log ("Loading path " + t.transform.position);
			path.Add(t.transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(1)){
			Debug.Log("Recording position in " + transform.position);
			GameObject go =  GameObject.Find("Go");
			GameObject p  = (GameObject) Instantiate(go);
			p.transform.position = transform.position;
			p.transform.parent = GameObject.Find("NewPath").transform;
		}

		if (!followPath) return; 
		if (current >= path.Count) current = 0; //Restart parth

		Vector3 target = path[current];
		float distance = (transform.position - target).magnitude;
		if (distance > 1){
			
			Vector3 direction = (target - transform.position ).normalized;//Vector3.MoveTowards(transform.position,target, step);
			
			CharacterController controller  = GetComponent<CharacterController>();
			controller.Move(direction * speed);
			
		}
		else current++;
	}
}
