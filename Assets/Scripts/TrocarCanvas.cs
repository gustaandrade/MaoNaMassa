using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCanvas : MonoBehaviour
{
	public GameObject canvasReceita;

	public void LigarCanvasReceita ()
	{
		canvasReceita.SetActive (true);
	}

	public void DesligarCanvasReceita ()
	{
		canvasReceita.SetActive (false);
	}

	public void LoadReceita1 ()
	{
		SceneManager.LoadScene (2);
	}

	public void LoadReceita2 ()
	{
		SceneManager.LoadScene (4);
	}

	public void LoadReceita3 ()
	{
		SceneManager.LoadScene (5);
	}
}
