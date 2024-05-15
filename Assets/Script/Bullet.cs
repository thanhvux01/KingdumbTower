using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
        StartCoroutine(Position());
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);

    }
      IEnumerator Position()
    {
        yield return new WaitForSeconds(0.25f);
        Debug.Log("Vi tri 0.25s"+gameObject.transform.position);

    }

}
