using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;
    Enemy enemy;
    // Start is called before the first frame update


    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
       
    }

    
    void FindPath() {


        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        
        foreach(Transform child in parent.transform) {

            Waypoint waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null) {
                path.Add(waypoint);
            }
          
        }
    }

    //Set set the location of enemy in first item in list
    private void ReturnToStart() {

        transform.position = new Vector3(path[0].transform.position.x, 0, path[0].transform.position.z);
    }
    void FinishPath() {
        enemy = GetComponent<Enemy>();
        enemy.GoldPenalty();
    }
    IEnumerator FollowPath() {

        foreach(Waypoint waypoint in path) {

            Vector3 startPosition = transform.position;
            Vector3 endPosition = new Vector3(waypoint.transform.position.x,0,waypoint.transform.position.z); 
            float travelPercent = 0f;
            transform.LookAt(endPosition);
            while(travelPercent < 1f) { 
             travelPercent += Time.deltaTime * speed ;
             transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
             yield return new WaitForEndOfFrame();
            }
          
        }

       FinishPath();
      gameObject.SetActive(false);
    }
   
}