using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isdead=false;
    private Rigidbody2D rb2d;
    public float upforce = 200f;
    private Animator anim;

   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {//don't allow control if bird dies
        if (isdead==false)
        {
            if (Input.GetMouseButtonDown(0))//if button clicked
            {
                rb2d.velocity = Vector2.zero;//reset velocity to zero at every click for cartoony motion
                rb2d.AddForce(new Vector2(0,upforce));//x=0 since player does not move horizontally
                anim.SetTrigger("Flap");//animation trigger 'flap'
            }
        }
    }

    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;//zero vel so he falls w/o moving horizontally
        isdead = true;
        anim.SetTrigger("Die");//sets animation trigger to 'die'
        GameControl.instance.BirdDied();//access the function
    }
}
