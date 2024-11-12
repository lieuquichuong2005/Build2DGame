using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePrefab;
    public GameObject coinPrefab;
    public List<GameObject> platforms = new List<GameObject>();
    public List<GameObject> spikes = new List<GameObject>();
    public List<GameObject> coins = new List<GameObject>();

    public float spawnInterval = 0.4f; // Thời gian giữa các lần spawn
    private float elapsedTime = 0.0f; // Thời gian đã trôi qua
    private float speed = 10.0f; // Tốc độ di chuyển của các đối tượng

    System.Random rand = new System.Random(); // Khởi tạo ngẫu nhiên

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > spawnInterval)
        {
            SpawnPlatform();
            elapsedTime = 0.0f; // Reset thời gian
        }

        MovePlatforms();
        MoveSpikes();
        MoveCoins();
    }

    private void SpawnPlatform()
    {
        int randY = rand.Next(-4, 3);
        int randSize = rand.Next(5, 10);
        GameObject platform = Instantiate(platformPrefab);
        platform.GetComponent<SpriteRenderer>().size = new Vector2((float)randSize, 1.0f);
        var spriteSize = platform.GetComponent<SpriteRenderer>().size;
        platform.transform.position = new Vector3(10f + spriteSize.x / 2f, (float)randY, 0f);
        platform.GetComponent<BoxCollider2D>().size = new Vector2(spriteSize.x, 1.0f);
        platforms.Add(platform);

        // Spawn spikes
        if (rand.Next(-3, 4) > 0)
        {
            SpawnObject(spikePrefab, platform, randSize, 1f);
        }

        // Spawn coins
        if (rand.Next(-1, 2) > 0)
        {
            SpawnObject(coinPrefab, platform, randSize, 1f);
        }
    }

    private void SpawnObject(GameObject prefab, GameObject platform, int randSize, float offsetY)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.position = new Vector3(platform.transform.position.x + (float)rand.Next((-randSize + 1) / 2, (randSize - 1) / 2), platform.transform.position.y + offsetY, 0f);

        if (prefab == spikePrefab)
            spikes.Add(obj);
        else
            coins.Add(obj);
    }

    private void MovePlatforms()
    {
        foreach (GameObject p in platforms)
        {
            p.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        CheckAndDestroy(platforms);
    }

    private void MoveSpikes()
    {
        foreach (GameObject s in spikes)
        {
            s.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        CheckAndDestroy(spikes);
    }

    private void MoveCoins()
    {
        foreach (GameObject c in coins)
        {
            if (c != null)
            {
                c.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            }
        }
        CheckAndDestroy(coins);
    }

    private void CheckAndDestroy(List<GameObject> list)
    {
        if (list.Count > 0 && list[0] != null && list[0].transform.position.x < -10f)
        {
            Destroy(list[0]);
            list.RemoveAt(0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision: " + collision.gameObject.tag);
        Debug.Log("Collider: " + collision.collider.gameObject.tag);
    }
}