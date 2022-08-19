using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLifeCycle : MonoBehaviour
{
    ParticleSystem particle;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitUntil(() => particle && !particle.IsAlive());
        Destroy(gameObject);
    }
}
