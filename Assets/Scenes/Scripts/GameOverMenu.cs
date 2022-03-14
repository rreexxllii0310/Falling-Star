using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    SpriteRenderer TryAgain;
    SpriteRenderer Easy;
    SpriteRenderer Menu;
    AudioSource SE;

    int keyIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        TryAgain = GameObject.Find("btnAgain").GetComponent<SpriteRenderer>();
        Easy = GameObject.Find("btnEasy").GetComponent<SpriteRenderer>();
        Menu = GameObject.Find("btnMenu").GetComponent<SpriteRenderer>();
        SE = GameObject.Find("AudioSource").GetComponent<AudioSource>();

        TryAgain.color = new Color(1,1,1,1);
        Easy.color = new Color(1,1,1,0.2f);
        Menu.color = new Color(1,1,1,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            keyIndex++;
            SE.Play();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            keyIndex--;
            SE.Play();
        }

        if (keyIndex%3 == 0){
            if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene("SampleScene");
            }
            TryAgain.color = new Color(1,1,1,1);
            Easy.color = new Color(1,1,1,0.2f);
            Menu.color = new Color(1,1,1,0.2f);
        }
        else if (keyIndex%3 == 1){
            if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown(KeyCode.Space)){
                easyFlag.easyMode =true;
                SceneManager.LoadScene("SampleScene");
            }
            TryAgain.color = new Color(1,1,1,0.2f);
            Easy.color = new Color(1,1,1,1);
            Menu.color = new Color(1,1,1,0.2f);
        }
        else {
            if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene("menu");
            }
            TryAgain.color = new Color(1,1,1,0.2f);
            Easy.color = new Color(1,1,1,0.2f);
            Menu.color = new Color(1,1,1,1);
        }
    }
}
