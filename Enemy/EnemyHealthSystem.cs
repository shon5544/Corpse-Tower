using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSystem : MonoBehaviour
{
    public float HP = 100f;
    public ParticleSystem Ps;


    public AudioSource hit;
    public AudioSource[] Die;

    public GameObject DeadEffect;

    //Text KillAmountText;
    //int KillAmount;

    public float Weight;
    public bool isBoss;
    public GameObject BossDeadParticle;

    private void Start()
    {
        StartCoroutine(PlayEffect());
        //KillAmountText = GameObject.Find("KillAmount").GetComponent<Text>();
        //KillAmount = GameObject.Find("EnemySpawner").GetComponent<EnemySpawnManager>().EnemyAmount;
    }

    /*void Update()
    {
        if(HP <= 0)
        {
            StartCoroutine(PlayEffect());
            //Instantiate(DeadEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject, 0.8f);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Ps.Play();
            hit.Play();
        }
    }


    IEnumerator PlayEffect()
    {
        while (true)
        {
            if (HP <= 0)
            {
                break;
            }

            yield return null;
        }

        Die[Random.Range(0, Die.Length)].Play();

        yield return new WaitForSeconds(0.1f);

        if (isBoss)
        {
            Instantiate(BossDeadParticle, transform.position, Quaternion.identity);
            GameObject.Find("Player").GetComponent<Player>().CanMove = true; // 간판 뜨기도 전에 보스를 순살해버렷을 때를 대비한 안전장치
            // GameObject.Find("MaFriend").SetActive(true);
        }
        else
        {
            Instantiate(DeadEffect, transform.position, Quaternion.identity);
        }

        GameManager.KillAmount = -1;

        try
        {
            gameObject.GetComponent<EnemyDropItem>().DropItem();
        }
        catch
        {

        }
        Destroy(gameObject);
    }
}
