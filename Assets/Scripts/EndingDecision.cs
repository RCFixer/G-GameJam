using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDecision : MonoBehaviour {
Camera mainCam;
public int money = 0;
private SpriteRenderer SR;
	// Use this for initialization
	void Start () {
		SR = GetComponentInChildren<SpriteRenderer>();
		money = UIController.money;

		if (money < 10) {
			SR.sprite = Resources.Load("Bad_Ending",typeof(Sprite)) as Sprite;
			transform.localScale = new Vector2(1.570381f, 1.344699f);
		}
		else if (money>=30) {
			SR.sprite = Resources.Load("Good_Ending",typeof(Sprite)) as Sprite;
			transform.localScale = new Vector2(1.965f, 1.653f);
		}
		else{
			SR.sprite = Resources.Load("Neutral_Ending",typeof(Sprite)) as Sprite;
			transform.localScale = new Vector2(0.91f, 1.05f);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
