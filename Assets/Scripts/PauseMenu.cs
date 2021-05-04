using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	public GameObject playButton;
	public GameObject restartButton;
	public GameObject saveButton;
	public GameObject loadGame;
	public GameObject musicToggle;
	public GameObject pauseCanvas;
	int livesRemaining;
	public AudioSource music;


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}

	public void Reload()
	{
		pauseControl();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void mainMenu()
	{
		pauseControl();
		SceneManager.LoadScene(0);
	}

	public void pauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
		}
	}

	public void showPaused()
	{
		pauseCanvas.gameObject.SetActive(true);
	}

	public void hidePaused()
	{
		pauseCanvas.gameObject.SetActive(false);

	}

	public void saveGame()
    {
		PlayerPrefStore newSave = new PlayerPrefStore();
		newSave.Score = PlayerPrefs.GetInt("Score");
		newSave.PlayerName = PlayerPrefs.GetString("PlayerName");
		newSave.LivesRemaining = PlayerPrefs.GetInt("LivesRemaining");
		//newSave.PlayMusic = PlayerPrefs.GetInt("PlayMusic")==1?true:false;
		newSave.PlayMusic = PlayerPrefs.GetInt("PlayMusic");

		string json = JsonUtility.ToJson(newSave);
		Debug.Log(json);
	}

	public void SaveIntoJson(string json)
	{
		System.IO.File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
	}

	public void SetPlayMusic()
	{
		Debug.Log(musicToggle.GetComponent<Toggle>().isOn);
		PlayerPrefs.SetInt("PlayMusic", musicToggle ? 1 : 0);
	}

	public void toggleMusic()
    {
		music.mute = !music.mute;
	}
}
