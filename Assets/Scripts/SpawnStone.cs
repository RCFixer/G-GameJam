using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStone : MonoBehaviour {
public int StoneCount = 0;
public GameObject Stone;
	// Use this for initialization
	void Start () {
	//GameObject End = GameObject.Find("EndGame");
	}
	void Awake() {
		Messenger.AddListener(GameEvent.STONE_COLLECTED,OnStoneCollected);
		Messenger.AddListener(GameEvent.STONE_CANCELLED,OnStoneCancelled);
	}
	void OnDestroy() {
		Messenger.RemoveListener(GameEvent.STONE_COLLECTED,OnStoneCollected);
		Messenger.RemoveListener(GameEvent.STONE_CANCELLED,OnStoneCancelled);
	}
	private void OnStoneCollected() {
			StoneCount-=1;
			
			Invoke("StoneCreation", Random.Range(3.0f,6.0f));
			StoneCount++;
	}
	
	private void StoneCreation() {
		if (!GoldHill.EndGame)
		Instantiate(Stone, new Vector3(Random.Range(-8.3f,8.3f), -5.53f, -5.898f), Quaternion.identity);
	}
	// Update is called once per frame
	private void OnStoneCancelled() {
		Invoke("StoneCreation",Random.Range(20f,25f));
		StoneCount --;
	}
	void Update () {
		if (StoneCount<1) {
			Invoke("StoneCreation", Random.Range(5f,8f));
			StoneCount++;
		}
	}
}