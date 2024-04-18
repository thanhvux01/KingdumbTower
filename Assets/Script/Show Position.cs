using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPosition : MonoBehaviour
{
    // Start is called before the first frame update
  
    // Update is called once per frame
    [SerializeField] GameObject Tree;

    [SerializeField] Count count;

    void FixedUpdate()
    {   
      
    }

     private void OnMouseDown() {
        
        Debug.Log(transform.position);
    }
}
