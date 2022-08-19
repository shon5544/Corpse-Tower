using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnPoint : MonoBehaviour
{
    public GameObject SpawnPaticle;
    public GameObject[] Enemies;

    public float time;

    GameObject targetEnemy;
    

    private void Start()
    {
        targetEnemy = Enemies[Random.Range(0, Enemies.Length)];
        StartCoroutine(Shown());
        StartCoroutine(Spawn());
    }

    IEnumerator Shown()
    {
        yield return new WaitForSeconds(time);
        GetComponent<SpriteRenderer>().DOFade(1, 2f);
        GameObject.Find("SpawnLoading").GetComponent<AudioSource>().Play();
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(4f + time);
        Instantiate(SpawnPaticle, transform.position, Quaternion.identity);
        Instantiate(targetEnemy, transform.position, Quaternion.identity);
        GameObject.Find("Spawn").GetComponent<AudioSource>().Play();
        yield return null;
        Destroy(gameObject);
    }
}
