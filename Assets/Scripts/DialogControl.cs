using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogControl : MonoBehaviour
{
	public GameObject dialogos;
	private Transform log;
	private Text[] vetorDialogos;
	private int numDialogos;

	public GameObject canvasLivro;
	private Animator livro;
	public Button next;

	public int count;

	public GameObject aguafria1;
	public GameObject aguafria2;
	public GameObject aguafria3;
	public GameObject aguafria4;
	public GameObject aguaquente1;
	public GameObject aguaquente2;
	public GameObject aguavermelha;
	public GameObject bowl;
	public GameObject pogelatina1;
	public GameObject pogelatina2;
	public GameObject gelatinafinal;

	public GameObject btnMix;
	public Button btnNext;

	/**************** RECEITA 2 *****************/

	public TutorialControl receita;
	public GameObject canvasDialogo;

	public AudioSource etapaSom;
	public AudioClip etapaSon;
	private bool soundPlayed = false;


	void Start ()
	{
		etapaSom = GetComponent<AudioSource> ();

		log = dialogos.GetComponent<Transform> ();
		numDialogos = log.childCount; 
		vetorDialogos = new Text[numDialogos];


		for (int i = 0; i < numDialogos; i++) {
			vetorDialogos [i] = log.GetChild (i).gameObject.GetComponent<Text> ();
		}

		livro = canvasLivro.GetComponent<Animator> ();
	}

	void Update ()
	{
		ChangeDialog ();
	}

	public void ChangeDialog ()
	{
		/**************** RECEITA 1 *****************/

		if (SceneManager.GetActiveScene ().buildIndex == 2) {
			if (count == GameConstants.ANIM_LIVRO_ON) {
				livro.Play ("anim_fadein_livro");
			}
			if (count == GameConstants.ANIM_LIVRO_OFF) {
				livro.Play ("anim_fadeout_livro");
			}
			if (count == GameConstants.PASSO1_TUTORIAL
			    || count == GameConstants.PASSO2_TUTORIAL
			    || count == GameConstants.PASSO3_TUTORIAL
			    || count == GameConstants.PASSO4_TUTORIAL
			    || count == GameConstants.PASSO5_TUTORIAL
			    || count == GameConstants.PASSO6_TUTORIAL
			    || count == GameConstants.PASSO7_TUTORIAL
			    || count == GameConstants.PASSO8_TUTORIAL
			    || count == GameConstants.PASSO9_TUTORIAL
			    || count == GameConstants.PASSO10_TUTORIAL
			    || count == GameConstants.PASSO11_TUTORIAL
			    || count == GameConstants.PASSO12_TUTORIAL) {
				next.interactable = false;
			}

			if (count == GameConstants.PASSO1_TUTORIAL + 1) {
				aguafria1.SetActive (true);

				if (!soundPlayed) {
					etapaSom.PlayOneShot (etapaSon);
					soundPlayed = true;
				}

			} else if (count == GameConstants.PASSO2_TUTORIAL + 1) {
				aguafria1.SetActive (false);
				aguafria2.SetActive (true);

				TocarSom ();

			} else if (count == GameConstants.PASSO3_TUTORIAL + 1) {
				aguafria2.SetActive (false);
				aguafria4.SetActive (true);

				TocarSom ();

			} else if (count == GameConstants.PASSO4_TUTORIAL + 1) {
				aguafria4.SetActive (false);
				aguafria3.SetActive (true);

				TocarSom ();

			} else if (count == 24) {
				aguafria3.SetActive (false);
				aguaquente1.SetActive (true);

				TocarSom ();

			} else if (count == GameConstants.PASSO5_TUTORIAL + 1) {
				aguafria3.SetActive (false);
				pogelatina1.SetActive (true);

				TocarSom ();

			} else if (count == GameConstants.PASSO6_TUTORIAL + 1) {
				pogelatina1.SetActive (false);
				pogelatina2.SetActive (true);

				TocarSom ();

			} else if (count == GameConstants.PASSO8_TUTORIAL + 1) {
				aguaquente1.SetActive (false);
				aguaquente2.SetActive (true);

				TocarSom ();

			} else if (count == GameConstants.PASSO9_TUTORIAL + 1) {
				aguafria1.SetActive (true);

				TocarSom ();

			} else if (count == GameConstants.PASSO10_TUTORIAL + 1) {
				aguafria1.SetActive (false);
				aguafria2.SetActive (true);

				TocarSom ();

			} else if (count == GameConstants.PASSO11_TUTORIAL) {
				btnMix.SetActive (true);

			} else if (count == GameConstants.PASSO11_TUTORIAL + 1) {
				btnMix.SetActive (false);
				btnNext.interactable = true;
				aguafria2.SetActive (false);
				aguaquente2.SetActive (false);
				pogelatina2.SetActive (false);
				bowl.SetActive (false);
				aguavermelha.SetActive (true);


			} else if (count == GameConstants.PASSO12_TUTORIAL + 1) {
				aguavermelha.SetActive (false);
				gelatinafinal.SetActive (true);

				TocarSom ();

			} else if (count == GameConstants.PASSOFINAL_TUTORIAL) {
				SceneManager.LoadScene (3);
			}
		}

		/**************** RECEITA 2 *****************/

		else if (SceneManager.GetActiveScene ().buildIndex == 4) {
			if (count == GameConstants.ANIM_LIVRO_ON) {
				livro.Play ("anim_fadein_livro");
			}
			if (count == GameConstants.ANIM_LIVRO_OFF) {
				livro.Play ("anim_fadeout_livro");
			}

			if (count == GameConstants.COUNT_INICIO_RECEITA2) {
				receita.SetAllBoxesTrue ();
				canvasDialogo.GetComponent<Canvas> ().enabled = false;
			}
		} 


		/**************** RECEITA 3 *****************/


		else if (SceneManager.GetActiveScene ().buildIndex == 5) {
			if (count == GameConstants.ANIM_LIVRO_ON) {
				livro.Play ("anim_fadein_livro");
			}
			if (count == GameConstants.ANIM_LIVRO_OFF) {
				livro.Play ("anim_fadeout_livro");
			}

			if (count == GameConstants.COUNT_INICIO_RECEITA3) {
				receita.SetAllBoxesTrue ();
				canvasDialogo.GetComponent<Canvas> ().enabled = false;
			}
		}
	}

	public void SetCount ()
	{
		count++;
		vetorDialogos [count - 1].GetComponent<Animator> ().Play ("anim_fadeout_text");
		vetorDialogos [count - 1].enabled = false;
		vetorDialogos [count].GetComponent<Animator> ().Play ("anim_fadein_text");
		vetorDialogos [count].enabled = true;
		Debug.Log (count);

		soundPlayed = false;
	}

	public int GetCount ()
	{
		return count;
	}

	public void TocarSom ()
	{
		if (!soundPlayed) {
			etapaSom.PlayOneShot (etapaSon);
			soundPlayed = true;
		}
	}

}
