using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSniperMove : MonoBehaviour
{
    public float bulletSpeed;
    public float Damage;
    //public AudioSource FireSound;

    public GameObject BoomParticle;
    public GameObject DamageText;
    public GameObject HillSquare;

    Vector2 mousePos;
    Vector2 Dir;
    Vector2 WeaponPos;

    float angle;

    Rigidbody2D rigid;

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

        GameObject.Find("BulletSniperSound").GetComponent<AudioSource>().Play();

        angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg; // ��ź��Ʈ�� ���� ����
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // ������ŭ ������

        WeaponPos = new Vector2(transform.position.x, transform.position.y);

        //Dir = (mousePos - WeaponPos);

        //rigid.AddForce(Dir.normalized * Time.deltaTime * bulletSpeed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * bulletSpeed);
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