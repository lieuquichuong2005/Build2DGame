using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI CoinsTXT;
    public Button replayButton;
    public Button returnButton;
    // Start is called before the first frame update
    void Start()
    {
        int coin = Player.Instance.coin;
        CoinsTXT.text = coin.ToString();

        replayButton.onClick.AddListener(Replay);
        returnButton.onClick.AddListener(Return);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Replay()
    {
        SceneManager.LoadScene("MainGame");
    }

    void Return()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
