using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	/**************** RECEITA 1 *****************/

	public Transform posicaoFogao;
	public Transform posicaoForno;
	public Transform posicaoMesaVovo;

	public Transform posicaoArmario;
	public Transform posicaoGeladeira;
	public Transform posicaoPia;
	public Transform posicaoMesaNeta;

	private Transform destino1;
	private Transform destino2;
	public Transform origDestino1;
	public Transform origDestino2;

	public GameObject player1;
	public GameObject player2;

	private bool flagMover1 = false;
	private bool flagMover2 = false;

	public TutorialControl tutorial;

	private Transform[] numeroPosicoes;

	private Animator animVo;
	private Animator animNeta;

	private BoxCollider2D boxVo;
	private BoxCollider2D boxNeta;


	#region DECLARAÇÕES RECEITA 2

	/**************** RECEITA 2 *****************/


	public GameObject canvasArmario;
	public GameObject canvasGeladeira;
	public GameObject btnAcucar;
	public GameObject btnFarinha;
	public GameObject btnOleo;
	public GameObject btnOvo;
	public GameObject btnLeite;
	public GameObject btnMix;

	private bool flagEtapa1 = false;
	private bool flagEtapa2 = false;
	private bool flagEtapa3 = false;

	public GameObject ovos;
	public GameObject farinha;
	public GameObject leite;
	public GameObject oleo1;
	public GameObject oleo2;
	public GameObject massa1;
	public GameObject massa2;
	public GameObject massa3;
	public GameObject bolinho1;
	public GameObject bolinho2;
	public GameObject bolinho3;
	public GameObject panela1;
	public GameObject panela2;
	public GameObject acucar;
	public GameObject bolinhofinal;

	public GameObject btnMix2;

	public GameObject relogio1;

	#endregion

	#region DECLARAÇÕES RECEITA 3

	/**************** RECEITA 3 *****************/

	public GameObject r3_canvasArmario;
	public GameObject r3_canvasGeladeira;
	public GameObject r3_btnAcucar1;
	public GameObject r3_btnAcucar2;
	public GameObject r3_btnFarinha;
	public GameObject r3_btnOvo;
	public GameObject r3_btnLeite;
	public GameObject r3_btnChocolate1;
	public GameObject r3_btnChocolate2;
	public GameObject r3_btnManteiga1;
	public GameObject r3_btnManteiga2;
	public GameObject r3_btnFermento;
	public GameObject r3_btnCreme;

	public GameObject r3_btnMix;
	public GameObject r3_btnMix2;

	public GameObject r3_ovos;
	public GameObject r3_farinha;
	public GameObject r3_leite;
	public GameObject r3_acucar1;
	public GameObject r3_acucar2;
	public GameObject r3_acucar3;
	public GameObject r3_fermento;
	public GameObject r3_manteiga1;
	public GameObject r3_manteiga2;
	public GameObject r3_manteiga3;
	public GameObject r3_chocolate1;
	public GameObject r3_chocolate2;
	public GameObject r3_chocolate3;
	public GameObject r3_massaBolo1;
	public GameObject r3_massaBolo2;
	public GameObject r3_bolo1;
	public GameObject r3_bolo2;
	public GameObject r3_creme1;
	public GameObject r3_creme2;
	public GameObject r3_panela1;
	public GameObject r3_panela2;
	public GameObject r3_calda;
	public GameObject r3_boloFinal;

	public GameObject relogio2;
	public GameObject relogio3;

	private bool flagEtapa1_R3 = false;
	private bool flagEtapa2_R3 = false;
	private bool flagEtapa3_R3 = false;
	private bool flagEtapa4_R3 = false;
	private bool flagEtapa5_R3 = false;
	private bool flagEtapa6_R3 = false;


	#endregion

	#region DECLARAÇÕES CANVASCHEERS PARA R2 E R3

	public GameObject canvasCheers;

	public GameObject txtr2_1;
	public GameObject txtr2_2;
	public GameObject txtr2_3;
	public GameObject btnFim1;

	public GameObject txtr3_1;
	public GameObject txtr3_2;
	public GameObject txtr3_3;
	public GameObject btnFim2;

	#endregion

	void Start ()
	{
		Input.multiTouchEnabled = true;
		destino1 = origDestino1;
		destino2 = origDestino2;

		numeroPosicoes = new Transform[7];
		numeroPosicoes [0] = posicaoForno;
		numeroPosicoes [1] = posicaoFogao;
		numeroPosicoes [2] = posicaoMesaVovo;
		numeroPosicoes [3] = posicaoArmario;
		numeroPosicoes [4] = posicaoGeladeira;
		numeroPosicoes [5] = posicaoPia;
		numeroPosicoes [6] = posicaoMesaNeta;
	}

	void Update ()
	{
		MoverPersonagem ();
	}

	public void EscolherDestino (string name)
	{
		if (name == "Forno") {
			destino1 = posicaoForno;

			if (SceneManager.GetActiveScene ().buildIndex == 5) {
				LevarForno_R3 ();
			}

			AnimeVovo (1);
			flagMover1 = true;

		} else if (name == "Fogao") {
			destino1 = posicaoFogao;

			if (SceneManager.GetActiveScene ().buildIndex == 4) {
				LevarFogao ();
			} else if (SceneManager.GetActiveScene ().buildIndex == 5) {
				LevarFogao_R3 ();
			}

			AnimeVovo (2);
			flagMover1 = true;

		} else if (name == "MesaVovo") {
			destino1 = posicaoMesaVovo;

			if (SceneManager.GetActiveScene ().buildIndex == 4) {
				PegarMesa ();
			} else if (SceneManager.GetActiveScene ().buildIndex == 5) {
				PegarMesa_R3 ();
			}

			AnimeVovo (3);
			flagMover1 = true;
		}

		if (name == "Armario") {
			destino2 = posicaoArmario;

			if (SceneManager.GetActiveScene ().buildIndex == 4) {
				canvasArmario.GetComponent<Canvas> ().enabled = true;
				canvasGeladeira.GetComponent<Canvas> ().enabled = false;
			} else if (SceneManager.GetActiveScene ().buildIndex == 5) {
				r3_canvasArmario.GetComponent<Canvas> ().enabled = true;
				r3_canvasGeladeira.GetComponent<Canvas> ().enabled = false;
			}

			AnimeNeta (3);
			flagMover2 = true;

		} else if (name == "Geladeira") {
			destino2 = posicaoGeladeira;

			if (SceneManager.GetActiveScene ().buildIndex == 4) {
				canvasArmario.GetComponent<Canvas> ().enabled = false;
				canvasGeladeira.GetComponent<Canvas> ().enabled = true;
			} else if (SceneManager.GetActiveScene ().buildIndex == 5) {
				r3_canvasArmario.GetComponent<Canvas> ().enabled = false;
				r3_canvasGeladeira.GetComponent<Canvas> ().enabled = true;
			}

			AnimeNeta (1);
			flagMover2 = true;

		} else if (name == "Pia") {
			destino2 = posicaoPia;

			if (SceneManager.GetActiveScene ().buildIndex == 4) {
				canvasArmario.GetComponent<Canvas> ().enabled = false;
				canvasGeladeira.GetComponent<Canvas> ().enabled = false;
			} else if (SceneManager.GetActiveScene ().buildIndex == 5) {
				r3_canvasArmario.GetComponent<Canvas> ().enabled = false;
				r3_canvasGeladeira.GetComponent<Canvas> ().enabled = false;
			}

			AnimeNeta (3);
			flagMover2 = true;

		} else if (name == "MesaNeta") {
			destino2 = posicaoMesaNeta;

			if (SceneManager.GetActiveScene ().buildIndex == 4) {
				canvasArmario.GetComponent<Canvas> ().enabled = false;
				canvasGeladeira.GetComponent<Canvas> ().enabled = false;
				ColocarNaMesa ();
			} else if (SceneManager.GetActiveScene ().buildIndex == 5) {
				r3_canvasArmario.GetComponent<Canvas> ().enabled = false;
				r3_canvasGeladeira.GetComponent<Canvas> ().enabled = false;
				ColocarNaMesa_R3 ();
			}

			AnimeNeta (2);
			flagMover2 = true;
		}
	}

	public void MoverPersonagem ()
	{  
		if (flagMover1) {
			player1.transform.position = Vector3.MoveTowards (player1.transform.position, destino1.position, GameConstants.PLAYER_SPEED * Time.deltaTime);

			if (Vector3.Distance (player1.transform.position, destino1.position) < 0.1) {
				AnimeVovo (5);
				tutorial.SetFlagMover1 ();
				flagMover1 = false;
			}
		} 
		
		if (flagMover2) {
			player2.transform.position = Vector3.MoveTowards (player2.transform.position, destino2.position, GameConstants.PLAYER_SPEED * Time.deltaTime);

			if (Vector3.Distance (player2.transform.position, destino2.position) < 0.1) {
				AnimeNeta (5);
				tutorial.SetFlagMover2 ();
				flagMover2 = false;
			}	
		}
	}

	public void AnimeVovo (int i)
	{
		if (i == 1) {
			player1.GetComponent<Animator> ().SetBool ("isWest", false);
			player1.GetComponent<Animator> ().SetBool ("isEast", false);
			player1.GetComponent<Animator> ().SetBool ("isSouth", false);
			player1.GetComponent<Animator> ().SetBool ("isNorth", true);
		}
		if (i == 2) {
			player1.GetComponent<Animator> ().SetBool ("isNorth", false);
			player1.GetComponent<Animator> ().SetBool ("isEast", false);
			player1.GetComponent<Animator> ().SetBool ("isSouth", false);
			player1.GetComponent<Animator> ().SetBool ("isWest", true);
		}
		if (i == 3) {
			player1.GetComponent<Animator> ().SetBool ("isNorth", false);
			player1.GetComponent<Animator> ().SetBool ("isWest", false);
			player1.GetComponent<Animator> ().SetBool ("isSouth", false);
			player1.GetComponent<Animator> ().SetBool ("isEast", true);
		}
		if (i == 4) {
			player1.GetComponent<Animator> ().SetBool ("isNorth", false);
			player1.GetComponent<Animator> ().SetBool ("isWest", false);
			player1.GetComponent<Animator> ().SetBool ("isEast", false);
			player1.GetComponent<Animator> ().SetBool ("isSouth", true);
		}
		if (i == 5) {
			player1.GetComponent<Animator> ().SetBool ("isNorth", false);
			player1.GetComponent<Animator> ().SetBool ("isWest", false);
			player1.GetComponent<Animator> ().SetBool ("isEast", false);
			player1.GetComponent<Animator> ().SetBool ("isSouth", false);
		}
	}

	public void AnimeNeta (int i)
	{
		if (i == 1) {
			player2.GetComponent<Animator> ().SetBool ("isWest", false);
			player2.GetComponent<Animator> ().SetBool ("isEast", false);
			player2.GetComponent<Animator> ().SetBool ("isSouth", false);
			player2.GetComponent<Animator> ().SetBool ("isNorth", true);
		}
		if (i == 2) {
			player2.GetComponent<Animator> ().SetBool ("isNorth", false);
			player2.GetComponent<Animator> ().SetBool ("isEast", false);
			player2.GetComponent<Animator> ().SetBool ("isSouth", false);
			player2.GetComponent<Animator> ().SetBool ("isWest", true);
		}
		if (i == 3) {
			player2.GetComponent<Animator> ().SetBool ("isNorth", false);
			player2.GetComponent<Animator> ().SetBool ("isWest", false);
			player2.GetComponent<Animator> ().SetBool ("isSouth", false);
			player2.GetComponent<Animator> ().SetBool ("isEast", true);
		}
		if (i == 4) {
			player2.GetComponent<Animator> ().SetBool ("isNorth", false);
			player2.GetComponent<Animator> ().SetBool ("isWest", false);
			player2.GetComponent<Animator> ().SetBool ("isEast", false);
			player2.GetComponent<Animator> ().SetBool ("isSouth", true);
		}
		if (i == 5) {
			player2.GetComponent<Animator> ().SetBool ("isNorth", false);
			player2.GetComponent<Animator> ().SetBool ("isWest", false);
			player2.GetComponent<Animator> ().SetBool ("isEast", false);
			player2.GetComponent<Animator> ().SetBool ("isSouth", false);
		}
	}

	#region FUNÇÕES RECEITA 2

	/**************** RECEITA 2 *****************/


	public void EscolherItem1 ()
	{
		btnAcucar.SetActive (false);
		canvasArmario.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem2 ()
	{
		btnFarinha.SetActive (false);
		canvasArmario.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem3 ()
	{
		btnOleo.SetActive (false);
		canvasArmario.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem4 ()
	{
		btnOvo.SetActive (false);
		canvasArmario.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem5 ()
	{
		btnLeite.SetActive (false);
		canvasGeladeira.GetComponent<Canvas> ().enabled = false;
	}

	public void ColocarNaMesa ()
	{
		if (!flagEtapa1) {
			if (btnOvo.activeInHierarchy == false) {
				ovos.SetActive (true);
			}
			if (btnFarinha.activeInHierarchy == false) {
				farinha.SetActive (true);
			}
			if (btnLeite.activeInHierarchy == false) {
				leite.SetActive (true);
			}
			if (btnOleo.activeInHierarchy == false) {
				oleo1.SetActive (true);
			}
			if (btnAcucar.activeInHierarchy == false) {
				acucar.SetActive (true);
			}

			if (btnAcucar.activeInHierarchy == false && btnFarinha.activeInHierarchy == false &&
			    btnOleo.activeInHierarchy == false && btnOvo.activeInHierarchy == false &&
			    btnLeite.activeInHierarchy == false) {
				btnMix.SetActive (true);
				StartCoroutine (CheersR2 (1));
			}
		}
	}

	public void MisturarIngredientes ()
	{
		StartCoroutine (Rotina ());
	}

	IEnumerator Rotina ()
	{
		flagEtapa1 = true;
		btnMix.SetActive (false);
		ovos.SetActive (false);
		farinha.SetActive (false);
		leite.SetActive (false);
		massa1.SetActive (true);
		yield return new WaitForSecondsRealtime (3);
		massa1.SetActive (false);
		massa2.SetActive (true);
	}

	public void PegarMesa ()
	{
		if (massa2.activeInHierarchy == true) {
			oleo1.SetActive (false);
			massa2.SetActive (false);
			flagEtapa2 = true;
		}
		if (flagEtapa3) {
			panela1.SetActive (false);
			bolinho2.SetActive (false);
			panela2.SetActive (true);
			bolinho3.SetActive (true);
			btnMix2.SetActive (true);
			flagEtapa3 = false;
		}
	}

	public void LevarFogao ()
	{
		if (flagEtapa2) {
			tutorial.SetBoxFalse (1);
			oleo2.SetActive (true);
			massa3.SetActive (true);
			StartCoroutine (FritarBolinho ());
		}
	}

	IEnumerator FritarBolinho ()
	{
		yield return new WaitForSecondsRealtime (3);
		relogio1.SetActive (true);
		oleo2.SetActive (false);
		massa3.SetActive (false);
		//panela1.SetActive (true);
		bolinho1.SetActive (true);
		StartCoroutine (CheersR2 (2));
		yield return new WaitForSecondsRealtime (3);
		relogio1.SetActive (false);
		bolinho1.SetActive (false);
		bolinho2.SetActive (true);
		flagEtapa2 = false;
		flagEtapa3 = true;
	}

	public void TerminarReceita ()
	{
		acucar.SetActive (false);
		panela2.SetActive (false);
		bolinho3.SetActive (false);
		btnMix2.SetActive (false);
		bolinhofinal.SetActive (true);
		StartCoroutine (CheersR2 (3));
	}

	IEnumerator CheersR2 (int num)
	{
		canvasCheers.SetActive (true);

		if (num == 1) {
			txtr2_1.SetActive (true);
			yield return new WaitForSecondsRealtime (3);
			canvasCheers.SetActive (false);
		} else if (num == 2) {
			txtr2_1.SetActive (false);
			txtr2_2.SetActive (true);
			yield return new WaitForSecondsRealtime (3);
			canvasCheers.SetActive (false);
		} else if (num == 3) {
			txtr2_2.SetActive (false);
			txtr2_3.SetActive (true);
			btnFim1.SetActive (true);
		}
	}

	#endregion

	/**************** RECEITA 3 *****************/

	#region FUNÇÕES RECEITA 3

	public void EscolherItem1_R3 ()
	{
		r3_btnChocolate1.SetActive (false);
		r3_canvasArmario.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem2_R3 ()
	{
		r3_btnFarinha.SetActive (false);
		r3_canvasArmario.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem3_R3 ()
	{
		r3_btnOvo.SetActive (false);
		r3_canvasArmario.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem4_R3 ()
	{
		r3_btnFermento.SetActive (false);
		r3_canvasArmario.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem5_R3 ()
	{
		r3_btnAcucar1.SetActive (false);
		r3_canvasArmario.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem6_R3 ()
	{
		r3_btnManteiga1.SetActive (false);
		r3_canvasGeladeira.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem7_R3 ()
	{
		r3_btnLeite.SetActive (false);
		r3_canvasGeladeira.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem8_R3 ()
	{
		r3_btnChocolate2.SetActive (false);
		r3_canvasArmario.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem9_R3 ()
	{
		r3_btnCreme.SetActive (false);
		r3_canvasArmario.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem10_R3 ()
	{
		r3_btnAcucar2.SetActive (false);
		r3_canvasArmario.GetComponent<Canvas> ().enabled = false;
	}

	public void EscolherItem11_R3 ()
	{
		r3_btnManteiga2.SetActive (false);
		r3_canvasGeladeira.GetComponent<Canvas> ().enabled = false;
	}

	public void ColocarNaMesa_R3 ()
	{
		if (!flagEtapa1_R3) {
			if (r3_btnChocolate1.activeInHierarchy == false) {
				r3_chocolate1.SetActive (true);
			}
			if (r3_btnFarinha.activeInHierarchy == false) {
				r3_farinha.SetActive (true);
			}
			if (r3_btnOvo.activeInHierarchy == false) {
				r3_ovos.SetActive (true);
			}
			if (r3_btnFermento.activeInHierarchy == false) {
				r3_fermento.SetActive (true);
			}
			if (r3_btnAcucar1.activeInHierarchy == false) {
				r3_acucar1.SetActive (true);
			}
			if (r3_btnManteiga1.activeInHierarchy == false) {
				r3_manteiga1.SetActive (true);
			}
			if (r3_btnLeite.activeInHierarchy == false) {
				r3_leite.SetActive (true);
			}

			if (r3_btnChocolate1.activeInHierarchy == false && r3_btnFarinha.activeInHierarchy == false &&
			    r3_btnOvo.activeInHierarchy == false && r3_btnFermento.activeInHierarchy == false &&
			    r3_btnAcucar1.activeInHierarchy == false && r3_btnManteiga1.activeInHierarchy == false &&
			    r3_btnLeite.activeInHierarchy == false) {
				r3_btnMix.SetActive (true);
			}
		} 

		if (r3_bolo2.activeInHierarchy == true) {
			if (r3_btnChocolate2.activeInHierarchy == false) {
				r3_chocolate2.SetActive (true);
			}
			if (r3_btnAcucar2.activeInHierarchy == false) {
				r3_acucar2.SetActive (true);
			}
			if (r3_btnManteiga2.activeInHierarchy == false) {
				r3_manteiga2.SetActive (true);
			}
			if (r3_btnCreme.activeInHierarchy == false) {
				r3_creme1.SetActive (true);
			}

			if (r3_btnChocolate2.activeInHierarchy == false && r3_btnAcucar2.activeInHierarchy == false &&
			    r3_btnManteiga2.activeInHierarchy == false && r3_btnCreme.activeInHierarchy == false) {
				flagEtapa5_R3 = true;
			}
		}
	}

	public void MisturarIngredientes_R3 ()
	{
		flagEtapa1_R3 = true;
		r3_btnMix.SetActive (false);
		r3_ovos.SetActive (false);
		r3_chocolate1.SetActive (false);
		r3_manteiga1.SetActive (false);
		r3_farinha.SetActive (false);
		r3_acucar1.SetActive (false);
		r3_leite.SetActive (false);
		r3_fermento.SetActive (false);
		r3_massaBolo1.SetActive (true);

		StartCoroutine (CheersR3 (1));
	}

	public void PegarMesa_R3 ()
	{
		if (r3_massaBolo1.activeInHierarchy == true) {
			r3_massaBolo1.SetActive (false);
			flagEtapa2_R3 = true;
		}
		if (flagEtapa3_R3) {
			r3_bolo1.SetActive (false);
			r3_bolo2.SetActive (true);
			StartCoroutine (CheersR3 (2));
			flagEtapa3_R3 = false;
			flagEtapa4_R3 = true;
			LigarElementosCalda ();
		}
		if (r3_bolo2.activeInHierarchy == true && r3_chocolate2.activeInHierarchy == true &&
		    r3_acucar2.activeInHierarchy == true && r3_manteiga2.activeInHierarchy == true &&
		    r3_creme1.activeInHierarchy == true) {
			r3_chocolate2.SetActive (false);
			r3_acucar2.SetActive (false);
			r3_manteiga2.SetActive (false);
			r3_creme1.SetActive (false);
			flagEtapa5_R3 = true;
		}
		if (flagEtapa6_R3) {
			r3_panela2.SetActive (false);
			r3_calda.SetActive (true);
			r3_btnMix2.SetActive (true);
			tutorial.SetBoxFalse (2);
			tutorial.SetBoxFalse (5);
		}
	}

	public void LevarForno_R3 ()
	{
		if (flagEtapa2_R3) {
			r3_massaBolo2.SetActive (true);
			StartCoroutine (AssarBolo ());
		}
	}

	public IEnumerator AssarBolo ()
	{
		tutorial.SetBoxFalse (0);
		yield return new WaitForSecondsRealtime (3); 
		relogio2.SetActive (true);
		r3_massaBolo2.SetActive (false);
		yield return new WaitForSecondsRealtime (3);
		relogio2.SetActive (false);
		r3_bolo1.SetActive (true);
		flagEtapa2_R3 = false;
		flagEtapa3_R3 = true;
	}

	public void LigarElementosCalda ()
	{
		if (flagEtapa4_R3) {
			r3_btnChocolate2.SetActive (true);
			r3_btnAcucar2.SetActive (true);
			r3_btnManteiga2.SetActive (true);
			r3_btnCreme.SetActive (true);
		}
	}

	public void LevarFogao_R3 ()
	{
		if (flagEtapa5_R3) {
			r3_chocolate3.SetActive (true);
			r3_acucar3.SetActive (true);
			r3_manteiga3.SetActive (true);
			r3_creme2.SetActive (true);
			StartCoroutine (FazerCalda ());
		}
	}

	IEnumerator FazerCalda ()
	{
		tutorial.SetBoxFalse (1);
		yield return new WaitForSecondsRealtime (3);
		relogio3.SetActive (true);
		r3_chocolate3.SetActive (false);
		r3_acucar3.SetActive (false);
		r3_manteiga3.SetActive (false);
		r3_creme2.SetActive (false);
		yield return new WaitForSecondsRealtime (3);
		relogio3.SetActive (false);
		r3_panela1.SetActive (false);
		r3_panela2.SetActive (true);
		flagEtapa6_R3 = true;
	}

	public void TerminarReceita_R3 ()
	{
		r3_bolo2.SetActive (false);
		r3_calda.SetActive (false);
		r3_btnMix2.SetActive (false);
		r3_boloFinal.SetActive (true);
		StartCoroutine (CheersR3 (3));
	}

	IEnumerator CheersR3 (int num)
	{
		canvasCheers.SetActive (true);

		if (num == 1) {
			txtr3_1.SetActive (true);
			yield return new WaitForSecondsRealtime (3);
			canvasCheers.SetActive (false);
		} else if (num == 2) {
			txtr3_1.SetActive (false);
			txtr3_2.SetActive (true);
			yield return new WaitForSecondsRealtime (3);
			canvasCheers.SetActive (false);
		} else if (num == 3) {
			txtr3_2.SetActive (false);
			txtr3_3.SetActive (true);
			btnFim2.SetActive (true);
		}
	}

	#endregion
}
