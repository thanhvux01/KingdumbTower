using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField][Range(0f, 5f)] float speed = 1f;
    Enemy enemy;

    OrderPathfinder orderPathfinder;
    // Start is called before the first frame update


    void OnEnable()
    {

        GetPath();
        ReturnToStart();
        StartCoroutine(FollowPath());

    }


    void GetPath()
    {
        orderPathfinder = FindObjectOfType<OrderPathfinder>();
        path = orderPathfinder.Path;

    }

    //Set set the location of enemy in first item in list
    private void ReturnToStart()
    {

        transform.position = new Vector3(path[0].transform.position.x, 0, path[0].transform.position.z);
    }
    void FinishPath()
    {
        enemy = GetComponent<Enemy>();
        enemy.GoldPenalty();
    }
    IEnumerator FollowPath()
    {

        foreach (Tile waypoint in path)
        {

            Vector3 startPosition = transform.position;
            Vector3 endPosition = new Vector3(waypoint.transform.position.x, 0, waypoint.transform.position.z);
            float travelPercent = 0f;
            transform.LookAt(endPosition);
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }

        FinishPath();
        gameObject.SetActive(false);
    }

}