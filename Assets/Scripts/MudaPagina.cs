using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MudaPagina : MonoBehaviour
{
	public GameObject livro;
	public GameObject objLivro;
	public GameObject objCreditos;
	public GameObject objSair;

	private Image imgLivro;

	private int flag1 = 0;
	private bool flag2 = true;
	private bool flag3 = true;
	private bool flag4 = true;

	public Sprite gelatina;
	public Sprite bolinho;
	public Sprite chocolate;

	void Start ()
	{
		imgLivro = livro.GetComponent<Image> ();
	}

	public void TrocarReceita ()
	{
		flag1++;
		if (flag1 == 3)
			flag1 = 0;
		
		if (flag1 == 0) {
			imgLivro.sprite = gelatina;
		} else if (flag1 == 1) {
			imgLivro.sprite = bolinho;
		} else if (flag1 == 2) {
			imgLivro.sprite = chocolate;
		}
	}

	public void TrocarCanvasReceita ()
	{
		if (!flag2) {
			objLivro.SetActive (false);
			flag2 = true;
		} else {
			objLivro.SetActive (true);
			flag2 = false;
		}
	}

	public void TrocarCanvasInfo ()
	{
		if (!flag3) {
			objCreditos.SetActive (false); 
			flag3 = true;
		} else {
			objCreditos.SetActive (true);
			flag3 = false;
		}
	}

	public void TrocarCanvasSair ()
	{
		if (!flag4) {
			objSair.SetActive (false); 
			flag4 = true;
		} else {
			objSair.SetActive (true);
			flag4 = false;
		}
	}

	public void LoadReceita ()
	{
		if (flag1 == 0) {
			SceneManager.LoadScene (2);
		} else if (flag1 == 1) {
			SceneManager.LoadScene (4);
		} else if (flag1 == 2) {
			SceneManager.LoadScene (5);
		}
	}
}