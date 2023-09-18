using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    //creating object pool to recyle objects instead of spawning and destroyin(leads to memory space issue
    private float TimeSinceLastSpawned;
    public float SpawnRate = 4f;

    private GameObject[] columns;//creates an array
    public int columnpoolsize = 5;//size of array

    public float colMin = -2f;//to generate pos
    public float colMax = 2f;

    public float spawnXpos = 10f;//pos offscreen
    private int CurrCol = 0;//keep track of column used

    public GameObject columnprefab;//to instantiate column at beginning of game
    private Vector2 ObjectPoolPos = new Vector2(-15f, -25f);//offscreen pos;stuff spawned initially there

    
    void Start()
    {
         columns = new GameObject[columnpoolsize];//creates array with size 5

            for (int i = 0; i < columnpoolsize; i++)//loop through array
            {
                //for each slot in index
                //instantiate, cast to gameobj,store in array
                columns[i] = (GameObject)Instantiate(columnprefab, ObjectPoolPos, Quaternion.identity);//thing to instantiate, pos to inst at, use qu.id to use rotation of prefab
            
            }

    }

    void Update()//set up a timer to check if time to repos column
    {     
         TimeSinceLastSpawned += Time.deltaTime;//time it took to render last frame
         
        if (GameControl.instance.gameover==false && TimeSinceLastSpawned >= SpawnRate)//if game not over and timesince last spawned is more than certain no.;time to spawn?
        {
            TimeSinceLastSpawned = 0f;//setting timer at 0

            float spawnYpos = Random.Range(colMin, colMax);//x fixed //generate random vertical offsets

            columns[CurrCol].transform.position = new Vector2(spawnXpos, spawnYpos);//positioning column
            CurrCol++;//move to next col

            if (CurrCol >= columnpoolsize)
            {
                CurrCol = 0;
            }
        }
     
    }

}
