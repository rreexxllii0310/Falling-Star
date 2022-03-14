using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPinkController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platformPink;
    void Start()
    {
        InvokeRepeating("appear", 5, 10);
        InvokeRepeating("disappear", (float)0.3, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void disappear()
    {
        platformPink.SetActive(false);
    }

    private void appear()
    {
        platformPink.SetActive(true);
    }
}
