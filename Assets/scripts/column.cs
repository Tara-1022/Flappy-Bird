using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class column : MonoBehaviour
{
    //to check if player passes column
    private void OnTriggerEnter2D(Collider2D other)//parameter named other to check what has collided
    {
        if (other.GetComponent<Bird>() != null)//check if bird passed through trigger;if has bird component
        {
            GameControl.instance.BirdScored();//calling birdscored function
        }
    }
}
