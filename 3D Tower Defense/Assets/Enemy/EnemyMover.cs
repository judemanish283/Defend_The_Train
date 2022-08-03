using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [Range(0f,5f)][SerializeField] float speed = 1;

    Enemy enemy;
    

    // Start is called before the first frame update
    void OnEnable()
    {
       FindPath();
       ReturnToStart(); 
       StartCoroutine(FollowPath());   
    }

    void Start() 
    {
        enemy = GetComponent<Enemy>();    
    }

    void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach(GameObject child in parent.transform) 
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if(!waypoint)
            {
                path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.StealGold();
    }


    IEnumerator FollowPath()
    {
        
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPos);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent); 
                yield return new WaitForEndOfFrame();
            }   
        }
        FinishPath();      
    }
}
