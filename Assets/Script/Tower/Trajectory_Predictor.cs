using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Trajectory_Predictor : MonoBehaviour

{
    [SerializeField] int loopTime = 50;

    [SerializeField] GameObject shadowObject;

    [Tooltip("time unit")]
    readonly float increment = 0.025f;

    [Tooltip("Tuning range raycast")]
    readonly float rayOverlap = 1.1f;
    

    public float Predict(float force, float maxForce, Rigidbody projectile, Transform initialPoint)
    {
       
        bool hitEnemy = false;
        while (!hitEnemy || force < maxForce)
        {
            
            Vector3 accelerate = initialPoint.forward * (force / projectile.mass);
            Vector3 position = initialPoint.position;
            Vector3 nextPosition;
            float overlap;
            for (int i = 0; i < loopTime; i++)
            {
                
                accelerate = CalculateNewAccel(accelerate, projectile.drag, increment);
                nextPosition = position + accelerate * increment;
                overlap = Vector3.Distance(position, nextPosition) * rayOverlap;
                // Instantiate(shadowObject,nextPosition,Quaternion.identity); 
                if (Physics.Raycast(position, accelerate.normalized, out RaycastHit hit, overlap))
                {

                    if (hit.transform.gameObject.CompareTag("Enemy"))
                    {
                        hitEnemy = true;
                        return force;

                    }
                }
                position = nextPosition;

            }
            force++;
        }
        return 0;

    }

    private Vector3 CalculateNewAccel(Vector3 accel, float drag, float increment)
    {
        accel += Physics.gravity * increment;
        accel *= Mathf.Clamp01(1f - drag * increment);
        return accel;
    }



}
