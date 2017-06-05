using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	public void EncerrarReceita ()
	{
		SceneManager.LoadScene (3);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.F2)) {
			SceneManager.LoadScene (0);
		} 
		if (Input.GetKeyDown (KeyCode.F3)) {
			SceneManager.LoadScene (1);
		} 
		if (Input.GetKeyDown (KeyCode.F4)) {
			SceneManager.LoadScene (2);
		} 
		if (Input.GetKeyDown (KeyCode.F5)) {
			SceneManager.LoadScene (3);
		} 
		if (Input.GetKeyDown (KeyCode.F6)) {
			SceneManager.LoadScene (4);
		} 
		if (Input.GetKeyDown (KeyCode.F7)) {
			SceneManager.LoadScene (5);
		}
	}
}
