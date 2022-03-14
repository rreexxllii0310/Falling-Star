using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBlueController : MonoBehaviour
{
    public GameObject platformBlue;
    void Start()
    {
        InvokeRepeating("appear", 0, 10);
        InvokeRepeating("disappear", (float)5.3, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void disappear()
    {
        platformBlue.SetActive(false);
    }

    private void appear()
    {
        platformBlue.SetActive(true);
    }
}
