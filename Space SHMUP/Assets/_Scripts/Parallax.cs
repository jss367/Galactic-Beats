﻿using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	
	public GameObject poi; //The player ship
	public GameObject[] panels; //The scrolling foregrounds
	public float scrollSpeed = -30f;
	//mptionMult controls how much panels react to player movement
	public float motionMult = 0.25f;
	
	private float panelHt; //Height of each panel
	private float depth; //Depth of panels (that is, pos.z)
	
	
	void Start () {

		panels = GameObject.FindGameObjectsWithTag ("Starfield");
		Debug.Log (panels);
		Debug.Log (panels.Length);
		if (panels.Length != 0){
		panelHt = panels [0].transform.localScale.y;
		depth = panels [0].transform.position.z;
		
		//Set initial positions of panels
		panels [0].transform.position = new Vector3 (0, 0, depth);
		panels [1].transform.position = new Vector3 (0, panelHt, depth);
	}
}	

	void Update () {
//		panels = GameObject.FindGameObjectsWithTag ("Starfield");
//		Debug.Log (panels);
//		Debug.Log (panels.Length);
		if (panels.Length != 0){
			float tY, tX = 0;
			tY = Time.time * scrollSpeed % panelHt + (panelHt * 0.5f);
		
			if (poi != null) {
				tX = -poi.transform.position.x * motionMult;
			}
		
			//Position panels[0]
		
			panels [0].transform.position = new Vector3 (tX, tY, depth);
			//Then position panels[1] where needed to make a continuous starfield
			if (tY >= 0) {
				panels [1].transform.position = new Vector3 (tX, tY - panelHt, depth);
			} else {
				panels [1].transform.position = new Vector3 (tX, tY + panelHt, depth);
			}
		}
		
	}
}
