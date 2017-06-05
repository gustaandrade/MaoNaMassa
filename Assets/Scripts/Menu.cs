using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

	public string Tutorial;
	public string Creditos;
	public string Receitas;

	public void NewGame ()
	{
		SceneManager.LoadScene (Tutorial);
	}

	public void Receita ()
	{
		SceneManager.LoadScene (Receitas);
	}

	public void CreditsScene ()
	{
		SceneManager.LoadScene (Creditos);
	}

	public void Voltar ()
	{
		SceneManager.LoadScene (1);
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}
}