using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AgainClick : MonoBehaviour {

	// Use this for initialization
	public void AgainCl () {
		Debug.Log("sos");
		GoldHill.EndGame = false;
		SceneManager.LoadScene("Main Scene");
	}
	
	// Update is called once per frame

}
