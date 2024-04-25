using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LogNumber());
    }

    IEnumerator LogNumber() {
        for (int i = 0;i<10;i++){
            if(i > 0){
                Debug.Log(i);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
