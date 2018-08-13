using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoinRand : MonoBehaviour {
public int count = 0;
private int score = 0;
public GameObject Coin;
	// Use this for initialization
	void Start () {
		//GameObject End = GameObject.Find("EndGame");
	}
	void Awake() {
		Messenger.AddListener(GameEvent.COIN_COLLECTED,OnCoinCollected);
		Messenger.AddListener(GameEvent.COIN_CANCELLED,OnCoinCancelled);
	}
	void OnDestroy() {
		Messenger.RemoveListener(GameEvent.COIN_COLLECTED,OnCoinCollected);
		Messenger.RemoveListener(GameEvent.COIN_CANCELLED,OnCoinCancelled);
	}
	private void OnCoinCollected() {
			count-=1;
			
			Invoke("CoinCreation", Random.Range(3.0f,6.0f));
			count++;
	}
	
	private void CoinCreation() {
		if (!GoldHill.EndGame)
		Instantiate(Coin, new Vector3(Random.Range(-8.3f,8.3f), -5.53f, -5.898f), Quaternion.identity);
	}
	// Update is called once per frame
	private void OnCoinCancelled() {
		Invoke("CoinCreation",Random.Range(5f,8f));
		count ++;
	}
	void Update () {
		if (count<5) {
			Invoke("CoinCreation", Random.Range(5f,8f));
			count++;
		}
	}
}
