using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	public float timeRemaning = 5.49f;
	
	// Update is called once per frame
	void Update(){
		if (timeRemaning > 0)
		{
			timeRemaning -= Time.deltaTime;
		} else {
			SceneManager.LoadScene("Gameplay");
		}
	}
	
}
