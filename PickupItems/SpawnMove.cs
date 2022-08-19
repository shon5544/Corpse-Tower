using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnMove : MonoBehaviour
{
    float xVector;
    float yVector;
    Vector3 toVector;

    void Start()
    {
        xVector = Random.Range(0f, 5f);
        yVector = Random.Range(0f, 5f);

        toVector = new Vector3(xVector, yVector, 0);


        try
        {
            transform.DOMove(transform.position + toVector, 0.2f);
        }
        catch
        {

        }
        
    }
}
