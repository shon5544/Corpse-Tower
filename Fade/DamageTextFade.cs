using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamageTextFade : MonoBehaviour
{
    
    void Start()
    {
        transform.DOMoveY(3, 3f);
        GetComponent<MeshRenderer>().material.DOFade(0, 1.3f);
        StartCoroutine(DestroySelf());
    }


    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
    }
    
}
