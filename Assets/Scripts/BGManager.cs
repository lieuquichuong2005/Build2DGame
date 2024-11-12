using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    public GameObject BG1;
    public GameObject BG2;
    // Start is called before the first frame update
    void Start()
    {
        BG1.transform.position = new Vector3(0f, 0f, 0f);
        BG2.transform.position = new Vector3(17.5f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        BG1.transform.position += new Vector3(-1f, 0f, 0f) * 5f * Time.deltaTime;
        BG2.transform.position += new Vector3(-1f, 0f, 0f) * 5f * Time.deltaTime;

        if (BG1.transform.position.x < -17.5f)
        {
            BG1.transform.position = new Vector3(17.5f, 0f, 0f);
        }

        if (BG2.transform.position.x < -17.5f)
        {
            BG2.transform.position = new Vector3(17.5f, 0f, 0f);
        }
    }
}
