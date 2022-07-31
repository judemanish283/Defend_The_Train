using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float attackRange = 15f;
    [SerializeField] ParticleSystem projectile;
    Transform target;

    

    private void Update() 
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;

    }

    void AimWeapon()
    {
        if(!target){return;}
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        weapon.LookAt(target);
        if(targetDistance < attackRange)
        {
            Attack(true); 
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isFiring)
    {
        var emmissionModule = projectile.emission;
        emmissionModule.enabled = isFiring;
    }

}
