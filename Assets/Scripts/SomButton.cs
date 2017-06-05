using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SomButton : MonoBehaviour
{
	private AudioSource music;

	public Sprite btnOn;
	public Sprite btnOff;
	private Image btn;

	void Awake ()
	{
		music = GetComponent<AudioSource> ();
		btn = GameObject.Find ("Som").GetComponent<Image> ();
	}

	public void ChangeSound ()
	{
		if (music.mute) {
			music.mute = false;
			btn.sprite = btnOn;
		} else {
			music.mute = true;
			btn.sprite = btnOff;
		}
	}
}