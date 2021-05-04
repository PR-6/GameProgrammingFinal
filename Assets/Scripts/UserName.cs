using UnityEngine;
using UnityEngine.UI;

public class UserName : MonoBehaviour
{
	public Text userText;

	void Update()
	{
		userText.text = "Currently Playing: " + PlayerPrefs.GetString("PlayerName").ToString();
	}

}