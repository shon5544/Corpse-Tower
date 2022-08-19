using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{
    public GameObject DamageText;

    public float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            try
            {
                collision.GetComponent<EnemyHealthSystem>().HP -= (Damage * Player.Attack);
                var text = Instantiate(DamageText, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
                text.GetComponent<TextMesh>().text = "25";
            }
            catch
            {

            }

        }
    }
}
