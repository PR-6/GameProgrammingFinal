using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;

	void Update ()
	{
		scoreText.text = "Points: " + PlayerPrefs.GetInt("Score").ToString();
	}

	public void IncreaseScore ()
    {
		PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + 1);
    }

	public void DecreaseScore ()
    {
		PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) - 1);
	}
}
