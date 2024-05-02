using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] float range = 15f;
     Transform target;
    
    private void Start() {


    }
    private void Update() {
        FindClosestTarget();
        Aiming();
    }

    private void FindClosestTarget() {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;
        foreach(Enemy enemy in enemies) {
            float targetDistance = Vector3.Distance(transform.position,enemy.transform.position);
            if(targetDistance < maxDistance) {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
          
        }
        target = closestTarget;
    }
    private void Aiming() {

           if (target != null) {
            float targetDistance = Vector3.Distance(transform.position, target.transform.position);
            weapon.LookAt(target.transform.position);

            if (targetDistance < range) {
                Attack(true);
            }
            else {
                 Attack(false);
            }
        }



    }

    private void Attack(bool isActive) {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }


}
