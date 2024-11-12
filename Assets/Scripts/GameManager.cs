using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlatformReady;
    public GameObject PlatformSpawner;
    // Start is called before the first frame update
    void Start()
    {
        PlatformReady.SetActive(true);
        PlatformSpawner.SetActive(false);

        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("Lives", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) && transform.position.y < 2.9)
        {
            PlatformReady.SetActive(false);
            PlatformSpawner.SetActive(true);
        }
    }
}
