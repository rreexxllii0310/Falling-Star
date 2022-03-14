using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public PlayerController playercontroller;
    bool isopen = false;
    public bool dooropen = false;
    public SpriteRenderer sr;
    public Sprite[] doorSprite;

    void Update()
    {   
        dooropen = false;
        if(playercontroller.CurrentStar >= 5){
            sr.sprite = doorSprite[1];
            isopen = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "player" && isopen) //player在門附近，且門開了
        {
            // #TODO:  player按上可以切換場景
            dooropen = true;
            // Debug.Log(collision.gameObject.name);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("end");
        }

    }
}
