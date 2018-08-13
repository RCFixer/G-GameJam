using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
[SerializeField] private Text scoreLable;
public int money;
	// Use this for initialization
	void Start () {
		money = UIController.money;
		scoreLable.text = money.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
