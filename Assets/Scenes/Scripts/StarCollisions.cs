using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollisions : MonoBehaviour
{
    public PlayerController playercontroller;
   // public AudioSource SE;

    private void OnTriggerEnter2D(Collider2D collision){
       // SE=this.GetComponent<AudioSource>();
        //SE.Play();
        if (collision.gameObject.tag == "player")
        {
            playercontroller.starImages[playercontroller.CurrentStar].SetActive(true);
            playercontroller.CurrentStar++;
            Destroy(this.gameObject);
        }
    }
}
