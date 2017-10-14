using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void changeMenuScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

	public void SetGameMode(string gameMode)
	{
		PlayerPrefs.SetString ("game_mode", gameMode);
	}
}
