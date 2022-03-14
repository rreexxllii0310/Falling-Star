using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endSceneCon : MonoBehaviour
{
    int picIndex = 0;
    SpriteRenderer[] pics = new SpriteRenderer[3];
    GameObject[] picObj = new GameObject[3];
    AudioSource SE;
    bool fadeFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        picObj[0] = GameObject.Find("end1");
        picObj[1] = GameObject.Find("end2");
        picObj[2] = GameObject.Find("end3");

        SE = GetComponent<AudioSource>();

        picIndex = 0;

        for (int i =0; i<3; i+=1){
            pics[i] = picObj[i].GetComponent<SpriteRenderer>();
            pics[i].color = new Color(1,1,1,0);
        }
        fadeIn();
        
    }

       void fadeIn (){
        if (pics[picIndex].color.a <= 1f){
            Color tmp = pics[picIndex].color;
            tmp.a = tmp.a + 0.05f;
           // Debug.Log
            pics[picIndex].color = tmp;
        }
    }

    void fadeOut (){
        if (pics[2].color.a == 0f)  SceneManager.LoadScene("menu");
        else {
            Color tmp = pics[2].color;
            tmp.a = tmp.a - 0.0001f;
            pics[2].color = tmp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && picIndex<3){
            picIndex += 1;
            Debug.Log(picIndex);
            SE.Play();
            for (int i =0; i<3; i+=1){
                pics[i].color = new Color(1,1,1,0f); //all black
            }
        }
        if (picIndex<3) fadeIn();
        else if (picIndex == 3 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))) fadeOut();
    }
    
}
