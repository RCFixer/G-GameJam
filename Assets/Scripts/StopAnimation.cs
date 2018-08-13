using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour {
public float timeRemaning = 60f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		if (timeRemaning > 0)
		{
			timeRemaning -= Time.deltaTime;
		} else {
			GetComponent<Animator>().Stop();
		}
	}

}
