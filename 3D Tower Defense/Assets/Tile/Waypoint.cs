using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject defender;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }
    
    private void  OnMouseDown() 
    {
        if(isPlaceable)
        {
            GameObject defenderPrefab = Instantiate(defender, transform.position, Quaternion.identity);
            isPlaceable = false;   
        }
    }

    public bool GetIsPlaceable()
    {
        return isPlaceable;
    }
}    

    
