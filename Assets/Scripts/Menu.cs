using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void CloseGame()
	{
		Application.Quit();
		UnityEditor.EditorApplication.isPlaying = false;
	}
	
	public void StartGame()
	{
		SceneManager.LoadScene(sceneBuildIndex: 1);
	}
}
