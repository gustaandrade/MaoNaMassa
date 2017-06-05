using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class Tap : MonoBehaviour
{

	private TapGesture gesture;
	public PlayerController player;

	// Use this for initialization
	void Awake ()
	{
		gesture = GetComponent<TapGesture> ();
	}
	
	// Update is called once per frame
	void TapHandler (object sender, System.EventArgs e)
	{
		player.EscolherDestino (gameObject.name);
	}

	public void OnEnable ()
	{
		gesture.Tapped += TapHandler;
	}

	public void OnDisable ()
	{
		gesture.Tapped -= TapHandler;
	}
}
