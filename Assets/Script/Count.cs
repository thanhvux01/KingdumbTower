using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text text;
    public float totalTree;

    public float totalVegetable = 0;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Update() {

         text.SetText("Trees:"+totalTree);
    }



}
