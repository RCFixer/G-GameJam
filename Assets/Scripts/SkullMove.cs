using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullMove : MonoBehaviour {
public float speed = 6.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y<=5.58f) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
		} else {
			Destroy(gameObject);
			Messenger.Broadcast(GameEvent.SKULL_CANCELLED);
			
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		Destroy(gameObject);
		Messenger.Broadcast(GameEvent.SKULL_COLLECTED);
		
	}
}