using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 1f;
    [SerializeField] int poolsize = 5;

    GameObject[] pool;

    // Start is called before the first frame update
    private void Awake() 
    {
        PopulatePool();    
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

     void PopulatePool()
    {
        pool = new GameObject[poolsize];

        for(int i=0; i< pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
       for(int i=0; i< pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        } 
    }

    // So now when the game starts the objects are created in the pool and when spawnenemies 
    // is called it activates the first object and then exits the loop and when the 
    // coroutine calls it again it calls the method once more.

    

   

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
          EnableObjectInPool();
          yield return new WaitForSeconds(spawnTimer);
        }
    }
 }
