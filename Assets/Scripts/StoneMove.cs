using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMove : MonoBehaviour {
public float speed = 8.0f;
private int sprite_type;
private SpriteRenderer SR;

	// Use this for initialization
	void Start () {
		SR = GetComponent<SpriteRenderer>();
		sprite_type = Random.Range(0,2);
		if (sprite_type == 0) {
        	SR.sprite = Resources.Load("Stone1",typeof(Sprite)) as Sprite;
        }
        else if (sprite_type == 1) {
            SR.sprite = Resources.Load("Stone2",typeof(Sprite)) as Sprite;
        }
	}
	
	// Update is called oncse per frame
	void Update () {
		

		if (transform.position.y<=5.58f) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
		} else {
			Destroy(gameObject);
			Messenger.Broadcast(GameEvent.STONE_CANCELLED);
			
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		Destroy(gameObject);
		Messenger.Broadcast(GameEvent.STONE_COLLECTED);
		
	}

}
