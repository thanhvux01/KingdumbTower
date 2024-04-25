using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class OrderPathfinder : MonoBehaviour
{
    // Start is called before the first frame update
     List<Tile> path = new List<Tile>();

    public List<Tile> Path { get { return path; } }
    


    void Awake()
    {
        FindPath();
    }

    void OrderRemovedIndex()
    {
        float lowest;
        int removedIndex = 0;
        for (int i = 0; i < path.Count; i++)
        {
            if (i != 0)
            {
                path.RemoveAt(removedIndex);
            }
            lowest = path[i].transform.position.x;
            //    for(int j = 0;j< path.Count; j++) {
            //       if(path[i].transform.position.x > path[j].transform.position.x){

            //       }

            //    }
            for (int j = 0; j < path.Count; j++)
            {
                if (lowest > path[j].transform.position.x)
                {
                    lowest = path[j].transform.position.x;
                    removedIndex = j;
                }
            }
            // orderedPath.Add(lowest);
        }

    }
    void OrderReplaceX()
    {


        for (int i = 0; i < path.Count; i++)
        {

            for (int j = 0; j < path.Count; j++)
            {
                if (path[i].transform.position.x < path[j].transform.position.x)
                {

                    (path[j], path[i]) = (path[i], path[j]);

                }
            }

        }
    }
    void OrderReplaceY()
    {
        for (int i = 0; i < path.Count; i++)
        {
            for (int j = 0; j < path.Count; j++)
            {
                if (path[i].transform.position.x == path[j].transform.position.x)
                {

                    if (path[i].transform.position.z < path[j].transform.position.z)
                    {
                        (path[j], path[i]) = (path[i], path[j]);


                    }
                }
            }

        }
    }


    void TurnPath()
    {

        if (path.Count > 1) // Đảm bảo có đủ phần tử để so sánh
        {
            for (int i = 0; i < path.Count - 1; i++)
            {
                //loai bo diem xuat phat theo chieu doc
                if (path[i].transform.position.x == path[i + 1].transform.position.x)
                {


                    // Debug.Log(path[i].transform.position.x);
                    float turnPoint = path[i - 1].transform.position.z;
                    // Debug.Log(turnPoint);


                    if (turnPoint > path[i + 1].transform.position.z)
                    {

                        for (int j = i; j < path.Count; j++)
                        {

                            for (int k = j; k < path.Count; k++)
                            {

                                if (path[j].transform.position.x == path[i].transform.position.x && path[j].transform.position.x == path[k].transform.position.x)
                                {
                                    if (path[j].transform.position.z < path[k].transform.position.z)
                                    {

                                        (path[j], path[k]) = (path[k], path[j]);

                                    }
                                }
                            }
                        }

                    }

                }
            }
        }
    }
    void RemoveAfterBarricade()
    {    
        for (int i = 0; i < path.Count - 1; i++)
        {
            if (path[i].IsBarricaded)
            {   
                int total = Path.Count;
                for (int j = 0; j < total-i; j++)
                {   
                    path.RemoveAt(path.Count-1);
                }
                return;
            }
        }


    }
    public void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {

            if (child.TryGetComponent<Tile>(out var tile))
            {
                path.Add(tile);
            }

        }
        OrderReplaceX();
        OrderReplaceY();
        TurnPath();
        RemoveAfterBarricade();
    }
}
