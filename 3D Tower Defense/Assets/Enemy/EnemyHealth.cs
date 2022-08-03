using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxhitpoints = 5;
    
    [Tooltip("Adds amount to maxhitpoints when killed... Max 5")]
    [SerializeField] int difficultyRamp = 1;
    
    int currentHitPoints = 0;
    
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
            maxhitpoints += difficultyRamp;
            enemy.RewardGold();
         }
    }

   
}
