using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
	public Text scoreText;

	void Update()
	{
		scoreText.text = "Lives: " + PlayerPrefs.GetInt("LivesRemaining", 0).ToString();
	}

	public void IncreaseLives()
	{
		PlayerPrefs.SetInt("LivesRemaining", PlayerPrefs.GetInt("LivesRemaining", 0) + 1);
	}

	public void DecreaseLives()
	{
		PlayerPrefs.SetInt("LivesRemaining", PlayerPrefs.GetInt("LivesRemaining", 0) - 1);
	}
}
