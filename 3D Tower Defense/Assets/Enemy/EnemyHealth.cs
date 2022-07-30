using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxhitpoints = 5;
    [SerializeField] int currentHitPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
       currentHitPoints = maxhitpoints;
    }

    private void OnParticleCollision(GameObject other) 
    {
        
         ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints--;
         if(currentHitPoints <= 0)
         {
            Death();
         }
    }

    void Death()
    {
        
        Destroy(gameObject);
    }
}
