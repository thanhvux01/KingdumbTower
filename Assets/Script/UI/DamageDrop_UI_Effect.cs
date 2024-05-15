using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageDrop : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMesh;

    [SerializeField] float yMoveSpeed = 10f;
    [SerializeField] float textDisappearSpeed = 3f;
    [SerializeField] float textDisappearTimer = 1f;
    Color color;
    void Start()
    {   
        textMesh = GetComponent<TextMeshProUGUI>();
        color = textMesh.color;
    }

    // Update is called once per frame
    void Update()
    {   
        //move text up
        transform.position += new Vector3(0,yMoveSpeed) * Time.deltaTime;
        textDisappearTimer -= Time.deltaTime;
        if (textDisappearTimer <= 0)
        {
            //reduce opacity
            color.a -= textDisappearSpeed * Time.deltaTime;
            textMesh.color = color;
            if (textMesh.color.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
