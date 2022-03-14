using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCon : MonoBehaviour
{
   GameObject StartBtn;
    GameObject ExitBtn;
    GameObject StartArrow;
    GameObject ExitArrow;
    bool selectFlag = true;

    SpriteRenderer EA_Ren;
    SpriteRenderer EB_Ren;
    SpriteRenderer SA_Ren;
    SpriteRenderer SB_Ren;

    AudioSource SE;
    // Start is called before the first frame update
    void Start()
    {
        SE = GetComponent<AudioSource>();
        StartBtn = GameObject.Find("start_btn");
        ExitBtn = GameObject.Find("exit_btn");
        StartArrow = GameObject.Find("arrow");
        ExitArrow = GameObject.Find("arrow2");

        SA_Ren = StartArrow.GetComponent<SpriteRenderer>();
        SB_Ren = StartBtn.GetComponent<SpriteRenderer>();
        EA_Ren = ExitArrow.GetComponent<SpriteRenderer>();
        EB_Ren= ExitBtn.GetComponent<SpriteRenderer>();

        SA_Ren.color = new Color(1,1,1,1);
        SB_Ren.color = new Color(1,1,1,1);
        EA_Ren.color = new Color(1,1,1,0);
        EB_Ren.color = new Color(1,1,1,0.25f);
        ///initialization
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            SE.Play();
            if (selectFlag == true) selectFlag = false;
            else selectFlag = true;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow)){
            SE.Play();
            if (selectFlag == true) selectFlag = false;
            else selectFlag = true;
        }

        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)){
            if (selectFlag == true){
                //turn to intro scene
                SceneManager.LoadScene("intro");
            }
            else if (selectFlag == false){
                //exit
                Application.Quit();
            }
        }
        
        if (selectFlag == true){
            SA_Ren.color = new Color(1,1,1,1);
            SB_Ren.color = new Color(1,1,1,1);
            EA_Ren.color = new Color(1,1,1,0);
            EB_Ren.color = new Color(1,1,1,0.25f);
        }
        else if (selectFlag == false){
            SA_Ren.color = new Color(1,1,1,0);
            SB_Ren.color = new Color(1,1,1,0.25f);
            EA_Ren.color = new Color(1,1,1,1);
            EB_Ren.color = new Color(1,1,1,1);
        }
    }
}
