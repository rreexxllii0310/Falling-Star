using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cutSceneIntro : MonoBehaviour
{
   int picIndex = 0;
    SpriteRenderer[] pics = new SpriteRenderer[4];
    GameObject[] picObj = new GameObject[4];
    AudioSource SE;
    bool fadeFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        picObj[0] = GameObject.Find("intro1");
        picObj[1] = GameObject.Find("intro2");
        picObj[2] = GameObject.Find("intro3");
        picObj[3] = GameObject.Find("intro4");

        SE = GetComponent<AudioSource>();

        picIndex = 0;

        for (int i =0; i<4; i+=1){
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
        if (pics[3].color.a == 0f)  SceneManager.LoadScene("SampleScene");
        else {
            Color tmp = pics[3].color;
            tmp.a = tmp.a - 0.0001f;
            pics[3].color = tmp;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && picIndex<4){
            picIndex += 1;
            Debug.Log(picIndex);
            SE.Play();
            for (int i =0; i<4; i+=1){
                pics[i].color = new Color(1,1,1,0f); //all black
            }
        }
        if (picIndex<4) fadeIn();
        else if (picIndex == 4 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))) fadeOut();
    }
}
