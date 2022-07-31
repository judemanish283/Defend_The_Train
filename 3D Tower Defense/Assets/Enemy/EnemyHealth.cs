using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxhitpoints = 5;
    [SerializeField] int currentHitPoints = 0;
    
    Enemy enemy;
    
    void OnEnable()
    {
       currentHitPoints = 0;
    }

    private void Start() 
    {
        enemy = GetComponent<Enemy>();    
    }

    private void OnParticleCollision(GameObject other) 
    {
        
         ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints++;
         if(currentHitPoints >= maxhitpoints)
         {
            gameObject.SetActive(false);
            enemy.RewardGold();
         }
    }

   
}
