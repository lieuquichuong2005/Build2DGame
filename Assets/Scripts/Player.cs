using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;

    Rigidbody2D rb;
    [SerializeField] int jumpPower;

    public Animator animator;
    bool isOnPlatform = false;
    //int coins = 0;

    public AudioSource audioJump;
    public AudioSource audioCoin;

    private int live = 3;
    public int coin = 0;

    public TextMeshProUGUI livesTXT;
    public TextMeshProUGUI coinsTXT;

    public TextMeshProUGUI highScore;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
        highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        coinsTXT.text = coin.ToString();
        livesTXT.text = live.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // PC version
        if ((Input.GetKey(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) && transform.position.y < 2.9)
        {
            audioJump.Play(0);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isOnPlatform = false;
        }

        animator.SetBool("isOnPlatform", isOnPlatform);

        if (transform.position.x < -10f || transform.position.y < -5.5f)
        {
            if (live > 1)
            {
                live--;
                livesTXT.text = live.ToString(); // Cập nhật số mạng
                transform.position = new Vector3(-5f, 6f, 0f);
                isOnPlatform = false;
            }
            else
            {
                DeadManager();
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            isOnPlatform = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            audioCoin.Play(0);
            coin++;
            coinsTXT.text = coin.ToString();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "spike")
        {
            if (live > 1)
            {
                live--;
                livesTXT.text = live.ToString(); // Cập nhật số mạng
                transform.position = new Vector3(-5f, 6f, 0f);
                isOnPlatform = false;
            }
            else
            {
                DeadManager();
            }
        }
    }
    void DeadManager()
    {
        int coinHigh = PlayerPrefs.GetInt("highScore");
        coinHigh = coin > coinHigh ? coin : coinHigh;
        PlayerPrefs.SetInt("highScore", coinHigh);
        SceneManager.LoadScene("GameOver");
    }
}
