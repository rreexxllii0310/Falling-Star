using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public PlayerController playercontroller;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "platform" || collision.gameObject.tag == "platformP")
        {
            playercontroller.isjump = false;
            playercontroller.animator.SetInteger("Status", 0);
            // Debug.Log(collision.gameObject.name);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "platform" || collision.gameObject.tag == "platformP")
        {
            playercontroller.isjump = true;
            playercontroller.animator.SetInteger("Status", 2);
        }

    }
}