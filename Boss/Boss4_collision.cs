using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4_collision : MonoBehaviour
{
    public Boss4 boss;

    // void Start()
    // {
    //     boss = GetComponent<Boss4>();
    // }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    // if (other.gameObject.tag == "Wall")
    // {
    //     GameObject.Find("WallBangSound").GetComponent<AudioSource>().Play();
    //     StartCoroutine(boss.camShake.Shake(1f, 0.5f));
    //     boss.dashState = false;
    // }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            GameObject.Find("WallBangSound").GetComponent<AudioSource>().Play();
            StartCoroutine(boss.camShake.Shake(1f, 0.5f));
            boss.dashState = false;
        }
    }
}
