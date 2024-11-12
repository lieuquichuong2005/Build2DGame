using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformReadyManager : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    // Start is called before the first frame update
    void Start()
    {
        P1.transform.position = new Vector3(0f, -4.5f, 0f);
        P2.transform.position = new Vector3(20f, -4.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        P1.transform.position += new Vector3(-1f, 0f, 0f) * 10f * Time.deltaTime;
        P2.transform.position += new Vector3(-1f, 0f, 0f) * 10f * Time.deltaTime;

        if (P1.transform.position.x < -20f)
        {
            P1.transform.position = new Vector3(20f, -4.5f, 0f);
        }
        if (P2.transform.position.x < -20f)
        {
            P2.transform.position = new Vector3(20f, -4.5f, 0f);
        }
    }
}
