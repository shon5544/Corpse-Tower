using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyCircle : MonoBehaviour
{
    float AttackTime;
    public float AttackCool = 0.5f;
    public GameObject DamageText;

    private void Start()
    {
        Destroy(gameObject, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        AttackTime += Time.deltaTime;

        transform.position = GameObject.Find("Player").GetComponent<Transform>().position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(AttackTime >= AttackCool)
        {
            try
            {
                collision.GetComponent<EnemyHealthSystem>().HP -= 25f;
                //var text = Instantiate(DamageText, transform.position, Quaternion.identity);
                var text = Instantiate(DamageText, collision.GetComponent<Transform>().position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
                text.GetComponent<TextMesh>().text = "25";
                AttackTime = 0f;
            } catch
            {

            }
        }
    }
}
