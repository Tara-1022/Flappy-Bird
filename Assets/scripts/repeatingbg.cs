using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatingbg : MonoBehaviour
{
    private BoxCollider2D groundcollider;//ref to box s=coll of ground
    private float groundhorizontallength;//length of ground;pos to be put at next

   
    void Start()
    {
        groundcollider = GetComponent<BoxCollider2D>();
        groundhorizontallength = groundcollider.size.x;
    }

   
    void Update()
    {
        //is it time to repos?has obj scrolled out of view
        if (transform.position.x < -groundhorizontallength)//cam looks at 0; if an obj is scrolled to full length, time to repos; check if x pos is less than its length
        {
            ReposBg();
        }
    }
    //funct to repostion bg
    private void ReposBg()
    {
        Vector2 groundoffset = new Vector2(groundhorizontallength * 2, 0);//how far to ove ground when repositioning
        transform.position = (Vector2)transform.position + groundoffset;//changing pos of obj

    }
}
