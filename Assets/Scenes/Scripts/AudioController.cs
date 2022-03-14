using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip change;
    AudioSource audiosource;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = 0;
        InvokeRepeating("playaudio", 4, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void playaudio()
    {
        audiosource.volume = 1;
        audiosource.PlayOneShot(change);
    }
}
