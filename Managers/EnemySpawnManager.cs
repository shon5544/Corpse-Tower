using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawnManager : MonoBehaviour
{
    public GameObject obj_player;
    public GameObject[] enemies;
    //public Text KillAmountText;

    public int EnemyAmount;

    Vector3 PlayerPos;

    float cumulativeSum = 0;

    void Start()
    {
        foreach(GameObject i in enemies)
        {
            cumulativeSum += i.GetComponent<EnemyHealthSystem>().Weight;
        }

        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        PlayerPos = obj_player.transform.position;
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if(EnemyAmount > 0)
            {
                Instantiate(GetRandomEnemy(), GetOffset(), Quaternion.identity);
                EnemyAmount -= 1;
                yield return new WaitForSeconds(1.7f);
            } else
            {
                break;
            }
            
        }
    }

    GameObject GetRandomEnemy()
    {
        float cumulative = 0, roll = Random.Range(0f, cumulativeSum);

        foreach(var entry in enemies)
        {
            cumulative += entry.GetComponent<EnemyHealthSystem>().Weight;

            if (cumulative > roll)
            {
                return entry;
            }
        }

        return enemies[0];
    }

    Vector3 GetOffset()
    {
        int angle = Random.Range(-180, 180);
        Vector3 offset = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * 10;

        return PlayerPos + offset;
    }
}
