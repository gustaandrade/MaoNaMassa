using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialControl : MonoBehaviour
{
	public DialogControl dc;
	public Button btn;
	public PlayerController pc;

	public BoxCollider2D forno;
	public BoxCollider2D fogao;
	public BoxCollider2D mesaVovo;
	public BoxCollider2D armario;
	public BoxCollider2D geladeira;
	public BoxCollider2D pia;
	public BoxCollider2D mesaNeta;

	public bool flagMover1;
	public bool flagMover2;

	private int proximoBox1;
	private int proximoBox2;

	public GameObject btnMix;

	public SpriteRenderer cursorFogao;
	public SpriteRenderer cursorGeladeira;
	public SpriteRenderer cursorArmario;
	public SpriteRenderer cursorMesaVo;
	public SpriteRenderer cursorMesaNeta;

	private bool flagBoxes = false;

	void Update ()
	{
		if (SceneManager.GetActiveScene ().buildIndex == 2) {
			if (dc.GetCount () == GameConstants.PASSO1_TUTORIAL) {
				geladeira.enabled = true;
				cursorGeladeira.enabled = true;
				DefinirProximoDestino2 (GameConstants.VALOR_MESANETA);
				TestFlags (geladeira);
			} else if (dc.GetCount () == GameConstants.PASSO2_TUTORIAL) {
				cursorGeladeira.enabled = false;
				mesaNeta.enabled = true;
				cursorMesaNeta.enabled = true;
				DefinirProximoDestino2 (GameConstants.VALOR_ARMARIO);
				TestFlags (mesaNeta);
			} else if (dc.GetCount () == GameConstants.PASSO3_TUTORIAL) {
				cursorMesaNeta.enabled = false;
				mesaVovo.enabled = true;
				cursorMesaVo.enabled = true;
				DefinirProximoDestino1 (GameConstants.VALOR_FOGAO);
				TestFlags (mesaVovo);
			} else if (dc.GetCount () == GameConstants.PASSO4_TUTORIAL) {
				cursorMesaVo.enabled = false;
				fogao.enabled = true;
				cursorFogao.enabled = true;
				DefinirProximoDestino1 (GameConstants.VALOR_FOGAO);
				TestFlags (fogao);
			} else if (dc.GetCount () == GameConstants.PASSO5_TUTORIAL) {
				cursorFogao.enabled = false;
				armario.enabled = true;
				cursorArmario.enabled = true;
				DefinirProximoDestino2 (GameConstants.VALOR_MESANETA);
				TestFlags (armario);
			} else if (dc.GetCount () == GameConstants.PASSO6_TUTORIAL) {
				cursorArmario.enabled = false;
				mesaNeta.enabled = true;
				cursorMesaNeta.enabled = true;
				DefinirProximoDestino2 (GameConstants.VALOR_GELADEIRA);
				TestFlags (mesaNeta);
			} else if (dc.GetCount () == GameConstants.PASSO7_TUTORIAL) {
				cursorMesaNeta.enabled = false;
				fogao.enabled = true;
				cursorFogao.enabled = true;
				DefinirProximoDestino1 (GameConstants.VALOR_MESAVOVO);
				TestFlags (fogao);
			} else if (dc.GetCount () == GameConstants.PASSO8_TUTORIAL) {
				cursorFogao.enabled = false;
				mesaVovo.enabled = true;
				cursorMesaVo.enabled = true;
				DefinirProximoDestino1 (GameConstants.VALOR_MESAVOVO);
				TestFlags (mesaVovo);
			} else if (dc.GetCount () == GameConstants.PASSO9_TUTORIAL) {
				cursorMesaVo.enabled = false;
				geladeira.enabled = true;
				cursorGeladeira.enabled = true;
				DefinirProximoDestino2 (GameConstants.VALOR_MESANETA);
				TestFlags (geladeira);
			} else if (dc.GetCount () == GameConstants.PASSO10_TUTORIAL) {
				cursorGeladeira.enabled = false;
				mesaNeta.enabled = true;
				cursorMesaNeta.enabled = true;
				DefinirProximoDestino2 (GameConstants.VALOR_MESANETA);
				TestFlags (mesaNeta);
			} else if (dc.GetCount () == GameConstants.PASSO12_TUTORIAL) {
				cursorMesaNeta.enabled = false;
				geladeira.enabled = true;
				cursorGeladeira.enabled = true;
				TestFlags (geladeira);
			} else if (dc.GetCount () == GameConstants.PASSO36_TUTORIAL) {
				cursorGeladeira.enabled = false;
			}
		}
	}

	public void TestFlags (BoxCollider2D box)
	{
		if (SceneManager.GetActiveScene ().buildIndex == 2) {
			if (flagMover1) { 
				dc.SetCount ();
				btn.interactable = true;
				flagMover1 = false;	
				DeactivateObject (box);
			} else if (flagMover2) {
				dc.SetCount ();
				btn.interactable = true;
				flagMover2 = false;	
				DeactivateObject (box);
			}
		}
	}

	public void SetFlagMover1 ()
	{
		flagMover1 = true;
	}

	public void SetFlagMover2 ()
	{
		flagMover2 = true;
	}

	public void DeactivateObject (BoxCollider2D box)
	{
		box.enabled = false;
	}

	public void DefinirProximoDestino1 (int num1)
	{
		proximoBox1 = num1;
	}

	public void DefinirProximoDestino2 (int num2)
	{
		proximoBox2 = num2;
	}

	public int MandarPosicaoBox1 ()
	{
		return proximoBox1;
	}

	public int MandarPosicaoBox2 ()
	{
		return proximoBox2;
	}

	public void SetAllBoxesTrue ()
	{
		if (!flagBoxes) {
			forno.enabled = true;
			fogao.enabled = true;
			mesaVovo.enabled = true;
			armario.enabled = true;
			geladeira.enabled = true;
			mesaNeta.enabled = true;

			flagBoxes = true;
		}
	}

	public void SetBoxFalse (int num)
	{
		if (num == 0) {
			forno.enabled = false;
		} else if (num == 1) {
			fogao.enabled = false;
		} else if (num == 2) {
			mesaVovo.enabled = false;
		} else if (num == 3) {
			armario.enabled = false;
		} else if (num == 4) {
			geladeira.enabled = false;
		} else if (num == 5) {
			mesaNeta.enabled = false;
		}
	}
}