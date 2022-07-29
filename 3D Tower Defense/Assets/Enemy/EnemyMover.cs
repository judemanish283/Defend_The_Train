using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [Range(0f,5f)][SerializeField] float speed = 1;
    

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(FollowPath());   
    }

    IEnumerator FollowPath()
    {
        
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPos);

            while(travelPercent < 1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent); 
                yield return new WaitForEndOfFrame();
            }   
        }
        
    }
}
