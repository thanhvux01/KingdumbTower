using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisSpell : MonoBehaviour
{
    
    public float timeToDestroy = 5f;
    void Start()
    {
        StartCoroutine(SeftDestruct());
    }
    
       IEnumerator SeftDestruct ()
    {
        yield return new WaitForSeconds(timeToDestroy);
        
        Destroy(gameObject);
    }
   
  
}
