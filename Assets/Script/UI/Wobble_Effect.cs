using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Wobble_Effect : MonoBehaviour
{
    // Start is called before the first frame update
     TMP_Text textMesh;

    Mesh mesh;

    Vector3[] vertices;
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;
        for(int i = 0; i < vertices.Length;i++){
             Vector3 offset = Wobble(Time.time + i);
             vertices[i] = vertices[i] + offset;
        }   
        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }

    Vector2 Wobble(float time) {
        return new Vector2(Mathf.Sin(time*5.3f),Mathf.Cos(time*3.8f));
    }
}
