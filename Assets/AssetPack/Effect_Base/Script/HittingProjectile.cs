using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HittingProjectile : MonoBehaviour
{

    [SerializeField] GameObject hittingVFX;
    GameObject hittingVFXInstance;
    private void OnCollisionEnter(Collision other) {

       
        ContactPoint contact = other.GetContact(0);
        Vector3 collisionPoint = contact.point;
        hittingVFXInstance = Instantiate(hittingVFX,collisionPoint+new Vector3(0,0,-1),Quaternion.identity);
        Destroy(gameObject);
  
    }
 
}
