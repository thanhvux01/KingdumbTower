using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float time; 

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    IEnumerator SelfDestruct () {
         yield return new WaitForSeconds(time);
         Destroy(gameObject);
    }
   
}
