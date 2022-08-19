using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotgunMove : MonoBehaviour
{
    public float bulletSpeed;
    public float Damage;

    Vector2 mousePos;
    Vector2 Dir;
    Vector2 WeaponPos;

    float randomX;
    float randomY;

    Rigidbody2D rigid;

    public GameObject BoomParticle;
    public GameObject DamageText;
    public GameObject HillSquare;

    float PlusDamage;

    public GameObject BoomEffect;
    public GameObject HillBoomEffect;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        PlusDamage = Random.Range(-5f, 8f);

        //StartCoroutine(Remove());
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        randomX = Random.Range(-4, 4);
        randomY = Random.Range(-4, 4);

        WeaponPos = new Vector2(transform.position.x + randomX, transform.position.y + randomY);

        Dir = (mousePos - WeaponPos);

        //rigid.AddForce(Dir.normalized * Time.deltaTime * bulletSpeed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        transform.Translate(Dir.normalized * Time.deltaTime * bulletSpeed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    /*
    IEnumerator Remove()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Enemy" && (collision.gameObject.layer != 3 && collision.gameObject.layer != 8)) || collision.tag == "Wall")
        {
            try
            {
                float totalDamage = Mathf.Round(((Damage * Player.Attack) + PlusDamage) * 100) * 0.01f;

                collision.GetComponent<EnemyHealthSystem>().HP -= totalDamage;
                var textInstance = Instantiate(DamageText, transform.position + new Vector3(0, 0, -5), Quaternion.identity);
                textInstance.GetComponent<TextMesh>().text = $"{totalDamage}";

                if (Player.CurrentState == "BOOM")
                {
                    Instantiate(BoomParticle, transform.position, Quaternion.identity);
                }
                else if (Player.CurrentState == "VAMP")
                {
                    Instantiate(HillSquare, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
            }
            catch
            {
                if (Player.CurrentState == "BOOM")
                {
                    Instantiate(BoomParticle, transform.position, Quaternion.identity);
                }
                else if (Player.CurrentState == "VAMP")
                {
                    Instantiate(HillBoomEffect, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(BoomEffect, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
            }
        }
        // else
        // {
        //     Destroy(gameObject);
        // }
    }
}
