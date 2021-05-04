using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Menus : MonoBehaviour
{
    //PlayerName:
    public InputField playerName;

    //Lives DropDown:
    List<string> playerLives = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    public Dropdown dropdown;

    //Slider:
    public Slider sliderUI;
    private Text textSliderValue;

    //Play Music:
    public GameObject playMusicToggle;
    public AudioSource audioSource;

    // Standard Functions:
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        PopulateList();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        textSliderValue = GetComponent<Text>();
        ShowSliderValue();
    }

    // PlayerName Logic:
    public void setPlayerName()
    {
        Debug.Log(playerName.text);
        PlayerPrefs.SetString("PlayerName", playerName.text);
    }

    //Dropdown lives Logic:
    public void DropDownIndexChanged(int index)
    {
        Debug.Log("Lives = " + playerLives[index]);
        PlayerPrefs.SetInt("LivesRemaining", int.Parse(playerLives[index]));
    }

    void PopulateList()
    {
        dropdown.AddOptions(playerLives);
    }

    //Slider Speed logic:
    public void ShowSliderValue()
    {
        string sliderMessage = "Time: " + sliderUI.value + " Seconds";
        textSliderValue.text = sliderMessage;
        PlayerPrefs.SetInt("Time", (int)sliderUI.value);
        Debug.Log("Timer Set to: " + sliderUI.value);
    }

    // Play Music
    public void SetPlayMusic()
    {
        Debug.Log(playMusicToggle.GetComponent<Toggle>().isOn);
        PlayerPrefs.SetInt("PlayMusic", playMusicToggle ? 1 : 0);
        toggleMusic(audioSource);
    }

    public void toggleMusic(AudioSource music)
    {
        music.mute = !music.mute;
    }

    public void LoadGame()
    {
        string text = System.IO.File.ReadAllText(Application.persistentDataPath + "/saveData.json");
        Debug.Log("Save Data: " + text);
        var json = JsonUtility.FromJson<PlayerPrefStore>(text);
        PlayerPrefs.SetInt("Score", json.Score);
        PlayerPrefs.SetString("PlayerName", json.PlayerName);
        PlayerPrefs.SetInt("LivesRemaining", json.LivesRemaining);
        PlayerPrefs.GetInt("PlayMusic", json.PlayMusic);
    }

    public int getCarSpeed()
    {
        return PlayerPrefs.GetInt("CarSpeed", 0);
    }
}
