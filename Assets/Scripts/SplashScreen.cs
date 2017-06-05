using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	public float timer = 4f;
	public string Menu;

	void Start()
	{
		StartCoroutine ("LoadMenu");
	}

	IEnumerator LoadMenu() 
	{
		yield return new WaitForSeconds (timer);
		SceneManager.LoadScene(Menu);
	}
}
