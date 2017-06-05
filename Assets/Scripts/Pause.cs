using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public string Menu;

	public AudioSource soundManager;

	public GameObject thePauseScreen;

	public GameObject toqueCollider;


	void Start () {
		soundManager = GameObject.Find ("SoundManager").GetComponent<AudioSource>();
	}
		
	void Update () {
		if(Input.GetButtonDown("Pause"))
		{
			if(Time.timeScale == 0f)
			{
				ResumeGame();
			} else {
				PauseGame();
			}
		}
	}

	public void PauseGame()
	{
		Time.timeScale = 0;

		thePauseScreen.SetActive(true);
		toqueCollider.SetActive (false);
		soundManager.Pause();
	}

	public void ResumeGame()
	{
		thePauseScreen.SetActive(false);

		Time.timeScale = 1f;

		toqueCollider.SetActive (true);
		soundManager.Play ();
	}


	public void QuitToMainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(Menu);
	}
}