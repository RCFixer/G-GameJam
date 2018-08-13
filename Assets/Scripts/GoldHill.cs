using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldHill : MonoBehaviour {
public float timeRemaning = 58.65f;
public static bool EndGame = false;
public float speed = 3.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timeRemaning > 0)
		{
			timeRemaning -= Time.deltaTime;
		} else if (transform.position.y<=1.41f) {
			transform.position = new Vector3 (10.88f, transform.position.y + speed * Time.deltaTime, 0f);
			EndGame = true;
			
		}
	}
}
