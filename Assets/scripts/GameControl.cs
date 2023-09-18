using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//allows us to change scenes
using UnityEngine.UI;//to be able to display score

public class GameControl : MonoBehaviour
{
    private int score = 0;
    public Text scoretext;

    public static GameControl instance;//associate with class allowing easy access from other sripts
    public GameObject gameovertext;
    public bool gameover = false;
    public float scrollspeed = -1.5f;//easy to access siince the instance is statics

    private void Awake()//before start set up gamecontrol before anything else
    {//set up singleton pattern-only one instance can run at a time
        if (instance == null)
        {
            instance = this;//sets this as the instance
        }
        else if (instance != this)//an instance exists but not this one
        {
            Destroy(gameObject);//destroys itself
        }
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        //check to see if gameover; if someone flaps, restart
        if (gameover==true && Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//reloads currently active scene
        }
        
    }
    public void BirdScored()
    {//don't score if gameover
        if (gameover)
        {
            return;
        }
        score++;
        scoretext.text = "Score : " + score.ToString();//changes text in field
    }

    public void BirdDied()
    {
        gameovertext.SetActive(true);
        gameover = true;

    }
}
