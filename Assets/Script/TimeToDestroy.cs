using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float time; 

    void Start()
    {
        Invoke("Destroy2",5f);
    }

    private void Destroy2() {
         Destroy(gameObject);
    }   
}
