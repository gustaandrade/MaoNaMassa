using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour
{
	// Tags gerais
	public const string PLAYER_TAG = "Player";
	public const string LEVEL_TAG = "Level";
	public const string DIALOGO_TAG = "Dialogo";

	// Valores gerais
	public const float PLAYER_SPEED = 2.5F;

	// Valores de cena para o Tutorial
	public const int ANIM_LIVRO_ON = 4;
	public const int ANIM_LIVRO_OFF = 5;

	public const int PASSO1_TUTORIAL = 13;
	// Pegar água na geladeira
	public const int PASSO2_TUTORIAL = 18;
	// Levar água para mesa central da neta
	public const int PASSO3_TUTORIAL = 21;
	// Pegar água da mesa central da vovó
	public const int PASSO4_TUTORIAL = 22;
	// Levar a água para o fogão
	public const int PASSO5_TUTORIAL = 25;
	// Pegar gelatina no armário
	public const int PASSO6_TUTORIAL = 26;
	// Levar gelatina para mesa central da neta
	public const int PASSO7_TUTORIAL = 28;
	// Buscar água quente no fogão
	public const int PASSO8_TUTORIAL = 29;
	// Levar água quente para a mesa central da vovó
	public const int PASSO9_TUTORIAL = 30;
	// Buscar água fria da geladeira
	public const int PASSO10_TUTORIAL = 31;
	// Levar água fria para a mesa central da neta
	public const int PASSO11_TUTORIAL = 33;
	// Misturar ingredientes na mesa central
	public const int PASSO12_TUTORIAL = 35;
	// Levar gelatina para a geladeira
	public const int PASSO36_TUTORIAL = 36;
	// CursorDaGeladeiraFinal
	public const int PASSOFINAL_TUTORIAL = 40;
	// Último diálogo do tutorial

	public const int VALOR_FORNO = 0;
	public const int VALOR_FOGAO = 1;
	public const int VALOR_MESAVOVO = 2;
	public const int VALOR_ARMARIO = 3;
	public const int VALOR_GELADEIRA = 4;
	public const int VALOR_PIA = 5;
	public const int VALOR_MESANETA = 6;


	// Valores de cena para a Receita 2
	public const int COUNT_INICIO_RECEITA2 = 9;


	// Valores de cena para a Receita 3
	public const int COUNT_INICIO_RECEITA3 = 9;
}
