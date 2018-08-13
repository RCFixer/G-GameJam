using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkull : MonoBehaviour {
public int SkullCount = 0;
private int score = 0;
public GameObject Skull;
	// Use this for initialization
	void Start () {
	//GameObject End = GameObject.Find("EndGame");
	}
	void Awake() {
		Messenger.AddListener(GameEvent.SKULL_COLLECTED,OnSkullCollected);
		Messenger.AddListener(GameEvent.SKULL_CANCELLED,OnSkullCancelled);
	}
	void OnDestroy() {
		Messenger.RemoveListener(GameEvent.SKULL_COLLECTED,OnSkullCollected);
		Messenger.RemoveListener(GameEvent.SKULL_CANCELLED,OnSkullCancelled);
	}
	private void OnSkullCollected() {
			SkullCount-=1;
			
			Invoke("SkullCreation", Random.Range(3.0f,6.0f));
			SkullCount++;
	}
	
	private void SkullCreation() {
		if (!GoldHill.EndGame)
		Instantiate(Skull, new Vector3(Random.Range(-8.3f,8.3f), -5.53f, -5.898f), Quaternion.identity);
	}
	// Update is called once per frame
	private void OnSkullCancelled() {
		Invoke("SkullCreation",Random.Range(20f,25f));
		SkullCount --;
	}
	void Update () {
		if (SkullCount<1) {
			Invoke("SkullCreation", Random.Range(5f,8f));
			SkullCount++;
		}
	}
}