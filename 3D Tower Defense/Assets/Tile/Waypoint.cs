using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }
    
    private void  OnMouseDown() 
    {
        if(isPlaceable)
        {
            bool isPlaced = defenderPrefab.CreateDefender(defenderPrefab, transform.position);
            isPlaceable = !isPlaced;   
        }
    }

    
}    

    
