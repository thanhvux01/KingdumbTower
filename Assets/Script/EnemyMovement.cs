using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;


[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField][Range(0f, 5f)] float speed = 1f;

    [SerializeField] float attackRange = 3f;

    [SerializeField] float attackDamage = 10f;

    float distanceToTarget = Mathf.Infinity;

    Barricades barricades;

    Barricade target;
    NavMeshAgent navMeshAgent;
    int checkpoint;
    Animator animator;
    Enemy enemy;
    OrderPathfinder orderPathfinder;
    // Start is called before the first frame update
    private void Awake()
    {
        orderPathfinder = FindObjectOfType<OrderPathfinder>();
        barricades = FindObjectOfType<Barricades>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = barricades.GetLastestBarricade();
        animator = GetComponent<Animator>();

    }

    void OnEnable()
    {
        if (navMeshAgent)
        {
            navMeshAgent.enabled = false;
        }
        animator.SetBool("Move", true);
        StopAllCoroutines();
        GetPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void TriggerAttack(Barricade barricade)
    {
        if (animator != null && target != null && target.gameObject.activeSelf) 
        {   
            
            barricade.GetDamage(attackDamage);
            animator.SetBool("Move", false);
            animator.SetBool("Attack", true);
        }
    }
    void GetPath()
    {
        path = orderPathfinder.Path;

    }
    public void ResetEnemies()
    {

        StopAllCoroutines();

        if (animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", false);
        }
        animator.SetBool("Move", true);
        navMeshAgent.enabled = false;
        target = barricades.GetLastestBarricade();
        StartCoroutine(FollowPath());
        

    }

    //Set set the location of enemy in first item in list
    private void ReturnToStart()
    {
        if (checkpoint == 0)
        {
            if (path.Count > 0)
                transform.position = new Vector3(path[0].transform.position.x, 0, path[0].transform.position.z);
        }

    }
    void FinishPath()
    {
        enemy = GetComponent<Enemy>();
        enemy.GoldPenalty();

    }

    void EnableNavMesh()
    {
        if (navMeshAgent != null && target != null && target.gameObject.activeSelf)
        {
            if (navMeshAgent.enabled == false)
            {
                navMeshAgent.enabled = true;
                navMeshAgent.SetDestination(target.transform.position);
            }
        }
    }

    public IEnumerator FollowPath()
    {

        int indexPath = 0;
        //Make a copy of path in case changing the collection
        List<Tile> copyPath = new List<Tile>(path);
        foreach (Tile tile in copyPath)
        {
            indexPath++;
           
            if (checkpoint == 0 || checkpoint < indexPath)
            {   
                Vector3 startPosition = transform.position;
                Vector3 endPosition = new Vector3(tile.transform.position.x, 0, tile.transform.position.z);
                float travelPercent = 0f;
                transform.LookAt(endPosition);  
                while (travelPercent < 1f)
                {
                    travelPercent += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
            }

        }
        checkpoint = indexPath;
        if (barricades.TotalBarricade == 0)
        {

            FinishPath();

        }
        else
        {
            EnableNavMesh();
            StartCoroutine(AttackTarget());
        }
    }

    IEnumerator AttackTarget()
    {
        while (target != null && target.gameObject.activeSelf)
        {   
            distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        
            if (distanceToTarget < attackRange)
            {
                TriggerAttack(target);
            }
            yield return new WaitForSeconds(1f);
        }
    }

}