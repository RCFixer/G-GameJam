using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour {
private SpriteRenderer SR;
[SerializeField] private Text moneyLabel;
static public int money;
public AudioSource coin;
public AudioSource badCoin;
public AudioSource stone;
private int type;
	// Use this for initialization
	void Start () {
		money = 0;
		
		type = 0;
	}
	void Awake() {
		Messenger.AddListener(GameEvent.COIN_COLLECTED,OnCoinCollected);
		Messenger.AddListener(GameEvent.SKULL_COLLECTED,OnSkullCollected);
		Messenger.AddListener(GameEvent.STONE_COLLECTED,OnStoneCollected);
	}
	void OnDestroy() {
		Messenger.RemoveListener(GameEvent.COIN_COLLECTED,OnCoinCollected);
		Messenger.RemoveListener(GameEvent.SKULL_COLLECTED,OnSkullCollected);
		Messenger.RemoveListener(GameEvent.STONE_COLLECTED,OnStoneCollected);
	}
	void OnCoinCollected() {
		money +=1;
		coin.Play();
		moneyLabel.text = money.ToString();
		if (money == 10){
			Messenger.Broadcast("TYPE_CHECK");
			type = 1;
		}
		else if (money == 30){
			Messenger.Broadcast("GOLD_CHECK");
			type = 2;
		}
	}
	void OnSkullCollected(){
		money = money/2;
		badCoin.Play();
		moneyLabel.text = money.ToString();
		if ((money <= 10) && (type == 1)){
			Messenger.Broadcast("TYPE_CHECK");
			type = 0;
		}
		else if ((money < 30) && (type == 2)){
			Messenger.Broadcast("GOLD_CHECK");
			type = 1;
		}
	}
	void OnStoneCollected(){
		money = money - 3;
		stone.Play();
		if (money<0) {
			money = 0;
		}
		moneyLabel.text = money.ToString();
		if ((money <= 10) && (type == 1)){
			Messenger.Broadcast("TYPE_CHECK");
			type = 0;
		}
		else if ((money < 30) && (type == 2)){
			Messenger.Broadcast("GOLD_CHECK");
			type = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
