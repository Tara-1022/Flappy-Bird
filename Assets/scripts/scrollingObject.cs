using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;

   
    void Start()
    {//to scroll bg
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.instance.scrollspeed,0);//taking scrollspeed;not move vertical
    }

  
    void Update()
    {
        //stop scroll when game over
        if (GameControl.instance.gameover == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
