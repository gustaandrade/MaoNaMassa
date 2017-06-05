using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeControl : MonoBehaviour
{
	public Canvas intro;
	public Canvas inicio;
	public GameObject panel;

	public void Fade ()
	{
		panel.SetActive (true);
	}

	public void Off ()
	{
		intro.gameObject.SetActive (false);
		inicio.gameObject.SetActive (true);
	}

	public void Begin ()
	{
		inicio.gameObject.SetActive (false);
	}
}
