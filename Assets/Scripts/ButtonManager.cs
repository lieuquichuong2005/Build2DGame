
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

	public Button playButton;
	//public Button howToPlayButton;
	public Button setingButton;
	public Button quitButton;
	public Button closeButton;

	public GameObject settingPanel;
	//public GameObject howToPlayPanel;

	

	void Start()
	{
		playButton.onClick.AddListener(PlayButton);
		//howToPlayButton.onClick.AddListener(HowToPlayButton);
		setingButton.onClick.AddListener(SettingButton);
		quitButton.onClick.AddListener(QuitButton);
		closeButton.onClick.AddListener(CloseButton);
	}

	void PlayButton()
	{
		SettingManager.instance.PlayClickSound();
		SceneManager.LoadScene("MainGame");
	}

	/*void HowToPlayButton()
	{
        SettingManager.instance.PlayClickSound();
        howToPlayPanel.gameObject.SetActive(true);
		closeButton.gameObject.SetActive(true);

	}*/
	void SettingButton()
	{
        SettingManager.instance.PlayClickSound();
        settingPanel.gameObject.SetActive(true);
		closeButton.gameObject.SetActive(true);
	}
	void QuitButton()
	{
        SettingManager.instance.PlayClickSound();
        Application.Quit();
	}
	void CloseButton()
	{
        SettingManager.instance.PlayClickSound();
        settingPanel.gameObject.SetActive(false);
		//howToPlayPanel.gameObject.SetActive(false);
		closeButton.gameObject.SetActive(false);
	}
}
