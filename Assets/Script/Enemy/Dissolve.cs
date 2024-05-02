using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Material material;
     private float startTime;
    [SerializeField] GameObject renderObject;
    void DissolveEnemie()
    {
        if (material != null)
        {
            if (renderObject != null)
            {  
               renderObject.GetComponent<Renderer>().material = material;
               Material objectMat = renderObject.GetComponent<Renderer>().material;
               startTime = Time.time;
               objectMat.SetFloat("_StartTime",startTime);
            }
        }
    }
}
