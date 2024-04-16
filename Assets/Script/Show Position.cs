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
        Instantiate(Tree,transform.position+new Vector3(0,2,0),Quaternion.identity);
        count.totalTree++;
        Debug.Log(count.totalTree);
    }
}
